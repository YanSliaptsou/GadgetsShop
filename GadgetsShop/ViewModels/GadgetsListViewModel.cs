using GadgetsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.ViewModels
{
    /// <summary>
    /// This classs represents the model's view of Gadgets.
    /// </summary>
    public class GadgetsListViewModel
    {
        //A field of the current category.
        private string gadgetCategory;
        //A field of the current list of gadgets.
        private IEnumerable<Gadget> gadgets;

        //Properties
        public string GadgetCategory { get => gadgetCategory; set => gadgetCategory = value; }
        public IEnumerable<Gadget> Gadgets { get => gadgets; set => gadgets = value; }
    }
}
