using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ICategory_NewsRepository
    {
        public Task<List<Category_News>> GetAllCategory_News();
        public Task<Category_News> GetCategory_NewsById(long id);
        public Task<long> AddCategory_News(Category_News category);
        public Task UpdateCategory_News(long id, Category_News category);
        public Task<bool> DeleteCategory_News(long id);
    }
}
