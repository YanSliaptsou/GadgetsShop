using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsShop.Data.Interfaces;
using GadgetsShop.Data.Models;

namespace GadgetsShop.Data.Mocks
{
    public class MockCategory : IGadgetsCategory{

        public IEnumerable<Category> GetAllCategories{
            get{
                return new List<Category>{
                    new Category {Name = "Ноутбуки", Description = "Мобильные компьютеры для вашего комфорта."},
                    new Category {Name = "Мобильные телефоны", Description = "Будьте всегда на связи со своими близкими."},
                    new Category {Name = "Планшеты", Description = "Стильный современный гаджет для приятного времяпрепроваждения вдали от дома."}
                };
            }
        }
    }
}
