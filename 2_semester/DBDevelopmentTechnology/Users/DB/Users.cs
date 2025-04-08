using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.DB
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
