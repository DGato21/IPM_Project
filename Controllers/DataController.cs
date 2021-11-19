using IPM_Project.Models;
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

        public DataController()
        {
            data = new DataManagement();
        }

        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchAllDogs(FormCollection collection)
        {
            ViewBag.Title = "ListDogs";

            ViewBag.Message = "Form Received:\n";
            string finalMessage = string.Empty;
            foreach (string col in collection.AllKeys)
                ViewBag.Message += $"{col}: {collection[col]}\n";

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
                

            return View("ListDogs", dogs);
        }
    }
}