using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Admin
    {
        #region Properties

        //private int aID;

        private string userName;

        private string adminPassword;

        //public int AID
        //{
        //    get { return aID; }
        //    set { aID = value; }
        //}
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
        #endregion Properties

        #region Constructors
        public Admin(string userName, string adminPassword)
        {
            this.userName = userName;
            this.adminPassword = adminPassword;
        }
    }
    #endregion Constructors
}