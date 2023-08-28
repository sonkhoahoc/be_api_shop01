using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ICartRepository
    {
        public Task<List<Cart>> GetListCart();
        public Task<Cart> GetCartById(long id);
        public Task<Cart> CreateCart(Cart cart);
        public Task<Cart> UpdateCart(long id, Cart cart);
        public Task<bool> DeleteCart(long id);
    }
}
