using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Product
    {
        public Product()
        {
            ProductInvoice = new HashSet<ProductInvoice>();
            ProductInvoiceWithQuantity = new HashSet<ProductInvoiceWithQuantity>();
            ProductPurchaseOrder = new HashSet<ProductPurchaseOrder>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Mfg { get; set; }
        public string Vendor { get; set; }
        public decimal? Price { get; set; }

        public virtual Manufacturer MfgNavigation { get; set; }
        public virtual Supplier VendorNavigation { get; set; }
        public virtual ICollection<ProductInvoice> ProductInvoice { get; set; }
        public virtual ICollection<ProductInvoiceWithQuantity> ProductInvoiceWithQuantity { get; set; }
        public virtual ICollection<ProductPurchaseOrder> ProductPurchaseOrder { get; set; }
    }
}
