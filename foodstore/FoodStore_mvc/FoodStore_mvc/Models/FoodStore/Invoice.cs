using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Invoice
    {
        public Invoice()
        {
            ProductInvoice = new HashSet<ProductInvoice>();
            ProductInvoiceWithQuantity = new HashSet<ProductInvoiceWithQuantity>();
        }

        public int InvoiceNum { get; set; }
        public string Branch { get; set; }

        public virtual Store BranchNavigation { get; set; }
        public virtual ICollection<ProductInvoice> ProductInvoice { get; set; }
        public virtual ICollection<ProductInvoiceWithQuantity> ProductInvoiceWithQuantity { get; set; }
    }
}
