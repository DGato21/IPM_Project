using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Stage1()
        {
            ViewBag.Title = "Stage 1 - Project Proposal";

            return View();
        }

        public ActionResult Adopt()
        {
            ViewBag.Title = "Adopt a Dog Page.";

            return View();
        }
    }
}