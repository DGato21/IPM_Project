using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class Feed
    {
        [JsonProperty("newsFeed")]
        public List<News> feedNews { get; set; }

        public Feed()
        {
            this.feedNews = new List<News>();
        }
    }
}