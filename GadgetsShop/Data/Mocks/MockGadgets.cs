using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsShop.Data.Mocks;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;

namespace GadgetsShop.Data.Mocks
{
    public class MockGadgets : IAllGadgets
    {
        private readonly IGadgetsCategory _categoryGadgets = new MockCategory();

        public IEnumerable<Gadget> GetGadgets {
            get
            {
                return new List<Gadget>
                {
                    new Gadget {
                        Name = "Lenovo Z51",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 1000,
                        //IsFavourite=true,
                        Available=true,
                        category = _categoryGadgets.GetAllCategories.First()
                    },
                    new Gadget {
                        Name = "Lenovo Z45",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 1000,
                        //IsFavourite=true,
                        Available=true,
                        category = _categoryGadgets.GetAllCategories.Last()
                    },
                    new Gadget {
                        Name = "Lenovo Z12",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 1000,
                        //IsFavourite=true,
                        Available=true,
                        category = _categoryGadgets.GetAllCategories.First()}
                };
            }
        }
        public IEnumerable<Gadget> GetAvailableGadgets { get; set; }

        public Gadget GetObjectGadget(int gadgetID)
        {
            throw new NotImplementedException();
        }
    }
}
