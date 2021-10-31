using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models
{
    public class Dog
    {
        public static Dictionary<string, string> CATEGORIES = new Dictionary<string, string>()
        {
            {"BIG", "Big"},
            {"MEDIUM", "Medium"},
            {"SMALL", "Small"}
        };

        public static Dictionary<string, string> GENDER = new Dictionary<string, string>()
        {
            {"F", "Female"},
            {"M", "Male"}
        };

        public Dog (int id, string name, string category, string gender, int age, int likes, bool isAdopted)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Gender = gender;
            this.Age = age;
            this.Likes = likes;
            this.isAdopted = isAdopted;
            this.Figures = new List<string>();
        }

        public Dog(int id, string name, string category, string gender)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Gender = gender;
            //Default Info
            this.Age = 0;
            this.Likes = 0;
            this.isAdopted = false;
            this.Figures = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        //Specific Dog Info
        public int Likes { get; set; } = 0;

        public bool isAdopted { get; set; } = false;

        public List<string> Figures { get; set; } = new List<string>();
    }
}