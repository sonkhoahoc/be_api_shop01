    using AutoMapper;
using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Category_ProductRepository : ICategory_ProductRepository
    {
        private readonly ApplicationContext _context;

        public Category_ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Category_Product> AddCategory_Product(Category_Product category)
        {
            category.dateAdded = DateTime.Now;
            category.dateUpdated = DateTime.Now;

            _context.Category_Product.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory_Product(long id)
        {
            var category_product = await _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
            if (category_product != null)
            {
                _context.Category_Product.Remove(category_product);
                await _context.SaveChangesAsync();
                return true;
            }
            return  false;
        }

        public async Task<List<Category_Product>> GetAllCategory_Product()
        {
            return await _context.Category_Product.OrderByDescending(ct => ct.dateAdded).ToListAsync();
        }

        public Task<Category_Product> GetCategory_ProductById(long id)
        {
            return _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
        }

        public async Task<Category_Product> UpdateCategory_Product(long id, Category_Product category)
        {
            var category_product = await _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
            if(category_product == null)
            {
                return null;
            }
            category_product.name  = category.name;
            _context.Entry(category_product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category_product;
        }
    }
}
