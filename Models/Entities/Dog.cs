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

        [JsonProperty("breed")]
        public string Breed { get; set; }

        [JsonProperty("fur")]
        public string Fur { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ageYear")]
        public int AgeYear { get; set; }

        [JsonProperty("ageMonth")]
        public int AgeMonth { get; set; }

        [JsonProperty("timeInCaptivityYear")]
        public int TimeInCaptivityYear { get; set; }

        [JsonProperty("timeInCaptivityMonth")]
        public int TimeInCaptivityMonth { get; set; }

        //Specific App Info
        [JsonProperty("likes")]
        public int Likes { get; set; } = 0;

        [JsonProperty("isAdopted")]
        public bool isAdopted { get; set; } = false;

        [JsonProperty("news")]
        public List<News> Feed { get; set; } = new List<News>();

        public List<string> Figures { get; set; } = new List<string>();

        public string dbLocation { get; set; }

        public Dog (int id, string name, string category, string gender, int age, int likes, bool isAdopted, 
            string breed, string fur, string location)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Gender = gender;
            this.Age = age;
            this.Likes = likes;
            this.isAdopted = isAdopted;
            this.Breed = breed;
            this.Fur = fur;
            this.Location = location;

            this.Figures = new List<string>();
            this.Feed = new List<News>();
            this.dbLocation = null;
        }

        public Dog(int id, string name, string category, string gender)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Gender = gender;
            //Default Info
            this.Age = -1;
            this.Likes = 0;
            this.isAdopted = false;

            this.TimeInCaptivityMonth = -1;
            this.TimeInCaptivityYear = -1;

            this.AgeMonth = -1;
            this.AgeYear = -1;

            this.Breed = "undefined";
            this.Fur = "undefined";

            this.Location = "unknown";

            this.Figures = new List<string>();
            this.Feed = new List<News>();
            this.dbLocation = null;
        }

        [JsonConstructor()]
        public Dog()
        {
            this.dbLocation = null;
        }
    
        //Formats
        public string ageStringFormat()
        {
            string finalFormat = "Unknown";
            if (this.AgeYear != -1)
            {
                finalFormat = $"{this.AgeYear} years";

                if (this.AgeMonth > 0)
                {
                    finalFormat += " ( since ";
                    finalFormat += new DateTime(DateTime.Today.Year - this.AgeYear, this.AgeMonth, 1).ToString("yyyy MMM");
                    finalFormat += " )";
                }
            }

            return finalFormat;
        }

        public string timeInCaptivityStringFormat()
        {
            string finalFormat = "Unknown";
            if (this.TimeInCaptivityYear != -1)
            {
                finalFormat = $"{this.TimeInCaptivityYear} years";

                if (this.TimeInCaptivityMonth > 0)
                {
                    finalFormat += " ( since ";
                    finalFormat += new DateTime(DateTime.Today.Year - this.TimeInCaptivityYear, this.TimeInCaptivityMonth, 1).ToString("yyyy MMM");
                    finalFormat += " )";
                }
            }

            return finalFormat;
        }

        //Actions

        public void addLike()
        {
            this.Likes++;
        }
    }
}