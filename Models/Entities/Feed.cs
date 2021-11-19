using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class Feed
    {
        public List<News> feedNews { get; set; }
    }
}