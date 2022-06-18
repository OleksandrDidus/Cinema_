using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class CashierController : Controller
    {
        // GET: CashierController
        [Authorize(Roles = "Cashier")]
        public IActionResult Cashier()
        {
            return View();
        }
    }
}
