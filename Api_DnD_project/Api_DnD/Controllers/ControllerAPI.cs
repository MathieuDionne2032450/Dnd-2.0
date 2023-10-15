using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_DnD.Controllers
{
    public class ControllerAPI : Controller
    {
        // GET: ControllerAPI
        public ActionResult Index()
        {
            return View();
        }

        // GET: ControllerAPI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControllerAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControllerAPI/Create
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

        // GET: ControllerAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControllerAPI/Edit/5
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

        // GET: ControllerAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControllerAPI/Delete/5
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
