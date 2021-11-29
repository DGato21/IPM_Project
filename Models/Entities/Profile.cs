using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class Profile
    {
        public string Username;

        public string Name;

        public string Gender;

        public int Age;

        public List<Dog> Following;

        public bool IsVolunteer;

        public bool IsDonner;

        public bool IsPartner;

        public bool HaveDog;

        public string dbLocation;
    }
}