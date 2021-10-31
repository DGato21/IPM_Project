using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPM_Project.Models;

namespace IPM_Project.Controllers
{
    public class DogsController : Controller
    {
        // GET: Dogs
        public ActionResult Index()
        {
            //Load all the Dogs

            return View();
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int id)
        {
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
