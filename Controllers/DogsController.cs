using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPM_Project.Models;
using IPM_Project.Models.Entities;

namespace IPM_Project.Controllers
{
    /// <summary>
    /// Directly dogs object interaction
    /// </summary>
    public class DogsController : Controller
    {
        DataManagement dataManager;

        // GET: Dogs
        public ActionResult Index()
        {
            //Load all the Dogs

            return View();
        }

        //TO IMPROVE
        public ActionResult Dog(int id)
        {
            //Load all the Dogs
            dataManager = new DataManagement();

            Dictionary<string, string> filter = new Dictionary<string, string>();
            filter.Add("ID", id.ToString());
            List<Dog> tmpDogs = dataManager.GetDogsFiltered(filter);

            if (tmpDogs == null || tmpDogs.Count == 0)
                return View("Dog", null);
            else
                return View("Dog", tmpDogs[0]);
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
