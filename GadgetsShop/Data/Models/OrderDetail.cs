using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This class nts the model of order details.
    /// </summary>
    public class OrderDetail
    {
        //Fields
        private int id;
        private int orderID;
        private int gadgetID;
        private uint price;
        public virtual Gadget gadget { get; set; }
        public virtual Order order { get; set; }

        //Properties
        public int Id { get => id; set => id = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int GadgetID { get => gadgetID; set => gadgetID = value; }
        public uint Price { get => price; set => price = value; }
    }
}
