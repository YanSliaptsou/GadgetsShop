using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GadgetsShop.Data.Repository
{
    /// <summary>
    /// This class represents the access to the list of gadgets and implements the interface IAllGadgets 
    /// </summary>
    public class GadgetRepository : IAllGadgets
    {
        //Field of the database content
        private readonly AppDBContent _appDBContent;

        //Constructor
        public GadgetRepository(AppDBContent appDBContent)
        {
            this._appDBContent = appDBContent;
        }
        /// <summary>
        /// This method gets a list of gadgets from the database according to the category.
        /// </summary>
        public IEnumerable<Gadget> GetGadgets => _appDBContent.Gadget.Include(c => c.category);
        /// <summary>
        /// This method gets a list of available gadgets from the database according to the category.
        /// </summary>
        public IEnumerable<Gadget> GetAvailableGadgets => _appDBContent.Gadget.Where(p => p.Available).Include(c => c.category);
        /// <summary>
        /// This method returns the object of the gadget.
        /// </summary>
        /// <param name="gadgetID">The id of the gadget.</param>
        /// <returns>Gadget's object</returns>
        public Gadget GetObjectGadget(int gadgetID) => _appDBContent.Gadget.FirstOrDefault(p => p.Id == gadgetID);
        
    }
}
