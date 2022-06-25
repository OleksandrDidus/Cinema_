using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using System.Linq;
using Cinema.Enums;

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
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = (await _UserRepository.GetAsync(u => u.Login == model.Email)).FirstOrDefault();

                // User role check
                if((await _RoleRepository.GetAsync(r => r.Id == (int)Roles.User)).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("", "Роль користувача відсутня! Необхідно дабавити її до Бази Даних!");
                }

                if (user == null)
                {
                    // Define User
                    user = new User { Login = model.Email, Password = model.Password };
                    user.RoleId = (int)Roles.User;

                    // Add user
                    await _UserRepository.AddAsync(user);

                    // Autentificate user
                    await Authenticate(user); // аутентификация

                    // Redirect to main page
                    return RedirectToAction("Index", "Session");
                }
                else
                {
                    // When user is exists then generate error
                    ModelState.AddModelError("", "Пользователь с заданным логином уже существует!");
                }
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

                    return RedirectToAction("Index", "Session");
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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Session");
        }
    }
}