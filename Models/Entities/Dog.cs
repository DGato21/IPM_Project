using IPM_Project.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class Dog
    {
        [JsonProperty("id")]
        public int Id { get; set; } = -1;
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("colour1")]
        public string Colour1 { get; set; }
        [JsonProperty("colour2")]
        public string Colour2 { get; set; }
        [JsonProperty("fur")]
        public string Fur { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("timeInCaptivity")]
        public string TimeInCaptivity { get; set; }

        //Specific App Info
        [JsonProperty("likes")]
        public int Likes { get; set; } = 0;

        [JsonProperty("isAdopted")]
        public bool isAdopted { get; set; } = false;

        [JsonProperty("news")]
        public List<News> Feed { get; set; } = new List<News>();

        public List<string> Figures { get; set; } = new List<string>();

        public Dog (int id, string name, string category, string gender, int age, int likes, bool isAdopted, 
            string colour1, string colour2, string fur, string location, string TimeInCaptivity)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Gender = gender;
            this.Age = age;
            this.Likes = likes;
            this.isAdopted = isAdopted;
            this.Colour1 = colour1;
            this.Colour2 = colour2;
            this.Fur = fur;
            this.Location = location;
            this.TimeInCaptivity = TimeInCaptivity;

            this.Figures = new List<string>();
            this.Feed = new List<News>();
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

            this.Colour1 = "undefined"; 
            this.Colour2 = "undefined";
            this.Fur = "undefined";

            this.Location = "unknown";
            this.TimeInCaptivity = "unknown";

            this.Figures = new List<string>();
            this.Feed = new List<News>();
        }

        [JsonConstructor()]
        public Dog()
        {

        }
    }
}