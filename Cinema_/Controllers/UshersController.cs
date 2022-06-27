using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class UshersController : Controller
    {
        // GET: UsherController
        [Authorize(Roles = "Usher")]
        public ActionResult Usher()
        {
            return View();
        }

        // GET: UsherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
