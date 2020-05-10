using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Store
    {
        public Store()
        {
            Employee = new HashSet<Employee>();
            Invoice = new HashSet<Invoice>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public string Branch { get; set; }
        public string Region { get; set; }
        public string BuildingName { get; set; }
        public int? UnitNum { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
