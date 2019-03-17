using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Models
{
    public class Player
    {
        public string ID { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Int64 Health { get; set; }
        public string Attack  { get; set; }
    }
}
