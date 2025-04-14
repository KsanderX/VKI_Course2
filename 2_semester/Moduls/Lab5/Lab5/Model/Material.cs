using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new(); // продукты данного материала

        public override string ToString()
        {
            return Name;
        }
    }
}
