using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface IProductsRepository
    {
        public Task<List<Products>> ProductList();
        public Task<List<Products>> ProductList_Limit(long limit);
        public Task<List<Products>> ProductListBySize(string size);
        public Task<List<Products>> ProductListByCate_Id(long cate_id);
        public Task<List<Products>> GetInterestingProducts();
        public Task<long> GetTotalProduct();
        public Task<Products> ProductById(long id);
        public Task<Products> CreateProduct(Products product);
        public Task<Products> UpdateProduct(long id, Products product);
        public Task<bool> DeleteProduct(long id);
    }
}
