using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Order_detailRepository : IOrder_detailRepository
    {
        private readonly ApplicationContext _context;

        public Order_detailRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Order_detail> CreateOrder_detail(Order_detail order_detail)
        {
            order_detail.dateAdded = DateTime.Now;
            order_detail.dateUpdated = DateTime.Now;

            _context.Order_detail.Add(order_detail);
            await _context.SaveChangesAsync();

            return order_detail;
        }

        public async Task<bool> DeleteOrder_detail(long id)
        {
            var order_detail = await _context.Order_detail.FirstOrDefaultAsync(o => o.id == id);

            if(order_detail == null)
            {
                return false;
            }

            _context.Order_detail.Remove(order_detail);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Order_detail>> GetListOrder_detail()
        {
            return await _context.Order_detail.OrderByDescending(o => o.dateAdded).ToListAsync();
        }

        public async Task<Order_detail> GetOrder_detailById(long id)
        {
            return await _context.Order_detail.FindAsync(id);
        }

        public async Task<Order_detail> ModifyOrder_detail(long id, Order_detail order_detail)
        {
            var updateOr = await _context.Order_detail.FirstOrDefaultAsync(o => o.id == id);

            if(updateOr == null)
            {
                return null;
            }

            updateOr.quantity = order_detail.quantity;
            updateOr.price = order_detail.price;
            updateOr.product_id = order_detail.product_id;
            updateOr.size_id = order_detail.size_id;
            updateOr.quantity = order_detail.quantity;
            updateOr.total_price = order_detail.total_price;
            _context.Entry(updateOr).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateOr;
        }
    }
}
