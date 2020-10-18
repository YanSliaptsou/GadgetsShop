using GadgetsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gadget> availableGadgets { get; set; }
    }
}
