using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ICategory_ProductRepository
    {
        public Task<List<Category_Product>> GetAllCategory_Product();
        public Task<Category_Product> GetCategory_ProductById(long id);
        public Task<Category_Product> AddCategory_Product(Category_Product category);
        public Task<Category_Product> UpdateCategory_Product(long id, Category_Product category);
        public Task<bool> DeleteCategory_Product(long id);
    }
}
