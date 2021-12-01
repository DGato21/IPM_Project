using IPM_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPM_Project.Models.Helper
{
    public class LoginManagement
    {
        private DataManagement dataManager;

        private Profile currentUser;

        public const string LOGIN_MESSAGE = "Welcome {0}";

        public LoginManagement()
        {
            this.currentUser = null;
            this.dataManager = new DataManagement();

            //Static Info for Demo
            currentUser = _getUserInfo("DoeJohn");
            if (this.currentUser == null)
                throw new Exception("Error Logging In");
        }

        public Profile GetCurrentUser()
        {
            return this.currentUser;
        }

        private Profile _getUserInfo(string userId)
        {
            return this.dataManager.GetProfileById(userId);
        }
    }
}