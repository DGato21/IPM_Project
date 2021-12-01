using IPM_Project.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Controllers
{
    public class ProfileController : Controller
    {
        private LoginManagement loginManager;

        public ProfileController()
        {
            this.loginManager = new LoginManagement();
            ViewBag.Login = string.Format(LoginManagement.LOGIN_MESSAGE, loginManager.GetCurrentUser().Name);
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}