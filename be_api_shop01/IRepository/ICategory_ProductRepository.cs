using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ICategory_ProductRepository
    {
        public Task<List<Category_Product>> GetAllCategories();
        public Task<Category_Product> GetCategoryById(long Id);
        public Task<List<Category_Product>> GetChildCategories(long parentCategoryId);
        public Task<Category_Product> AddCategory(Category_Product category);
        public Task<Category_Product> UpdateCategory(long id, Category_Product category);
        public Task<bool> DeleteCategory(long Id);
    }
}
