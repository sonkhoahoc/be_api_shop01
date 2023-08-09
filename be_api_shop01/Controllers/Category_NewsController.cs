using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_NewsController : ControllerBase
    {
        public readonly ICategory_NewsRepository _repository;

        public Category_NewsController(ICategory_NewsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory_News()
        {
            try
            {
                var category_product = await _repository.GetAllCategory_News();
                return Ok(category_product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory_NewsById(long id)
        {
            try
            {
                var category_product = await _repository.GetCategory_NewsById(id);
                if(category_product == null)
                {
                    return NotFound();
                }
                return Ok(category_product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory_News(Category_News category)
        {
            try
            {
                var id = await _repository.AddCategory_News(category);
                return CreatedAtAction(nameof(GetCategory_NewsById), new {id}, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory_News(long id, Category_News category)
        {
            try
            {
                await _repository.UpdateCategory_News(id, category);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory_News(long id)
        {
            try
            {
                await _repository.DeleteCategory_News(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
