using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using be_api_shop01.Models.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel loginModel)
        {
            try
            {
                var cusId = await _customerRepository.CustomerLogin(loginModel);
                if (cusId == 0)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Không tim thấy tài khoản!!!",
                        Data = string.Empty
                    });
                }
                else if (cusId == -1)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Mật khẩu không đúng!!!",
                        Data = string.Empty
                    });
                }
                else
                {
                    return Ok(new ResponseMessageModel<long>
                    {
                        StatusCode = 200,
                        Message = "Đăng nhập thành công!!!",
                        Data = cusId
                    });
                }
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel customerModel)
        {
            try
            {
                var cusModel = await _customerRepository.CreateCustomer(customerModel);
                if (cusModel == null)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Tên tài khoản hoặc email đã tồn tại!!!",
                        Data = string.Empty
                    });
                }

                return Ok(new ResponseMessageModel<CustomerModel>
                {
                    StatusCode = 200,
                    Message = "Tạo tài khoản thành công!!!",
                    Data = cusModel
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> GetCustomerList()
        {
            try
            {
                var cusList = await _customerRepository.GetCustomerList();
                return Ok(new ResponseMessageModel<List<CustomerModel>>
                {
                    StatusCode = 200,
                    Message = "Cập nhập danh sách tài khoản thành công!!!",
                    Data = cusList
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            try
            {
                var cus = await _customerRepository.GetCustomerById(id);
                if (cus == null)
                {
                    return NotFound(new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy tài khoản!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<CustomerModel>
                {
                    StatusCode = 200,
                    Message = "Thành công",
                    Data = cus
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> ModifyCustomer(long id, [FromBody] CustomerModel cusModel)
        {
            try
            {
                cusModel.id = id;
                var cus = await this._customerRepository.ModifyCustomer(cusModel);
                if (cus == null)
                {
                    return BadRequest(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Không tìm thấy người dùng",
                        Data = string.Empty
                    });
                }

                return Ok(new ResponseMessageModel<CustomerModel>
                {
                    StatusCode = 200,
                    Message = "Cập nhật thành công",
                    Data = cus
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangeCustomerPassword([FromBody] ChangePassModel changePassModel)
        {
            try
            {
                var success = await _customerRepository.ChangeCustomerPassword(changePassModel);
                if (!success)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Đổi mật khẩu thất bại hoặc mật khẩu cũ không chính xác!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Đổi mật khẩu thành công!!!",
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            try
            {
                var cus = await _customerRepository.GetCustomerById(id);
                if (cus == null)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy người dùng!!!",
                        Data = null
                    });
                }

                var success = await _customerRepository.DeleteCustomer(id);
                if (!success)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Xóa người dùng thất bại",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Xóa người dùng thành công",
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("checkusername/{username}")]
        public async Task<IActionResult> CheckUsernameAvailability(string username)
        {
            try
            {
                var cus = await _customerRepository.CheckCustomer(username);
                if (cus != null)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 200,
                        Message = "Người dùng đã được sử dụng!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Người dùng đã có sẵn!!!",
                    Data = null,
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("checkuserexists")]
        public async Task<IActionResult> CheckCustomerExists([FromQuery] string username, [FromQuery] string emai)
        {
            try
            {
                var cusCount = await _customerRepository.CheckCustomerExists(username, emai);
                return Ok(new ResponseMessageModel<int>
                {
                    StatusCode = 200,
                    Message = "Thành công!!!",
                    Data = cusCount
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }
        //[AllowAnonymous]
        //[HttpPost("login")]
        //public async Task<IActionResult> CustomerLogin([FromBody] LoginModel login)
        //{
        //    try
        //    {
        //        var cusId = await _customerRepository.CustomerLogin(login);
        //        if (cusId > 0)
        //        {
        //            return Ok(new ResponseMessageModel<long>
        //            {
        //                StatusCode = 200,
        //                Message = "Đăng nhập thành công!!!",
        //                Data = cusId
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new ResponseMessageModel<string>
        //            {
        //                StatusCode = 400,
        //                Message = "Mật khẩu không đúng!!!",
        //                Data = string.Empty
        //            });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Ok(new ResponseMessageModel<IResponseData>
        //        {
        //            StatusCode = 500,
        //            Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
        //            Data = null
        //        });
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel userAdd)
        //{
        //    var response = await _customerRepository.CreateCustomer(userAdd);
        //    if (response != null)
        //    {
        //        return Ok(new ResponseMessageModel<CustomerModel>
        //        {
        //            StatusCode = 200,
        //            Message = "Tạo tài khoản thành công!!!",
        //            Data = userAdd
        //        });
        //    }
        //    return Ok(new ResponseMessageModel<IResponseData>
        //    {
        //        StatusCode = 500,
        //        Message = "Có lỗi xong quá trình xử lý, vui lòng thử lại!!!",
        //        Data = null
        //    });
        //}
    }
}
