using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Cinema.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using Cinema.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using System.Linq;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenericRepository<User> _UserRepository;

        private readonly IGenericRepository<Role> _RoleRepository;
        public AccountController(IGenericRepository<User> UserRepository, IGenericRepository<Role> RoleRepository)
        {
            _UserRepository = UserRepository;
            _RoleRepository = RoleRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = (await _UserRepository.GetAsync(u => u.Login == model.Email)).FirstOrDefault();
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Login = model.Email, Password = model.Password };
                    Role userRole = (await _RoleRepository.GetAsync(r => r.Name == "user")).FirstOrDefault();
                    if (userRole != null)
                        user.Role = userRole;

                   await _UserRepository.AddAsync(user);
                   

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = (await _UserRepository.GetAsync(u => u.Login == model.Email && u.Password == model.Password,
                    x => x.Include(u => u.Role))).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}