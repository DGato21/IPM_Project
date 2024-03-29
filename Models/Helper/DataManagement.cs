﻿using IPM_Project.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        //Profiles
        private const string PROFILES_FOLDER = "Profiles";

        private string mainUrl;

        //Main App Variables (Static Loading for Now)
        private List<Dog> dogList { get; set; } 
        private List<Profile> profileList { get; set; } 
        private Feed feed { get; set; }

        public DataManagement()
        {
            this.mainUrl = HttpRuntime.AppDomainAppPath;

            this.dogList = new List<Dog>();
            this.profileList = new List<Profile>();
            this.feed = new Feed();
        }


        #region Dogs Endpoints + Auxiliar Methods

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

        public Dog GetDogById(int id)
        {
            Dictionary<string, string> filter = new Dictionary<string, string>();
            filter.Add("ID", id.ToString());
            List<Dog> tmpDogs = this.GetDogsFiltered(filter);

            if (tmpDogs == null || tmpDogs.Count == 0)
                return null;
            else
                return tmpDogs[0];
        }

        public void LikeDog(int dogId, Profile user)
        {
            Dog dog = GetDogById(dogId);

            dog.addLike(user);

            //TODO THE PART OF THE PROFILE
            _saveJson(JsonConvert.SerializeObject(dog), dog.dbLocation);
        }

        public void FollowDog(int dogId, Profile user)
        {
            Dog dog = GetDogById(dogId);

            dog.addFollow(user);
            user.addFollowing(dog);

            //TODO THE PART OF THE PROFILE
            _saveJson(JsonConvert.SerializeObject(dog), dog.dbLocation);
            _saveJson(JsonConvert.SerializeObject(user), user.dbLocation);
        }

        public void UnfollowDog(int dogId, Profile user)
        {
            Dog dog = GetDogById(dogId);

            dog.removeFollow(user);
            user.removeFollowing(dog);

            //TODO THE PART OF THE PROFILE
            _saveJson(JsonConvert.SerializeObject(dog), dog.dbLocation);
            _saveJson(JsonConvert.SerializeObject(user), user.dbLocation);
        }

        public void SponsorDog(int dogId, Profile user)
        {
            Dog dog = GetDogById(dogId);

            dog.addSponsor(user);
            user.addSponsoringDog(dog);

            // TODO THE PART OF THE PROFILE
            _saveJson(JsonConvert.SerializeObject(dog), dog.dbLocation);
            _saveJson(JsonConvert.SerializeObject(user), user.dbLocation);
        }

        //IDEIA: WHEN ADOPT, POST A NEWS

        #endregion

        #region Profile Endpoints

        public Profile GetProfileById(string userId)
        {
            _loadAllUsers();
            Profile profile = null;

            var tmp = this.profileList.Where(x => x.Username.Equals(userId, StringComparison.InvariantCultureIgnoreCase));
            if (tmp != null && tmp.Count() > 0)
                profile = tmp.First();

            return profile;
        }

        #endregion

        #region Feed Endpoints

        public Feed GetGeneralFeed()
        {
            _loadGeneralFeed();

            return this.feed;
        }

        public Feed GetUserFeed(Profile user)
        {
            Feed userFeed = new Feed();

            try
            {
                foreach (int dogId in user.Following)
                {
                    Dog currentDog = GetDogById(dogId);

                    userFeed.feedNews.AddRange(currentDog.Feed);
                }
            }
            catch (Exception ex) {}

            return userFeed;
        }

        #endregion

        #region Form Endpoints

        public void SubmitForm(FormCollection form, string formType, Profile user, int? dogId = null)
        {
            Dictionary<string, object> formDic = _convertFormToDic(form);

            string json = JsonConvert.SerializeObject(formDic);

            string now = DateTime.Now.ToString("yyyy-MM-dd_hh:mm:ss:ffff");

            _executeFormActions(formType, dogId, user);

            //TODO: O SAVE NAO ESTA A FUNCIONAR POR CAUSA DE CAMINHO INVALIDO

            string fileName = $"{formType}_{DateTime.Now.Ticks}.json";
            string path = $"{DB_MAINFOLDER}\\{FORMS_FOLDER}\\{fileName}";

            _saveJson(json, path);
        }

        //TO FINISH
        private void _executeFormActions(string formType, int? dogId, Profile user)
        {
            //TODO_DR - Finish actions for each form
            /*
             * Sponsor Dog: Get the Dog And Add Him a News
             */
            switch(formType)
            {
                case "AdoptDog":
                    break;
                case "SponsorDog":
                    if (dogId != null)
                        SponsorDog((int)dogId, user);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Static Info Load

        private void _loadStaticDogList()
        {
            string pathDir = $"{mainUrl}\\{ DB_MAINFOLDER}\\{DOGS_FOLDER}";

            //Directory Info
            List<string> dirs = Directory.GetDirectories(pathDir, 
                                                         "*", SearchOption.AllDirectories).ToList();

            foreach (string dir in dirs)
            {
                string name = string.Empty;
                string category = string.Empty;
                string sex = string.Empty;

                string mainSubString = dir.Replace(mainUrl, "").Replace($"\\{DB_MAINFOLDER}", "").Replace($"\\{DOGS_FOLDER}\\", "");

                string[] strSplit = mainSubString.Split('\\');

                if (strSplit.Count() - 1 == 2)
                {
                    name = strSplit[2];
                    category = strSplit[0];
                    sex = strSplit[1];
                    Dog dog = new Dog(-1, name, category, sex);

                    //Get the Photos
                    List<string> dogDir = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories).ToList();
                    //If no Json configured, ignore and proceed
                    if (dogDir.Count == 0)
                        continue;
                    foreach (string dogInfo in dogDir)
                    {
                        using (StreamReader sr = new StreamReader(dogInfo))
                        {
                            string json = sr.ReadToEnd();
                            dog = JsonConvert.DeserializeObject<Dog>(json);
                            dog.dbLocation = _getRelativePath(dogInfo);
                        }
                    }

                    //Get the Photos
                    List<string> photosDir = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).ToList();
                    dog.Figures.Clear(); //Clear Photos first do to a reset
                    foreach (string photo in photosDir)
                        dog.Figures.Add(_getRelativePath(photo));

                    this.dogList.Add(dog);
                }
            }
        }

        private void _loadGeneralFeed()
        {
            string dir = $"{mainUrl}\\{ DB_MAINFOLDER}\\{FEED_MAIN_FOLDER}";

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

        private void _loadAllUsers()
        {
            //Directory Info
            string mainProfileDir = $"{mainUrl}\\{DB_MAINFOLDER}\\{PROFILES_FOLDER}";

            Profile profile = null;
            //Get the Photos
            List<string> profilesDir = Directory.GetFiles(mainProfileDir, "*.json", SearchOption.AllDirectories).ToList();
            foreach (string path in profilesDir)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    profile = JsonConvert.DeserializeObject<Profile>(json);
                    profile.dbLocation = _getRelativePath(path);
                    this.profileList.Add(profile);
                }
            }

        }

        #endregion

        #region Utilities Methods

        private string _getRelativePath(string fullPath)
        {
            string relativePath = string.Empty;

            relativePath = fullPath.Replace(this.mainUrl, "");
            relativePath = relativePath.Substring(relativePath.IndexOf("\\")+1);

            return relativePath;
        }

        #endregion

        #region Utilities DB Methods

        private void _saveJson(string json, string relativePath)
        {
            string finalPath = Path.Combine(this.mainUrl + relativePath);
            FileInfo file = new FileInfo(finalPath);

            if (file.Exists)
            {
                file.Delete();
            }

            using(StreamWriter wr = file.CreateText())
            {
                wr.Write(json);
                wr.Close();
            }
        }

        private Dictionary<string, object> _convertFormToDic(FormCollection form)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach (string col in form.AllKeys)
                dic.Add(col, form[col]);

            return dic;
        }

        #endregion
    
    }
}