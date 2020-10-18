using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This class represents the model of shopcart and provides some logic working with database
    /// </summary>
    public class ShopCart
    {
        //Fields
        private readonly AppDBContent _appDBContent;
        private string shopCartID;
        private List<ShopCartItem> listShopItems;

        //Constructor
        public ShopCart(AppDBContent appDBContent)
        {
            this._appDBContent = appDBContent;
        }

        //Properties
        public string ShopCartID { get => shopCartID; set => shopCartID = value; }
        public List<ShopCartItem> ListShopItems { get => listShopItems; set => listShopItems = value; }
        public AppDBContent AppDBContent => _appDBContent;

        /// <summary>
        /// This method gets shopcart and sets an ID on it.
        /// </summary>
        /// <param name="services">Parametr defines a mechanism for retrieving a service object.</param>
        /// <returns>A new shopcart</returns>
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", shopCartId);

            return new ShopCart(context) { ShopCartID = shopCartId };
        }
        /// <summary>
        /// This method adds the item of the chosen gadget to the database.
        /// </summary>
        /// <param name="gadget">The gadget item that a user chose.</param>
        public void AddToCart(Gadget gadget)
        {
            AppDBContent.ShopCartItem.Add(new ShopCartItem 
            {
                ShopCartID = ShopCartID,
                Gadget = gadget,
                Price = gadget.Price
            });
            AppDBContent.SaveChanges();
        }
        /// <summary>
        /// This method removes the chosen item from the basket and database.
        /// </summary>
        /// <param name="shopCartItem">The chosen basket item.</param>
        public void RemoveFromCart(ShopCartItem shopCartItem)
        {
            AppDBContent.ShopCartItem.Remove(shopCartItem);
            AppDBContent.SaveChanges();
        }
        /// <summary>
        /// This method returns the list of the chosen gadgets.
        /// </summary>
        /// <returns>The list of chosen gadgets.</returns>
        public List<ShopCartItem> GetShopItems()
        {
            return AppDBContent.ShopCartItem.Where(c => c.ShopCartID == ShopCartID).Include(s => s.Gadget).ToList();
        }
        
    }
}
