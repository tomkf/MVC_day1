using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class ProductInvoiceWithQuantity
    {
        public int ProductId { get; set; }
        public int InvoiceNum { get; set; }
        public int? Quantity { get; set; }

        public virtual Invoice InvoiceNumNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
