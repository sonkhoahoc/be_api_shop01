using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderRepository _repository;

        public SliderController(ISliderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlider()
        {
            try
            {
                var slider = await _repository.GetAllSlider();
                return Ok(slider);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(long id)
        {
            try
            {
                var slider = _repository.GetSliderById(id);
                if (slider == null)
                {
                    return NotFound();
                }
                return Ok(slider);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSlider(Slider slider)
        {
            try
            {
                var id = await _repository.AddSlider(slider);
                return CreatedAtAction(nameof(GetSliderById), new { id }, slider);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider(long id, Slider slider)
        {
            try
            {
                await _repository.UpdateSlider(id, slider);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiler(long id)
        {
            try
            {
                await _repository.DeleteSlider(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
