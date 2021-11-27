using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdoptDogForm()
        {
            return View();
        }

        public ActionResult DonatingForm()
        {
            return View();
        }

        public ActionResult PartnerForm()
        {
            return View();
        }

        public ActionResult SurrenderDogForm()
        {
            return View();
        }

        public ActionResult VolunteeringForm()
        {
            return View();
        }
    }
}
