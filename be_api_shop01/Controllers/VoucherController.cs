using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _repository;

        public VoucherController(IVoucherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVoucher()
        {
            try
            {
                var voucher = await _repository.GetAllVoucher();
                var response = new ResponseMessageModel<List<Voucher>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách voucher thành công!!!",
                    Data = voucher
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoucherById(long id)
        {
            try
            {
                var voucher = await _repository.GetVoucherById(id);
                if(voucher == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy voucher!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<Voucher>
                {
                    StatusCode = 200,
                    Message = "Hiển thị voucher theo id thành công!!!",
                    Data = voucher
                };
                return Ok(responses);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVoucher([FromBody] Voucher voucher)
        {
            try
            {
                var new_voucher = await _repository.AddVoucher(voucher);
                var response = new ResponseMessageModel<long>
                {
                    StatusCode = 200,
                    Message = "Thêm voucher thành công!!!",
                    Data = new_voucher
                };
                return CreatedAtAction(nameof(GetVoucherById), new { id = new_voucher }, response);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoucher(long id, [FromBody] Voucher voucher)
        {
            try
            {
                await _repository.UpdateVoucher(id, voucher);
                var response = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Sử voucher thành công!!!",
                    Data = null
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(long id)
        {
            try
            {
                var is_delete = await _repository.DeleteVoucher(id);
                if (!is_delete)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy voucher!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 200,
                    Message = "Xoá bản ghi thành công!!!",
                    Data = null
                };
                return Ok(responses);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }
    }
}
