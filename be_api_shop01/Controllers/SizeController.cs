using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _repository;

        public SizeController(ISizeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSize()
        {
            try
            {
                var size = await _repository.GetAllSize();  
                return Ok(size);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("size/{productId}")]
        public async Task<IActionResult> GetListSizeByProId(long productId)
        {
            try
            {
                var sizes = await _repository.GetListSizrByProId(productId);
                return Ok(sizes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeById(long id)
        {
            try
            {
                var size = await _repository.GetSizeById(id);
                if(size == null)
                {
                    return NotFound();
                }
                return Ok(size);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSize(Size size)
        {
            try
            {
                var id = await _repository.AddSize(size);
                return CreatedAtAction(nameof(GetSizeById), new { id }, size);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(long id, Size size)
        {
            try
            {
                await _repository.UpdateSize(id, size);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(long id)
        {
            try
            {
                await _repository.DeleteSize(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
