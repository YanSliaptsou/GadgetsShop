using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;
using GadgetsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GadgetsShop.Controllers
{
    /// <summary>
    /// This class provides an shopcart's controller
    /// </summary>
    public class ShopCartController : Controller
    {
        //Fields
        private readonly IAllGadgets _gadgRep;
        private readonly ShopCart _shopCart;

        //Constructor
        public ShopCartController(IAllGadgets gadgetRepository, ShopCart shopCart)
        {
            _gadgRep = gadgetRepository;
            _shopCart = shopCart;
        }
        /// <summary>
        /// This method finds and returns the HTML-page with the name of the method.
        /// </summary>
        /// <returns>The HTML-page from the Views/ShopCart repository</returns>
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel { ShopCart = _shopCart };
           
            return View(obj);
        }
        /// <summary>
        /// This method processes the gadget's adding to the basket.
        /// </summary>
        /// <param name="id">A gadget' id</param>
        /// <returns>Redirection to the following HTML-page.</returns>
        public RedirectToActionResult AddToCart(int id)
        {
            Gadget item = _gadgRep.GetGadgets.FirstOrDefault(i => i.Id == id);
            if(item!=null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This method processes the gadget's removing from the basket.
        /// </summary>
        /// <param name="shopCartItem">An item of the basket</param>
        /// <returns>Redirection to the following HTML-page.</returns>
        public RedirectToActionResult RemoveFromCart(ShopCartItem shopCartItem)
        {
            if(shopCartItem != null)
            {
                _shopCart.RemoveFromCart(shopCartItem);
            }

            return RedirectToAction("Index");
        }
    }
}
