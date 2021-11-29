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

        public ActionResult AdoptDogForm(string dogName)
        {
            ViewBag.Title = $"Adopt {dogName}";

            return View();
        }

        public ActionResult SponsorDogForm(string dogName)
        {
            ViewBag.Title = $"Sponsor {dogName}";

            return View();
        }

        public ActionResult DonatingForm()
        {
            ViewBag.Title = "Make a Donation";

            return View();
        }

        public ActionResult PartnerForm()
        {
            ViewBag.Title = "Become a Partner";

            return View();
        }

        public ActionResult SurrenderDogForm()
        {
            ViewBag.Title = "Surrender a Dog";

            return View();
        }

        public ActionResult VolunteeringForm()
        {
            ViewBag.Title = "Become a Volunteer";

            return View();
        }


        public ActionResult ReceiveForm(FormCollection form, string type)
        {
            ViewBag.Title = "Initialize";

            try
            {
                ViewBag.Title = $"Form {type} submited sucessfully";

                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Title = $"Something Wrong! Form {type} not submited.";

                ViewBag.Message = $"Error: {ex.Message}.";

                return View();
            }
        }
    }
}
