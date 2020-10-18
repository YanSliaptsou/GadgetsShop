using GadgetsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Interfaces
{
    public interface IAllGadgets
    {
        IEnumerable<Gadget> GetGadgets { get; }
        IEnumerable<Gadget> GetAvailableGadgets { get; }
        Gadget GetObjectGadget(int gadgetID);
    }
}
