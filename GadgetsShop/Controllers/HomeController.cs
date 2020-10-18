using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.ViewModels;

namespace GadgetsShop.Controllers
{
    /// <summary>
    /// This class provides a home page's controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IAllGadgets _gadgRep;

        //Constructor
        public HomeController(IAllGadgets gadgRep)
        {
            _gadgRep = gadgRep;
        }
        /// <summary>
        /// This method finds and returns the HTML-page with the name of the method.
        /// </summary>
        /// <returns>The HTML-page from the Views/Home repository</returns>
        public ViewResult Index()
        {
            var homeGadgets = new HomeViewModel{availableGadgets = _gadgRep.GetAvailableGadgets};
                
            return View(homeGadgets);
        }
    }
}
