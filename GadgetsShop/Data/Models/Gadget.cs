using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This class represents the model of gadget.
    /// </summary>
    public class Gadget
    {
        //Fields
        private int id;
        private string name;
        private string shortDescription;
        private string longDescription;
        private string img;
        private ushort price;
        private bool available;
        private int categoryID;
        public virtual Category category { get; set; }

        //Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public string LongDescription { get => longDescription; set => longDescription = value; }
        public string Img { get => img; set => img = value; }
        public ushort Price { get => price; set => price = value; }
        public bool Available { get => available; set => available = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
    }
}
