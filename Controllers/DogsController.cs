using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPM_Project.Models;
using IPM_Project.Models.Entities;
using IPM_Project.Models.Helper;

namespace IPM_Project.Controllers
{
    /// <summary>
    /// Directly dogs object interaction
    /// </summary>
    public class DogsController : Controller
    {
        DataManagement dataManager;
        private LoginManagement loginManager;

        public DogsController()
        {
            this.loginManager = new LoginManagement();
            ViewBag.Login = string.Format(LoginManagement.LOGIN_MESSAGE, loginManager.GetCurrentUser().Name);
        }

        // GET: Dogs
        public ActionResult Index()
        {
            //Load all the Dogs

            return View();
        }

        //TO IMPROVE
        public ActionResult Dog(int id)
        {
            try
            {
                //Load all the Dogs
                dataManager = new DataManagement();

                Dog dog = dataManager.GetDogById(id);

                ViewBag.Title = $"{dog.Name}";

                return View("Dog", dog);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Like(int id)
        {
            try
            {
                //Load all the Dogs
                dataManager = new DataManagement();

                dataManager.LikeDog(id, this.loginManager.GetCurrentUser());

                //Return to Previous Page
                return RedirectToAction("Dog", "Dogs", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Follow(int id, string userId)
        {
            try
            {
                //Load all the Dogs
                dataManager = new DataManagement();

                dataManager.FollowDog(id, this.loginManager.GetCurrentUser());

                //Return to Previous Page
                return RedirectToAction("Dog", "Dogs", new { id = id });
            }
            catch
            {
                return View();
            }
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
