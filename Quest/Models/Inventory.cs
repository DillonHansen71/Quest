using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerID { get; set; }
        public List<Item> Items { get; set; }
        public Int64 Gold { get; set; }
    }
}
