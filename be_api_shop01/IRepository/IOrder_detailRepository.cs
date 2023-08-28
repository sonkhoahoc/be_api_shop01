using be_api_shop01.Entities;
using be_api_shop01.Repository;

namespace be_api_shop01.IRepository
{
    public interface IOrder_detailRepository
    {
        public Task<List<Order_detail>> GetListOrder_detail();
        public Task<Order_detail> GetOrder_detailById(long id);
        public Task<Order_detail> CreateOrder_detail(Order_detail order_detail);
        public Task<Order_detail> ModifyOrder_detail(long id,  Order_detail order_detail);
        public Task<bool> DeleteOrder_detail(long id);
    }
}
