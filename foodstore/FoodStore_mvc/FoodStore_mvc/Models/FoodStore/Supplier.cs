using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public string Vendor { get; set; }
        public string SupplierEmail { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
