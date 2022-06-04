using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_.Controllers
{
    public class CashierController : Controller
    {
        // GET: CashierController
        public ActionResult Cashier()
        {
            return View();
        }
    }
}
