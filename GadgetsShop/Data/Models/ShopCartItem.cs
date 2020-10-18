using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This calss resents the model of shop cart item
    /// </summary>
    public class ShopCartItem
    {
        //Fields
        private int id;
        private Gadget gadget;
        private float price;
        private string shopCartID;

        //Properties
        public int Id { get => id; set => id = value; }
        public Gadget Gadget { get => gadget; set => gadget = value; }
        public float Price { get => price; set => price = value; }
        public string ShopCartID { get => shopCartID; set => shopCartID = value; }
    }
}
