using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrderList();
        public Task<Order> GetOrderById(long id);
        public Task<Order> CreateOrder(Order order);
        public Task<Order> UpdateOrder(long id, Order order);
        public Task<bool> DeleteOrder(long id);
    }
}
