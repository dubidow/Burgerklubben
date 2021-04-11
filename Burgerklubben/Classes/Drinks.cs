using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Drinks : Product
    {
       // No other properties besides the ones inherited is needed.
        
        // Constructors (Drinks inherits its properties from Product).
        #region Constructors

        // Constructor with pType needed to set and update Drink.
        public Drinks(/*int pID,*/ string pType, string pName, double price, string pDescription) : base(/*pID,*/ pType, pName, price, pDescription)
        {

        }
        // Constructor without pType needed when getting a list from the databse to display the menu on the menu page.
        public Drinks(/*int pID,*/ string pName, double price, string pDescription) : base(/*pID,*/ pName, price, pDescription)
        {

        }
        #endregion Constructors
    }
}