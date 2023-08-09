using be_api_shop01.Entities;
using be_api_shop01.Models;

namespace be_api_shop01.IRepository
{
    public interface ICategory_ProductRepository
    {
        public Task<List<Category_ProductModel>> GetAllCategory_Product(); 
        public Task<Category_ProductModel> GetCategory_ProductById(long id);
        public Task<long> AddCategory_Product(Category_ProductModel model);
        public Task UpdateCatetgoryProduct(long id, Category_ProductModel model);
        public Task DeleteCategory_Product(long id);
    }
}
