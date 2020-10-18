using GadgetsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsShop.Data.Interfaces
{
    public interface IGadgetsCategory
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
