using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models
{
    public class Dog
    {
        public Dog (int id, string name, string category, string sex, int age, int likes, bool isAdopted)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Sex = sex;
            this.Age = age;
            this.Likes = likes;
            this.isAdopted = isAdopted;
            this.Figures = new List<string>();
        }

        public Dog(int id, string name, string category, string sex)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Sex = sex;
            //Default Info
            this.Age = 0;
            this.Likes = 0;
            this.isAdopted = false;
            this.Figures = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        //Specific Dog Info
        public int Likes { get; set; } = 0;

        public bool isAdopted { get; set; } = false;

        public List<string> Figures { get; set; } = new List<string>();
    }

    public enum DOGS_CATEGORIES
    {
        BIG,
        MEDIUM,
        SMALL
    }

    public enum DOG_SEX
    {
        FEMALE,
        MALE
    }
}