using Microsoft.EntityFrameworkCore;
using GadgetsShop.Data.Models;

namespace GadgetsShop.Data
{
    /// <summary>
    /// This class regisrates the tables in the database.
    /// </summary>
    public class AppDBContent : DbContext
    {
        //Constructor
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        //Tables in the database
        public DbSet<Gadget> Gadget { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
