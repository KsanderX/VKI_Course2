using Lab5.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Service
{
    public interface IDbWorker
    {
        public List<Product> GetProducts();
        public List<Material> GetMaterials();
        public Material GetMaterialInId(int id);

        public List<Product> GetProductInMaterial(Material material);
        public void SaveChanges();
    }
}
