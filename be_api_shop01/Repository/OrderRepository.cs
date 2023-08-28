using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.dateAdded = DateTime.Now;
            order.dateUpdated = DateTime.Now;

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrder(long id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(o => o.id == id);

            if(order == null)
            {
                return false;
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Order> GetOrderById(long id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task<List<Order>> GetOrderList()
        {
            return await _context.Order.OrderByDescending(o => o.dateAdded).ToListAsync();
        }

        public async Task<Order> UpdateOrder(long id, Order order)
        {
            var updateOrder = await _context.Order.FirstOrDefaultAsync(o => o.id == id);

            if(updateOrder == null)
            {
                return null;
            }

            updateOrder.voucher_id = order.voucher_id;
            updateOrder.voucher_discount = order.voucher_discount;
            updateOrder.receive_info = order.receive_info;
            updateOrder.note = order.note;
            _context.Entry(updateOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateOrder;
        }
    }
}
