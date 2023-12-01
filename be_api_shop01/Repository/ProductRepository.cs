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

        public async Task<List<Products>> GetInterestingProducts()
        {
            var pro = await _context.Products.Where(p => p.views_count > 5).OrderByDescending(p => p.dateAdded).ToListAsync();

            return pro;
        }

        public async Task<long> GetTotalProduct()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<Products> ProductById(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Products>> ProductList()
        {
            return await _context.Products.OrderByDescending(p => p.dateAdded).ToListAsync();
        }

        public async Task<List<Products>> ProductListByCate_Id(long cate_id)
        {
            return await _context.Products.Where(p => p.category_id == cate_id).OrderByDescending(p => p.dateAdded).ToListAsync();
        }

        public async Task<List<Products>> ProductListBySize(string size)
        {
            var pro = await _context.Products.OrderByDescending(p => p.dateAdded)
                .Join(
                    _context.Size,
                    p => p.id,
                    s => s.product_id,
                    (p, s) => new { Products = p, Size = s }
                )
                .Where(p => p.Size.name == size)
                .Select(p => p.Products)
                .ToListAsync();
            return pro;
        }

        public async Task<List<Products>> ProductList_Limit(long limit)
        {
            return await _context.Products.OrderBy(p => Guid.NewGuid()).Take((int)limit).ToListAsync();
        }

        public async Task<Products> UpdateProduct(long id, Products product)
        {
            var id_pro = await _context.Products.FindAsync(id);

            if(id_pro == null)
            {
                return null;
            }

            id_pro.category_id = product.category_id;
            id_pro.name = product.name;
            id_pro.price = product.price;
            id_pro.avatar = product.avatar;
            id_pro.description = product.description;

            _context.Entry(id_pro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return id_pro;
        }
    }
}
