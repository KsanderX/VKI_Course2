using Lab5.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Service
{
    public class DbWorker : IDbWorker
    {
        private AppDbContext _context;
        public DbWorker()
        {
            _context = new AppDbContext();
        }
        public List<Material> GetMaterials()
        {
           return _context.Materials.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Material).ToList();
        }

        public Material GetMaterialInId(int id)
        {
            return _context.Materials.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Product> GetProductInMaterial(Material material)
        {
            if (material == null)
            {
                return new List<Product>();
            }
            return _context.Products.Where(p => p.MaterialId == material.Id).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
