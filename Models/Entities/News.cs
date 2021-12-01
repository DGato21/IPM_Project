using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPM_Project.Properties;

namespace IPM_Project.Models.Entities
{
    public class News
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("news")]
        public string news { get; set; }

        [JsonProperty("fig")]
        public string figure { get; set; }

        [JsonProperty("publishTime")]
        public DateTime publishTime { get; set; }

        [JsonProperty("readers")]
        public List<Profile> readers { get; set; }

        [JsonProperty("supporters")]
        public List<Profile> supporters { get; set; }

        //Specific Entity Info

        [JsonProperty("entity")]
        public string specificEntity { get; set; } = null;

        [JsonProperty("id")]
        public int entityId { get; set; } = -1;

        public string dbLocation { get; set; } = null;

        public News()
        {
            this.supporters = new List<Profile>();
            this.readers = new List<Profile>();
            this.publishTime = new DateTime();
            this.figure = "../../images/dognews_default.jpg";
            this.news = "Loading...";
            this.title = "News Title Loading...";

            this.specificEntity = null;
            this.entityId = -1;
        }
    }
}