using IPM_Project.Models;
using IPM_Project.Models.Entities;
using IPM_Project.Models.Helper;
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
        private LoginManagement loginManager;
        private FeedManagement feedManager;

        public HomeController()
        {
            this.loginManager = new LoginManagement();
            ViewBag.Login = string.Format(LoginManagement.LOGIN_MESSAGE, loginManager.GetCurrentUser().Name);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            feedManager = new FeedManagement();
            Feed feed = feedManager.GetGeneralFeed();

            return View("Index", feed);
        }

        public ActionResult Stage1()
        {
            ViewBag.Title = "Stage 1 - Project Proposal";

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