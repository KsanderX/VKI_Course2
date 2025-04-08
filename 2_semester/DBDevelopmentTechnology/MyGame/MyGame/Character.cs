using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Character
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Level { get; set; }
        public string Origin { get; set; }
        public string Sex { get; set; }
        public int PlayerID { get; set; }
        public Player Player { get; set; }
    }
}
