using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Category_NewsRepository : ICategory_NewsRepository
    {
        public readonly ApplicationContext _context;

        public Category_NewsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<long> AddCategory_News(Category_News category)
        {
            _context.Category_News.Add(category);
            await _context.SaveChangesAsync();
            return category.id;
        }

        public async Task DeleteCategory_News(long id)
        {
            var category_news = await _context.Category_News.FirstOrDefaultAsync(ct => ct.id == id);
            if(category_news != null)
            {
                _context.Category_News.Remove(category_news);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category_News>> GetAllCategory_News()
        {
            return await _context.Category_News.OrderByDescending(ct => ct.dateAdded).ToListAsync();
        }

        public async Task<Category_News> GetCategory_NewsById(long id)
        {
            return await _context.Category_News.FirstOrDefaultAsync(ct => ct.id == id);
        }

        public async Task UpdateCategory_News(long id, Category_News category)
        {   
            var category_news = await _context.Category_News.FirstOrDefaultAsync(ct => ct.id == id);
            if(category_news != null)
            {
                category_news.name = category.name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
