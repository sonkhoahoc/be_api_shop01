using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_ProductController : ControllerBase
    {
        private readonly ICategory_ProductRepository _repository;

        public Category_ProductController(ICategory_ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory_Product()
        {
            try
            {
                var category_product = await _repository.GetAllCategory_Product();
                return Ok(category_product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory_ProductById(long id)
        {
            try
            {
                var category_products = await _repository.GetCategory_ProductById(id);
                if(category_products == null)
                {
                    return NotFound();
                }
                return Ok(category_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory_Product(Category_Product category)
        {
            try
            {
                var id = await _repository.AddCategory_Product(category);
                return CreatedAtAction(nameof(GetCategory_ProductById), new { id }, category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory_Product(long id, Category_Product category)
        {
            try
            {
                await _repository.UpdateCategory_Product(id, category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory_Product(long id)
        {
            try
            {
                await _repository.DeleteCategory_Product(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
