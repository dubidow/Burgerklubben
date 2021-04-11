using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Product
    {
        #region Properties
        //private int pID;

        private string pType;

        private string pName;

        private double price;

        private string pDescription;

       /* public int PID
        {
            get { return pID; }
            set { pID = value; }
        }
       */
        public string PType
        {
            get { return pType; }
            set { pType = value; }
        }
        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string PDescription
        {
            get { return pDescription; }
            set { pDescription = value; }
        }
        #endregion Properties

        #region Constructors

        // Constructor without pType needed to get product/Food/Drinks from DAL to the productmanager/Menu page.
        public Product(/*int pID, string pType, */string pName, double price, string pDescription)
        {
            //this.pID = pID;
            //this.pType = pType;
            this.pName = pName;
            this.price = price;
            this.pDescription = pDescription;

        }
        // Constructor overload with pType needed to set product/Food/Drinks in the database through DAL and the productmanager/Menu page.
        public Product( string pType, string pName, double price, string pDescription) : this(pName, price, pDescription)
        {
            this.pType = pType;
        }
        #endregion Constructors
    }
}