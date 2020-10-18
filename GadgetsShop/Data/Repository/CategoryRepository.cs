using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;

namespace GadgetsShop.Data.Repository
{
    /// <summary>
    /// This class represents the access to the list of categories and implements the interface IGadgetCategory 
    /// </summary>
    public class CategoryRepository : IGadgetsCategory
    {
        //Field of the database content
        private readonly AppDBContent _appDBContent;
        //Constructor
        public CategoryRepository(AppDBContent appDBContent)
        {
            this._appDBContent = appDBContent;
        }
        /// <summary>
        /// This method gets a list of categories from the database.
        /// </summary>
        public IEnumerable<Category> GetAllCategories => _appDBContent.Category;
    }
}
