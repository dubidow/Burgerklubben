using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burgerklubben.Classes
{
    public class Orders
    {
       // Class is currently not used as there is no order-product possibility applied on the website.
        #region Properties
        private int orderNumber;

        private int cID;

        private DateTime orderDate;

        private int delivery;

        private int qty;

        private int pID;

        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public int CID
        {
            get { return cID; }
            set { cID = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public int Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public int PID
        {
            get { return pID; }
            set { pID = value; }
        }
        #endregion Properties

        #region Constructor
        public Orders(int orderNumber, int cID, DateTime orderDate, int delivery, int qty, int pID)
        {
            this.orderNumber = orderNumber;
            this.cID = cID;
            this.orderDate = orderDate;
            this.delivery = delivery;
            this.qty = qty;
            this.pID = pID;
        
        }
        #endregion Constructor
    }
}