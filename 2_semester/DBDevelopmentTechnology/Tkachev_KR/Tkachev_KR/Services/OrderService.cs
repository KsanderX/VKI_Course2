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
    }
}
