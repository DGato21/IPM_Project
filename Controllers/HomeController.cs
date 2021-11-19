using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Controllers
{
    /// <summary>
    /// DR
    /// Initial Pages
    /// Pages that are directly reached from the Home
    /// This pages shouldn't have much Logic. They should be the starting point for more complex and data requests
    /// </summary>
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

        public ActionResult HelpUs()
        {
            ViewBag.Title = "Help Us Page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Title = "Contact Us Page.";

            return View();
        }
    }
}