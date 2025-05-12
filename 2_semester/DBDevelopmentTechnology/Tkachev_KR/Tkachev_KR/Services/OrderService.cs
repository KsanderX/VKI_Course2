using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tkachev_KR.DataBase;

namespace Tkachev_KR.Services
{
    public class OrderService : IOrderService
    {
        private TkachevContext _context;
        public OrderService()
        {
            _context = new TkachevContext();
        }      

        public List<Order> GetOrder(int customerId)
        {
           return _context.Orders.Include(c => c.Customer).Include( p => p.Fproduct)
                .Where(i => i.FcustomerId == customerId).ToList();
        }


        public List<Order> SortNameProduct(int custoerId)
        {
            return _context.Orders.Include(c => c.Customer).Include(p => p.Fproduct)
                .Where(v => v.FcustomerId == custoerId)
                .OrderByDescending(b => b.Fproduct.ProductName).ToList();
        }

        public List<Order> SortPriceProduct(int custoerId)
        {
           return _context.Orders.Include(c => c.Customer).Include(p => p.Fproduct)
                .Where(v => v.FcustomerId == custoerId)
                .OrderBy(b => b.Fproduct.Price).ToList();
        }
        public List<Order> SortDateProduct(int custoerId)
        {
            return _context.Orders
                .Include(c => c.Customer)
                .Include(p => p.Fproduct)
                .Where(v => v.FcustomerId == custoerId)
                .OrderByDescending(b => b.OrderDate)
                .ToList();
        }
    }
}
