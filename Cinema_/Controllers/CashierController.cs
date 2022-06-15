using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class CashierController : Controller
    {
        // GET: CashierController
        public IActionResult Cashier()
        {
            return View();
        }
    }
}
