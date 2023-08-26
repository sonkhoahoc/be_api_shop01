using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Products> CreateProduct(Products product)
        {
            product.dateAdded = DateTime.Now;
            product.dateUpdated = DateTime.Now;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            
            if(product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Products> ProductById(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Products>> ProductList()
        {
            return await _context.Products.OrderByDescending(p => p.dateAdded).ToListAsync();
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            var id_pro = await _context.Products.FirstOrDefaultAsync(p => p.id == product.id);

            if(id_pro == null)
            {
                return null;
            }

            id_pro.name = product.name;
            id_pro.price = product.price;
            id_pro.stock_quantity = product.stock_quantity;
            id_pro.avatar = product.avatar;

            _context.Entry(id_pro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return id_pro;
        }
    }
}
