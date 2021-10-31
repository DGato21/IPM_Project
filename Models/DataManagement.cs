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
        private const string DOGS_FOLDER = "Dogs";
        private const string LOGOS_FOLDER = "Logos";
        private const string DOG_FOLDER_FORMAT = "{0}\\{1}\\{2}";

        private string mainDir;

        //Main App Variables (Static Loading for Now)
        public List<Dog> dogList { get; set; } 

        public DataManagement()
        {
            this.mainDir = System.Web.Hosting.HostingEnvironment.MapPath("~");
            this.dogList = new List<Dog>();

            _loadStaticDogList();
        }

        private void _loadStaticDogList()
        {
            //Directory Info
            List<string> dirs = Directory.GetDirectories($"{mainDir}\\{DB_MAINFOLDER}\\{DOGS_FOLDER}", 
                                                          "*", SearchOption.AllDirectories).ToList();

            int id = 1;

            foreach (string dir in dirs)
            {
                string name = string.Empty;
                string category = string.Empty;
                string sex = string.Empty;

                string mainSubString = dir.Replace(mainDir, "").Replace($"\\{DB_MAINFOLDER}", "").Replace($"\\{DOGS_FOLDER}\\", "");

                string[] strSplit = mainSubString.Split('\\');

                if (strSplit.Count() - 1 == 2)
                {
                    name = strSplit[2];
                    category = strSplit[0];
                    sex = strSplit[1];
                    Dog dog = new Dog(id++, name, category, sex);

                    //Get the Photos
                    List<string> photosDir = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).ToList();
                    foreach (string photo in photosDir)
                        dog.Figures.Add(photo.Replace($"{mainDir}\\", ""));

                    this.dogList.Add(dog);
                }
            }
        }

        private void _loadDynamicDogInfo()
        {
            //Foreach Dog, Load the Info that is changed on the TXT/DB
        }

    }
}