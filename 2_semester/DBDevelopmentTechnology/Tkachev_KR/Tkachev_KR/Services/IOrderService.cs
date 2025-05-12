using Tkachev_KR.DataBase;

namespace Tkachev_KR.Services
{
    public interface IOrderService
    {
        public List<Order> GetOrder(int customerId);
    }
}
