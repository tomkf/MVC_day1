using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Product = new HashSet<Product>();
        }

        public string Mfg { get; set; }
        public decimal? MfgDiscount { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
