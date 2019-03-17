using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Models
{
    public class Item
    {
        public int ID { get; set; }
        public Inventory InventoryID { get; set; }
        public string Name { get; set; }
        public string ItemImage { get; set; }
        public string Type { get; set; }
        public Int64 Damage { get; set; }
        public int Value { get; set; }
        
    }
}
