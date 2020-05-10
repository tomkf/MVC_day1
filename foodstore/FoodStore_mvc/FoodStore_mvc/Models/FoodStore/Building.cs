using System;
using System.Collections.Generic;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class Building
    {
        public Building()
        {
            Store = new HashSet<Store>();
        }

        public string BuildingName { get; set; }
        public int UnitNum { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Store> Store { get; set; }
    }
}
