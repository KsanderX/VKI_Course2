using Tkachev_KR.DataBase;

namespace Tkachev_KR.Services
{
    public interface IOrderService
    {
        public List<Order> GetOrder(int customerId);
        public List<Order> SortNameProduct(int customerId);
        public List<Order> SortPriceProduct(int custoerId);
        public List<Order> SortDateProduct(int custoerId);

    }
}
