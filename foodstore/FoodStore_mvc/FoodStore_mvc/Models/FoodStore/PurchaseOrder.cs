using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            ProductPurchaseOrder = new HashSet<ProductPurchaseOrder>();
        }

        public int PoNum { get; set; }
        public string Branch { get; set; }

        public virtual Store BranchNavigation { get; set; }
        public virtual ICollection<ProductPurchaseOrder> ProductPurchaseOrder { get; set; }
    }
}
