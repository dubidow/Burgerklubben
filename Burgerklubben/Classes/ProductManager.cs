using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class ProductManager
    {
        // Method which is used to take User data from the AdminCrud page and sends it through a method call to DAL to be inserted in the database.
        // Returns a bool to be used to tell the Admin user if the product was created successfully.
        #region CreateProduct
        public bool CreateProduct(string pType, string pName, double price, string pDescription, string imagePath)
        {
            bool successfull = true;
            Product p = null;

            #region MessageToAdmin
            if ((pType == null || pType.Trim().Length == 0) ||
                    (pName == null || pName.Trim().Length == 0) ||
                    (price == 99999) ||
                    (pDescription == null || pDescription.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin

            // Only objects of the Food class has an imgPath.
            if (imagePath != null && imagePath.Trim().Length > 0) { p = new Food(pType, pName, price, pDescription, imagePath); }
            else
                p = new Drinks(pType, pName, price, pDescription);

            successfull = DAL.CreateProduct(p);
            return successfull;
        }
        #endregion CreateProduct

        // Method which returns a list of Food from DAL/the database (is called from the Menu page to display the Burger Menu).
        #region GetBurger
        public static List<Food> GetBurger()
        {
            List<Food> f = DAL.GetBurger();
            return f;
        }
        #endregion GetBurger

        // Method which returns a list of Drinks from DAL/the database (is called from the Menu page to display the Drikkevare Menu).
        #region GetBeverages
        public static List<Drinks> GetBeverages()
        {
            List<Drinks> d = DAL.GetBeverages();
            return d;
        }
        #endregion GetBeverages

        // Method which is used to send the users search parameter from the Menu page to DAL/the database and return a list with the results
        // to be displayed on the Menu page.
        #region GetSearch
        public List<Product> GetSearch(string search)
        {

            List<Product> searchList = DAL.GetSearch(search);
            return searchList;

        }
        #endregion GetSearch

        // Method to be called from the AdminCrud.aspx.cs page getting a bool/message from DAL (the database) to be displayed on the AdminCrud page.
        // Sets new data in the database.
        #region SelectSP
        public bool ProductUpdateImgPath(string pName, string imgPathNew)
        {
            bool successfull = DAL.ProductUpdateImgPath(pName, imgPathNew);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0) ||
                    (imgPathNew == null || imgPathNew.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool ProductUpdatePDescription(string pName, string pDescriptionNew)
        {
            bool successfull = DAL.ProductUpdatePDescription(pName, pDescriptionNew);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0) ||
                    (pDescriptionNew == null || pDescriptionNew.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool ProductUpdatePName(string pName, string pNameNew)
        {
            bool successfull = DAL.ProductUpdatePName(pName, pNameNew);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0) ||
                    (pNameNew == null || pNameNew.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool ProductUpdatePrice(string pName, double priceNew)
        {
            bool successfull = DAL.ProductUpdatePrice(pName, priceNew);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0) ||
                    (priceNew == 1000000000))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool ProductUpdatePType(string pName, string pTypeNew)
        {
            bool successfull = DAL.ProductUpdatePType(pName, pTypeNew);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0) ||
                    (pTypeNew == null || pTypeNew.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        public bool ProductUpdateDelete(string pName)
        {
            bool successfull = DAL.ProductUpdateDelete(pName);
            #region MessageToAdmin
            if (    (pName == null || pName.Trim().Length == 0))
            {
                successfull = false;
            }
            #endregion MessageToAdmin
            return successfull;
        }
        #endregion SelectSP

    }
}