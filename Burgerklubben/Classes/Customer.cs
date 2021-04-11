using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Customer
    {
        // Class is currently not used as there is no order-product possibility applied on the website and no customer is needed.
        #region Properties

        private int cID;

        private string fName;

        private string lName;

        private string streetNameNumber;

        private int zipCode;

        private string city;

        private string email;

        private int phone;

        public int CID
        {
            get { return cID; }
            set { cID = value; }
        }
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }
        public string StreetNameNumber
        {
            get { return streetNameNumber; }
            set { streetNameNumber = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        #endregion Properties

        #region Constructors
        public Customer(int cID, string fName, string lName, string streetNameNumber, int zipCode, string city, string email, int phone)
        {
            this.cID = cID;
            this.fName = fName;
            this.lName = lName;
            this.streetNameNumber = streetNameNumber;
            this.city = city;
            this.zipCode = zipCode;
            this.phone = phone;

        }
        #endregion Constructors
    }
}