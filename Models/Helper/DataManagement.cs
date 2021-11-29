﻿using IPM_Project.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IPM_Project.Models
{
    public class DataManagement
    {
        private const string DB_MAINFOLDER = "0db";
        //Dogs
        private const string DOGS_FOLDER = "Dogs";
        private const string DOG_FOLDER_FORMAT = "{0}\\{1}\\{2}";
        //Feed
        private const string FEED_MAIN_FOLDER = "News";
        private const string FEED_GENERAL_FOLDER = "GeneralNews";
        //Forms
        private const string FORMS_FOLDER = "Forms";
        //Logos
        private const string LOGOS_FOLDER = "Logos";

        private string mainDir;

        //Main App Variables (Static Loading for Now)
        private List<Dog> dogList { get; set; } 
        private Feed feed { get; set; }

        public DataManagement()
        {
            this.mainDir = System.Web.Hosting.HostingEnvironment.MapPath("~");
            this.dogList = new List<Dog>();
            this.feed = new Feed();
        }

        #region Dogs Endpoints

        public List<Dog> GetAllDogs()
        {
            _loadStaticDogList();

            return dogList;
        }

        public List<Dog> GetDogsFiltered(Dictionary<string, string> filters)
        {
            _loadStaticDogList();

            List<Dog> filteredDog = new List<Dog>();

            foreach (Dog d in dogList)
                filteredDog.Add(d);

            foreach(KeyValuePair<string, string> f in filters)
            {
                if (filteredDog.Count == 0)
                    return null;

                switch(f.Key.Replace("modelDog.", "").ToUpperInvariant())
                {
                    case "ID":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Id.ToString().Equals(f.Value.ToUpperInvariant()))
                                                     .ToList();
                        }
                        break;

                    case "NAME":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Name.ToUpperInvariant().Contains(f.Value.ToUpperInvariant()))
                                                     .ToList();
                        }
                        break;

                    case "CATEGORY":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Category.Equals(f.Value, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        break;

                    case "ADOPTED":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            bool val = false;
                            if (bool.TryParse(f.Value, out val))
                            {
                                filteredDog = filteredDog.Where(x => x.isAdopted == val).ToList();
                            }
                        }
                        break;

                    case "GENDER":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Gender.Equals(f.Value, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        break;

                    case "COLOUR1":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Colour1.Equals(f.Value, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        break;

                    case "COLOUR2":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Colour2.Equals(f.Value, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        break;

                    case "FUR":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Fur.Equals(f.Value, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        break;

                    case "NEWS":
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            filteredDog = filteredDog.Where(x => x.Feed.Count() > 0).ToList();
                        }
                        break;
                }
            }

            return filteredDog;
        }

        //IDEIA: WHEN ADOPT, POST A NEWS

        #endregion

        #region Feed Endpoints

        public Feed GetGeneralFeed()
        {
            _loadGeneralFeed();

            return this.feed;
        }

        #endregion

        #region Static Info Load

        //TODO: IMPROVE ITERATIONS: BIPART IN 2 METHODs
        private void _loadStaticDogList()
        {
            //Directory Info
            List<string> dirs = Directory.GetDirectories($"{mainDir}\\{DB_MAINFOLDER}\\{DOGS_FOLDER}", 
                                                          "*", SearchOption.AllDirectories).ToList();

            foreach (string dir in dirs)
            {
                string name = string.Empty;
                string category = string.Empty;
                string sex = string.Empty;

                string mainSubString = dir.Replace(mainDir, "").Replace($"\\{DB_MAINFOLDER}", "").Replace($"\\{DOGS_FOLDER}\\", "");

                string[] strSplit = mainSubString.Split('\\');

                int id = 1;
                if (strSplit.Count() - 1 == 2)
                {
                    name = strSplit[2];
                    category = strSplit[0];
                    sex = strSplit[1];
                    Dog dog = new Dog(id++, name, category, sex);


                    //Get the Photos
                    List<string> dogDir = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories).ToList();
                    foreach (string dogInfo in dogDir)
                    {
                        using (StreamReader sr = new StreamReader(dogInfo))
                        {
                            string json = sr.ReadToEnd();
                            dog = JsonConvert.DeserializeObject<Dog>(json);
                        }
                    }

                    //Get the Photos
                    List<string> photosDir = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).ToList();
                    foreach (string photo in photosDir)
                        dog.Figures.Add(photo.Replace($"{mainDir}\\", ""));

                    this.dogList.Add(dog);
                }
            }
        }

        private void _loadGeneralFeed()
        {
            string dir = $"{mainDir}\\{DB_MAINFOLDER}\\{FEED_MAIN_FOLDER}";

            //Get the Photos
            List<string> generalFeedDir = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories).ToList();
            foreach (string newsInfo in generalFeedDir)
            {
                using (StreamReader sr = new StreamReader(newsInfo))
                {
                    Feed feed = new Feed();

                    string json = sr.ReadToEnd();
                    feed = JsonConvert.DeserializeObject<Feed>(json);

                    this.feed = feed;
                }
            }
        }

        private void _loadUserFeed(string userId)
        {
            //Directory Info
            List<string> dirs = Directory.GetDirectories($"{mainDir}\\{DB_MAINFOLDER}\\{FEED_GENERAL_FOLDER}",
                                                          "*", SearchOption.AllDirectories).ToList();
        }

        #endregion
    }
}