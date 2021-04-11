using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Info
    {
        #region Properties
        
        private string email;

        private string streetNameNumber;

        private string city;

        private int zipCode;

        private int phone;

        private string openingHours;

        private string aboutUs;


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string StreetNameNumber
        {
            get { return streetNameNumber; }
            set { streetNameNumber = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string OpeningHours
        {
            get { return openingHours; }
            set { openingHours = value; }
        }

        public string AboutUs
        {
            get { return aboutUs; }
            set { aboutUs = value; }
        }
        #endregion Properties

        #region Constructors

        // Default constructor needed to instantiate an Info object in the method DAL.GetInfo without parameters
        public Info()
        { }

        // Constructor needed to create an Info object in DAL.GetInfo the be displayed on the Info page
        public Info(string email, string streetNameNumber, int zipCode, string city, int phone, string openingHours, string aboutUs)
        {
            this.email = email;
            this.streetNameNumber = streetNameNumber;
            this.city = city;
            this.zipCode = zipCode;
            this.phone = phone;
            this.openingHours = openingHours;
            this.aboutUs = aboutUs;
        }
        #endregion Constructors
    }
}