using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class LoginManager
    {
        // Checks if Admins login credentials is valid/exists in the database.
        #region CheckLogin
        public int CheckLogin(string userName, string adminPassword)
        {
            Admin a = new Admin(userName, adminPassword);

            int count = DAL.CheckLogin(a);
            
            return count;
        }
        #endregion CheckLogin
    }
}