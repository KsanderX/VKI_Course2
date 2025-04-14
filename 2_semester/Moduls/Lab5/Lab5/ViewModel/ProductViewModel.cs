using Lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.ViewModel
{
    internal class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Material> Materials { get; set; }
    }
}
