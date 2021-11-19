﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Entities
{
    public class News
    {
        [JsonProperty("news")]
        public string news { get; set; }

        [JsonProperty("fig")]
        public string figure { get; set; }
    }
}