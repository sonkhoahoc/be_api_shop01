﻿using AutoMapper;
using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Category_ProductRepository : ICategory_ProductRepository
    {
        public readonly ApplicationContext _context;

        public Category_ProductRepository(ApplicationContext context)
        {
            _context = context;

        }

        public async Task<long> AddCategory_Product(Category_Product category)
        {
            _context.Category_Product.Add(category);
            await _context.SaveChangesAsync();
            return category.id;
        }

        public async Task DeleteCategory_Product(long id)
        {
            var category_product = await _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
            if(category_product != null)
            {
                _context.Category_Product.Remove(category_product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category_Product>> GetAllCategory_Product()
        {
            return await _context.Category_Product.OrderByDescending(ct => ct.dateAdded).ToListAsync();
        }

        public async Task<Category_Product> GetCategory_ProductById(long id)
        {
            return await _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
        }

        public async Task UpdateCategory_Product(long id, Category_Product category)
        {
            var category_products = await _context.Category_Product.FirstOrDefaultAsync(ct => ct.id == id);
            if(category_products != null)
            {
                category_products.name = category.name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
