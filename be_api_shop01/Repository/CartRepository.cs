using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationContext _context;

        public CartRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Cart> CreateCart(Cart cart)
        {
            cart.dateUpdated = DateTime.Now;
            cart.dateUpdated = DateTime.Now;

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return cart;    
        }

        public async Task<bool> DeleteCart(long id)
        {
            var cart = await _context.Cart.FirstOrDefaultAsync(c => c.id == id);

            if(cart == null)
            {
                return false;
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Cart> GetCartById(long id)
        {
            return await _context.Cart.FindAsync(id);
        }

        public async Task<List<Cart>> GetListCart()
        {
            return await _context.Cart.OrderByDescending(c => c.dateAdded).ToListAsync();
        }

        public async Task<Cart> UpdateCart(long id, Cart cart)
        {
            var update_cart = await _context.Cart.FirstOrDefaultAsync(c => c.id == id);

            if (update_cart == null)
            {
                return null;
            }

            update_cart.product_id = cart.product_id;
            update_cart.size_id = cart.size_id;
            update_cart.quantity = cart.quantity;
            update_cart.price = cart.price;
            _context.Entry(update_cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return update_cart;
        }
    }
}
