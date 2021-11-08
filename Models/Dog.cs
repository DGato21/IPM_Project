using Newtonsoft.Json;
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

        [JsonConstructor()]
        public Dog()
        {

        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }

        //Specific Dog Info
        [JsonProperty("likes")]
        public int Likes { get; set; } = 0;

        [JsonProperty("isAdopted")]
        public bool isAdopted { get; set; } = false;

        public List<string> Figures { get; set; } = new List<string>();
    }
}