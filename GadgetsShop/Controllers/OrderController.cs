using GadgetsShop.Data;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Controllers
{
    /// <summary>
    /// This class provides an order's controller
    /// </summary>
    public class OrderController : Controller
    {
        //Fields
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        //Constructor
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this._allOrders = allOrders;
            this._shopCart = shopCart;
        }

        /// <summary>
        /// This method finds and returns the HTML-page with the name of the method.
        /// </summary>
        /// <param name="order">Order item</param>
        /// <returns>The HTML-page from the Views/Order repository</returns>
        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// This method finds and returns the HTML-page with the name of the method.
        /// </summary>
        /// <param name="order">Order item</param>
        /// <returns>The HTML-page from the Views/Order repository</returns>
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();

            if(_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Нет товаров в корзине!");
            }

            if(ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        /// <summary>
        /// This method finds and returns the HTML-page with the name of the method.
        /// </summary>
        /// <returns>The HTML-page from the Views/Order repository</returns>
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
