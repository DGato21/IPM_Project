using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.SpecificViewModels
{
    public class AdoptViewModel
    {
        public const int DOGS_PER_ROW = 3;

        public Dog modelDog { get; set; }
        public List<Dog[]> searchDogs { get; set; }
    }
}