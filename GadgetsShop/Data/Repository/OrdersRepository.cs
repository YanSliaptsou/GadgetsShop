using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Repository
{
    /// <summary>
    /// This class represents the access to work with orders, specifically the order's creation.
    /// </summary>
    public class OrdersRepository : IAllOrders
    {
        // Fields
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;
        private const string SQLconnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=GadgetsShop;Trusted_Connection=True;MultipleActiveResultSets=true";

        //Constructor
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this._appDBContent = appDBContent;
            this._shopCart = shopCart;
        }

        /// <summary>
        /// This creates an order.
        /// </summary>
        /// <param name="order">An order item.</param>
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopCart.ListShopItems;

            SqlWorker sqlWorker = new SqlWorker(SQLconnectionString);

            foreach(var element in items)
            {
                int gadgID = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT gadgetid FROM ShopCartItem WHERE id=" + element.Id));

                var orderDetail = new OrderDetail()
                {
                    GadgetID = gadgID,
                    OrderID = order.Id,
                    Price = Convert.ToUInt32(sqlWorker.SelectDataFromDB("SELECT price FROM Gadget WHERE id=" + gadgID))
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
