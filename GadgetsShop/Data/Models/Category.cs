using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This class represents the model of gadget's category.
    /// </summary>
    public class Category
    {
        //Fields
        private int id;
        private string name;
        private string description;
        private List<Gadget> gadgets;

        //Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public List<Gadget> Gadgets { get => gadgets; set => gadgets = value; }
    }
}
