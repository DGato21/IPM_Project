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

                ViewBag.User = this.loginManager.GetCurrentUser().Username;
                ViewBag.Title = $"{dog.Name}";

                return View("Dog", dog);
            }
            catch (Exception)
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

                ViewBag.User = this.loginManager.GetCurrentUser().Username;
                dataManager.LikeDog(id, this.loginManager.GetCurrentUser());

                //Return to Previous Page
                return RedirectToAction("Dog", "Dogs", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Follow(int id)
        {
            try
            {
                //Load all the Dogs
                dataManager = new DataManagement();

                ViewBag.User = this.loginManager.GetCurrentUser().Username;
                dataManager.FollowDog(id, this.loginManager.GetCurrentUser());

                //Return to Previous Page
                return RedirectToAction("Dog", "Dogs", new { id = id });
            }
            catch (Exception)
            { 
                return View();
            }
        }

        public ActionResult Unfollow(int id)
        {
            try
            {
                //Load all the Dogs
                dataManager = new DataManagement();

                ViewBag.User = this.loginManager.GetCurrentUser().Username;
                dataManager.UnfollowDog(id, this.loginManager.GetCurrentUser());

                //Return to Previous Page
                return RedirectToAction("Dog", "Dogs", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
