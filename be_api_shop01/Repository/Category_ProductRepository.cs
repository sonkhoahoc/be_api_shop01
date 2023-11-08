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

        public async Task<Category_Product> AddCategory(Category_Product category)
        {
            category.dateAdded = DateTime.Now;
            category.dateUpdated = DateTime.Now;

            _context.Category_Product.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteCategory(long Id)
        {
            var cate = await _context.Category_Product.FirstOrDefaultAsync(c => c.id == Id);

            if (cate == null)
            {
                return false;
            }

            _context.Category_Product.Remove(cate);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Category_Product>> GetAllCategories()
        {
            return await _context.Category_Product.OrderByDescending(c => c.dateAdded).ToListAsync();
        }

        public async Task<Category_Product> GetCategoryById(long Id)
        {
            return await _context.Category_Product.FirstOrDefaultAsync(c => c.id == Id);
        }

        public async Task<List<Category_Product>> GetChildCategories(long parentCategoryId)
        {
            return await _context.Category_Product.Where(c => c.parent_category_id == parentCategoryId).ToListAsync();
        }

        public async Task<Category_Product> UpdateCategory(long id, Category_Product category)
        {
            var cate = await _context.Category_Product.FirstOrDefaultAsync(c => c.id == id);

            if(cate == null)
            {
                return null;
            }

            cate.name = category.name;
            cate.parent_category_id = category.parent_category_id;
            _context.Entry(cate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return cate;
        }
    }
}
