using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        public int ID {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }
        public string Email {  get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
