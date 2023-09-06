using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
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

        [HttpGet("slider-list")]
        public async Task<IActionResult> GetAllSlider()
        {
            try
            {
                var slider = await _repository.GetAllSlider();
                var response = new ResponseMessageModel<List<Slider>>
                {
                    StatusCode = 200,
                    Message = "Hiện thị danh sách slider thành công!!!",
                    Data = slider
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpGet("slider/{id}")]
        public async Task<IActionResult> GetSliderById(long id)
        {
            try
            {
                var slider = await _repository.GetSliderById(id);
                if (slider == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy slider!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<Slider>
                {
                    StatusCode = 200,
                    Message = "Hiển thị slider theo id thành công!!!",
                    Data = slider
                };
                return Ok(responses);
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPost("slider-create")]
        public async Task<IActionResult> AddSlider([FromBody] Slider slider)
        {
            try
            {
                var sliders = await _repository.AddSlider(slider);
                var response = new ResponseMessageModel<long>
                {
                    StatusCode = 201,
                    Message = "Thêm slider thành công",
                    Data = sliders
                };
                return CreatedAtAction(nameof(GetSliderById), new {id = slider}, response);
            }   
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPut("slider-put/{id}")]
        public async Task<IActionResult> UpdatetSlider(long id, [FromBody] Slider slider)
        {
            try
            {
                await _repository.UpdateSlider(id, slider);
                var response = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Sửa loại slider thành công!!!",
                    Data = null
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("slider-delete/{id}")]
        public async Task<IActionResult> DeleteSiler(long id)
        {
            try
            {
                var is_delete = await _repository.DeleteSlider(id);
                if (is_delete)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy slider!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 200,
                    Message = "Xoá thành công slider",
                    Data = null
                };
                return Ok(responses);
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }
    }
}
