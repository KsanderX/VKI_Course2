using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Example.Service
{
    public class IndentService : IIndentService
    {
        private ProductsContext _context;
        public IndentService()
        {
            _context = new ProductsContext();
        }
        public List<Indent> GetIndent(int userId)
        {
            return _context.Indents.Include(i => i.Product).Include(i => i.Client)
                .Where(i => i.ClientId == userId).ToList();            
        }

        public Indent GetIndetsById(string id, int userId)
        {
            return _context.Indents.Include(i => i.Product)
                .Include(i => i.Client)
                .Where(i => i.Id == Convert.ToInt32(id) && i.ClientId == userId)
                .FirstOrDefault();
        }       
    }
}
