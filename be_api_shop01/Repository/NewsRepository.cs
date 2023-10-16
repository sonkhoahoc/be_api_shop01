using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationContext _context;

        public NewsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddNews(News news)
        {
            news.dateAdded = DateTime.Now;
            news.dateUpdated = DateTime.Now;

            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return news.id;
        }

        public async Task<bool> DeleteNews(long id)
        {
            var id_delete = await _context.News.FindAsync(id);

            if(id_delete == null)
            {
                return false;
            }
            
            _context.News.Remove(id_delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _context.News.OrderByDescending(n => n.dateAdded).ToListAsync();
        }

        public async Task<List<News>> GetListNewsByCategory_Id(long category_id)
        {
            return await _context.News.Where(n => n.category_id == category_id).OrderByDescending(n => n.dateAdded).ToListAsync();
        }

        public async Task<News> GetNewsById(long id)
        {
            return await _context.News.FirstOrDefaultAsync(n => n.id == id);
        }

        public async Task UpdateNews(long id, News news)
        {
            var update_news = await _context.News.FirstOrDefaultAsync(n => n.id == id);
            if (update_news != null)
            {
                update_news.category_id = news.category_id;
                update_news.title = news.title;
                update_news.short_description = news.short_description;
                update_news.content = news.content;
                update_news.avatar = news.avatar;
                update_news.note = news.note;
                await _context.SaveChangesAsync();
            }
        }
    }
}
