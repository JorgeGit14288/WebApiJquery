using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class PersonasJqueryController : Controller
    {
        // GET: PersonasJquery
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonasJquery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasJquery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasJquery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasJquery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasJquery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasJquery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasJquery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
