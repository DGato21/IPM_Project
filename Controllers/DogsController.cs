using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPM_Project.Models;

namespace IPM_Project.Controllers
{
    /// <summary>
    /// Directly dogs object interaction
    /// </summary>
    public class DogsController : Controller
    {
        // GET: Dogs
        public ActionResult Index()
        {
            //Load all the Dogs

            return View();
        }

        public ActionResult Dog(int id)
        {
            //Load all the Dogs

            return View();
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        public ActionResult Adopt(int id, FormCollection collection)
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
    }
}
