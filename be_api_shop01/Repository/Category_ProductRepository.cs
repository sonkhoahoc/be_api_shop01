using AutoMapper;
using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Category_ProductRepository : ICategory_ProductRepository
    {
        public readonly ApplicationContext _context;
        public readonly IMapper _mapper;

        public Category_ProductRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<long> AddCategory_Product(Category_ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory_Product(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category_ProductModel>> GetAllCategory_Product()
        {
            var category_product = await _context.Category_Product.ToListAsync();
            return _mapper.Map<List<Category_ProductModel>>(category_product);
        }

        public async Task<Category_ProductModel> GetCategory_ProductById(long id)
        {
            var category_product = await _context.Category_Product.FindAsync(id);   
            return _mapper.Map<Category_ProductModel>(category_product);
        }

        public Task UpdateCatetgoryProduct(long id, Category_ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
