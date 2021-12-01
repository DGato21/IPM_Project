using IPM_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Helper
{
    public class FeedManagement
    {
        private DataManagement dataManager;

        public FeedManagement()
        {
            this.dataManager = new DataManagement();
        }

        public Feed GetGeneralFeed()
        {
            return this.dataManager.GetGeneralFeed();
        }

        public Feed GetUserFeed(string userId)
        {
            return this.dataManager.GetUserFeed(userId);
        }

    }
}