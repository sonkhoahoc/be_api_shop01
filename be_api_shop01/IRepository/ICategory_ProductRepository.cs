﻿using be_api_shop01.Entities;
using be_api_shop01.Models;

namespace be_api_shop01.IRepository
{
    public interface ICategory_ProductRepository
    {
        public Task<List<Category_Product>> GetAllCategory_Product();
        public Task<Category_Product> GetCategory_ProductById(long id);
        public Task<long> AddCategory_Product(Category_Product category);
        public Task UpdateCategory_Product(long id, Category_Product category);
        public Task DeleteCategory_Product(long id);
    }
}