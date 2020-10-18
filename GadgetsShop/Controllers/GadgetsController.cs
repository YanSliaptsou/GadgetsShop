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
    /// This class provides a gadgets' controller
    /// </summary>
    public class GadgetsController : Controller
    {
        //Fields
        private readonly IAllGadgets _allGadgets;
        private readonly IGadgetsCategory _allCategories;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allGadgets">List of gadgets</param>
        /// <param name="gadgetsCategory">Gadgets' category</param>
        public GadgetsController(IAllGadgets allGadgets, IGadgetsCategory gadgetsCategory)
        {
            _allGadgets = allGadgets;
            _allCategories = gadgetsCategory;
        }
       
        //Url links settings
        [Route("Gadgets/List")]
        [Route("Gadgets/List/{category}")]

        ///<summary>
        ///This method finds and returns the HTML-page with the name of the method.
        ///</summary>
        ///<param name="category">Gadgets' category</param>
        ///<returns>The HTML-page from the Views/Gadgets repository</returns>
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Gadget> gadgets = null;
            string gadgetCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                gadgets = _allGadgets.GetGadgets.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Laptops",category,StringComparison.OrdinalIgnoreCase))
                {
                    gadgets = _allGadgets.GetGadgets.Where(i => i.category.Name.Equals("Ноутбуки")).OrderBy(i => i.Id);
                    gadgetCategory = "Ноутбуки";
                }

                else if (string.Equals("Phones", category, StringComparison.OrdinalIgnoreCase))
                {
                    gadgets = _allGadgets.GetGadgets.Where(i => i.category.Name.Equals("Мобильные телефоны")).OrderBy(i => i.Id);
                    gadgetCategory = "Мобильные телефоны";
                }

                else if(string.Equals("Tablets", category, StringComparison.OrdinalIgnoreCase))
                {
                    gadgets = _allGadgets.GetGadgets.Where(i => i.category.Name.Equals("Планшеты")).OrderBy(i => i.Id);
                    gadgetCategory = "Планшеты";
                }
            }

            var gadgObj = new GadgetsListViewModel
            {
                Gadgets = gadgets,
                GadgetCategory = gadgetCategory
            };

            ViewBag.Title = gadgetCategory;

            return View(gadgObj);
        }
    }
}
