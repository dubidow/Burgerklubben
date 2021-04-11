using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class InfoManager
    {
        // Method to be called from the Info.aspx.cs page getting an info object from DAL (the database) to be displayed on the Info page.
        #region GetInfo InfoPage
        public static Info GetInfo()
        {
            Info i = DAL.GetInfo();
            return i;
        }
        #endregion GetInfo InfoPage

        // Method to be called from the AdminCrud.aspx.cs page getting a bool/message from DAL (the database) to be displayed on the AdminCrud page.
        // Sets new data in the database.
        #region SelectSP

        public bool InfoUpdateAboutUs(string email, string aboutUs)
        {
           bool successfull = DAL.InfoUpdateAboutUs(email, aboutUs);
            #region MessageToAdmin
            if (    (email == null || email.Trim().Length == 0) ||
                    (aboutUs == null || aboutUs.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool InfoUpdateEmail(string emailOld, string emailNew)
        {
            bool successfull = DAL.InfoUpdateEmail(emailOld, emailNew);
            #region MessageToAdmin
            if (    (emailOld == null || emailOld.Trim().Length == 0) ||
                    (emailNew == null || emailNew.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool InfoUpdateOpeningHours(string email, string openingHours)
        {
            bool successfull = DAL.InfoUpdateOpeningHours(email, openingHours);
            #region MessageToAdmin
            if (    (email == null || email.Trim().Length == 0) ||
                    (openingHours == null || openingHours.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool InfoUpdatePhone(string email, int newPhone)
        {
            bool successfull = DAL.InfoUpdatePhone(email, newPhone);
            #region MessageToAdmin
            if (    (email == null || email.Trim().Length == 0) ||
                    (newPhone == 1000000000))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool InfoUpdateStreetNameNumber(string email, string streetNameNumber)
        {
            bool successfull = DAL.InfoUpdateStreetNameNumber(email, streetNameNumber);
            #region MessageToAdmin
            if (    (email == null || email.Trim().Length == 0) ||
                    (streetNameNumber == null || streetNameNumber.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool InfoUpdateZipCode(string email, int zipCode)
        {
            bool successfull = DAL.InfoUpdateZipCode(email, zipCode);
            #region MessageToAdmin
            if (    (email == null || email.Trim().Length == 0) ||
                    (zipCode == 1000000000))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        #endregion SelectSP
    }
}