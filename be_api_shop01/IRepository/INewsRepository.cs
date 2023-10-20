using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface INewsRepository
    {
        public Task<List<News>> GetAllNews();
        public Task<List<News>> GetListNewsByCategory_Id(long category_id);
        public Task<long> GetTotalNews();
        public Task<News> GetNewsById(long id);
        public Task<long> AddNews(News news);
        public Task UpdateNews(long id, News news);
        public Task<bool> DeleteNews(long id);
    }
}
