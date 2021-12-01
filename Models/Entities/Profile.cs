using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class Profile
    {
        [JsonProperty("username")]
        public string Username;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("gender")]
        public string Gender;

        [JsonProperty("age")]
        public int Age;

        [JsonProperty("birthday")]
        public DateTime Birthday;

        [JsonProperty("following")]
        public List<Dog> Following = new List<Dog>();

        [JsonProperty("godfather")]
        public List<Dog> Godfather = new List<Dog>();

        [JsonProperty("isVolunteer")]
        public bool IsVolunteer;

        [JsonProperty("isDonner")]
        public bool IsDonner;

        [JsonProperty("isPartner")]
        public bool IsPartner;

        [JsonProperty("haveDog")]
        public bool HaveDog;

        [JsonProperty("dbLocation")]
        public string dbLocation;

        [JsonConstructor()]
        public Profile()
        {

        }

        //Actions
        public void addFollowing(Dog dog)
        {
            this.Following.Add(dog);
        }

        public void addSponsoringDog(Dog dog)
        {
            this.Godfather.Add(dog);
        }
    }
}