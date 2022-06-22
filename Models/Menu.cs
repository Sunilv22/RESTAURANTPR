using System;
using System.Collections.Generic;

namespace RESTAURANTPROJ.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Ordermenus = new HashSet<Ordermenu>();
        }

        public int Itemno { get; set; }
        public string? Menu1 { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Ordermenu> Ordermenus { get; set; }
    }
}
