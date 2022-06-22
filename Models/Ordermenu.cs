using System;
using System.Collections.Generic;

namespace RESTAURANTPROJ.Models
{
    public partial class Ordermenu
    {
        public int Orderid { get; set; }
        public int? Itemno { get; set; }
        public string? Menu { get; set; }
        public string? Username { get; set; }
        public int? Price { get; set; }
        public DateTime? Orderdate { get; set; }

        public virtual Menu? ItemnoNavigation { get; set; }
    }
}
