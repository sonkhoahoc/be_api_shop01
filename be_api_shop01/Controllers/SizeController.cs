﻿using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
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

        [HttpGet("size-list")]
        public async Task<IActionResult> GetAllSize()
        {
            try
            {
                var sizes = await _repository.GetAllSize();
                var response = new ResponseMessageModel<List<Size>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách size thành công!!!",
                    Data = sizes
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

        [HttpGet("size/product/{productId}")]
        public async Task<IActionResult> GetListSizeByProId(long productId)
        {
            try
            {
                var sizes = await _repository.GetListSizrByProId(productId);
                var response = new ResponseMessageModel<List<Size>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách size theo sản phẩm thành công!!!",
                    Data = sizes
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

        [HttpGet("size/{id}")]
        public async Task<IActionResult> GetSizeById(long id)
        {
            try
            {
                var sizes = await _repository.GetSizeById(id);
                if (sizes == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy size!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<Size>
                {
                    StatusCode = 200,
                    Message = "Hiển thị size theo id thành công!!!",
                    Data = sizes
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

        [HttpPost("size-create")]
        public async Task<IActionResult> AddSize([FromBody] Size size)
        {
            try
            {
                var sizes = await _repository.AddSize(size);

                return Ok(new ResponseMessageModel<Size>
                {
                    StatusCode = 200,
                    Message = "thêm sản phẩm thành công!!!",
                    Data = sizes
                });
            }
            catch(Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPut("size-put/{id}")]
        public async Task<IActionResult> UpdateSize(long id, [FromBody] Size size)
        {
            try
            {
                var up_sizes = await _repository.UpdateSize(id, size);

                if(up_sizes == null)
                {
                    return Ok(new ResponseMessageModel<Size>
                    {
                        StatusCode = 404,
                        Message = "không thấy ",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Size>
                {
                    StatusCode = 200,
                    Message = "Thanh công",
                    Data = up_sizes
                });
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

        [HttpDelete("size-delete/{id}")]
        public async Task<IActionResult> DeleteSize(long id)
        {
            try
            {
                var is_delete = await _repository.DeleteSize(id);
                if(!is_delete)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm size!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 200,
                    Message = "Xoá size thành công!!!",
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
