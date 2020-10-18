using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GadgetsShop.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace GadgetsShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if(!content.Gadget.Any())
            {
                content.AddRange(

                    new Gadget
                    {
                        Name = "Lenovo Z51",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 600,
                        //IsFavourite = true,
                        Available = true,
                        category = Categories["Ноутбуки"]
                    },
                    new Gadget
                    {
                        Name = "Lenovo Z45",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 1000,
                        //IsFavourite = true,
                        Available = true,
                        category = Categories["Ноутбуки"]
                    },
                    new Gadget
                    {
                        Name = "Lenovo Z12",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "/img/Lenovo_IdeaPad_330-15AST_81D600DWRU2_zP4ZFwi.jpg",
                        Price = 1000,
                        //IsFavourite = true,
                        Available = true,
                        category = Categories["Ноутбуки"]
                    }
                 ); 
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "Ноутбуки", Description = "Мобильные компьютеры для вашего комфорта."},
                        new Category {Name = "Мобильные телефоны", Description = "Будьте всегда на связи со своими близкими."},
                        new Category {Name = "Планшеты", Description = "Стильный современный гаджет для приятного времяпрепроваждения вдали от дома."}
                    };

                    category = new Dictionary<string, Category>();
                    
                    foreach(Category el in list)
                    {
                        category.Add(el.Name, el);
                    }
                }

                return category;
            }
        }
    }
}
