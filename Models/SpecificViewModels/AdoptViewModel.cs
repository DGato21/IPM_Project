using IPM_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPM_Project.Models.SpecificViewModels
{
    public class AdoptViewModel
    {
        public const int DOGS_PER_ROW = 3;

        public Dog modelDog { get; set; }
        public List<Dog[]> searchDogs { get; set; }

        //List Parameters
        public IEnumerable<SelectListItem> _categories { get; set; }
        public IEnumerable<SelectListItem> _gender { get; set; }
        public string _searchName { get; set; }
    }
}