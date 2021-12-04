using IPM_Project.Models;
using IPM_Project.Models.Entities;
using IPM_Project.Models.Helper;
using IPM_Project.Models.SpecificViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Controllers
{
    public class DataController : Controller
    {
        private DataManagement data;
        private LoginManagement loginManager;

        public DataController()
        {
            
            data = new DataManagement();
            this.loginManager = new LoginManagement();
            ViewBag.Login = string.Format(LoginManagement.LOGIN_MESSAGE, loginManager.GetCurrentUser().Name);
        }

        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchDogs(FormCollection collection = null)
        {
            ViewBag.Title = "ListDogs";

            ViewBag.Message = "Form Received:\n";
            string finalMessage = string.Empty;
            foreach (string col in collection.AllKeys)
                ViewBag.Message += $"{col}: {collection[col]}\n";

            AdoptViewModel adoptViewModel = new AdoptViewModel();
            adoptViewModel.modelDog = new Dog();

            List<Dog> dogs = null;
            if (collection == null || collection.AllKeys == null || collection.AllKeys.Count() == 0)
                dogs = data.GetAllDogs();
            else
            {
                Dictionary<string, string> filters = new Dictionary<string, string>();
                foreach (string col in collection.AllKeys)
                    filters.Add(col, collection[col]);

                dogs = data.GetDogsFiltered(filters);
            }

            adoptViewModel.searchDogs = new List<Dog[]>();

            //Add the List
            List<Dog> subList = new List<Dog>(AdoptViewModel.DOGS_PER_ROW);
            int i = 1;
            foreach(Dog d in dogs)
            {
                subList.Add(d);
                if (i == AdoptViewModel.DOGS_PER_ROW || i == dogs.Count)
                {
                    //Add the Dog List & Clear Vars
                    i = 1;
                    adoptViewModel.searchDogs.Add(subList.ToArray());
                    subList = new List<Dog>(AdoptViewModel.DOGS_PER_ROW);
                }
                else
                    i++;
            }
                
            return View("Adopt", adoptViewModel);
        }
    }
}