using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Food : Product
    {
        // Declare a property besides the ones inherited from product.
        #region Properties
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
        #endregion properties

        // Constructors (Food inherits its properties from Product except the imgPath which is added).
        #region Constructors

        // Constructor with pType needed to set and update Food.
        public Food(/*int pID,*/ string pType, string pName, double price, string pDescription, string imagePath) : base( /*pID, */ pType, pName, price, pDescription)
        {
            this.imagePath = imagePath;
        }
        // Constructor without pType needed when getting a list from the databse to display the menu on the menu page.
        public Food(/*int pID,*/ string pName, double price, string pDescription, string imagePath) : base( /*pID, */ pName, price, pDescription)
        {
            this.imagePath = imagePath;
        }
        #endregion Constructors
    }
}