using GadgetsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.ViewModels
{
    /// <summary>
    /// This class provides an access to the current shop cart
    /// </summary>
    public class ShopCartViewModel
    {
        //Field
        private ShopCart shopCart;

        //Property
        public ShopCart ShopCart { get => shopCart; set => shopCart = value; }
    }
}
