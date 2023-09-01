using be_api_shop01.IRepository;
using be_api_shop01.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using be_api_shop01.Models.Common;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel loginModel)
        {
            try
            {
                var userId = await _userRepository.Authenticaticate(loginModel);
                if (userId == 0)
                {
                    return BadRequest(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Không tìm thấy tài khoản!!!",
                        Data = string.Empty
                    });
                }
                else if (userId == -1)
                {
                    return BadRequest(new ResponseMessageModel<string>
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
                        Data = userId
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel createModel)
        {
            try
            {
                var userModel = await _userRepository.CreateUser(createModel);

                if (userModel == null)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Tên tài khoản hoặc email đã tồn tại!!!",
                        Data = string.Empty
                    });
                }

                return Ok(new ResponseMessageModel<UserModel>
                {
                    StatusCode = 200,
                    Message = "Tạo tài khoản thành công!!!",
                    Data = userModel
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var userList = await _userRepository.GetUserList();
                return Ok(new ResponseMessageModel<List<UserModel>>
                {
                    StatusCode = 200,
                    Message = "Cập nhập danh sách tài khoản thành công!!!",
                    Data = userList
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound(new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy tài khoản!!!",
                        Data = null
                    });
                }
                return Ok(new ResponseMessageModel<UserModel>
                {
                    StatusCode = 200,
                    Message = "Thành công",
                    Data = user
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

        [HttpPut("user/{id}")]
        public async Task<IActionResult> ModifyUser(long id, [FromBody] UserModel userModel)
        {
            try
            {
                userModel.id = id; // Đảm bảo Id của userModel là id truyền vào từ route

                var user = await this._userRepository.ModifyUser(userModel);

                if (user == null)
                {
                    return BadRequest(new ResponseMessageModel<string>
                    {
                        StatusCode = 400,
                        Message = "Không tìm thấy người dùng",
                        Data = string.Empty
                    });
                }

                return Ok(new ResponseMessageModel<UserModel>
                {
                    StatusCode = 200,
                    Message = "Cập nhật thành công",
                    Data = user
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePassModel changePassModel)
        {
            try
            {
                var success = await _userRepository.ChangeUserPassword(changePassModel);
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
                    Message = "Có lỗi trong quá trình xử lý, vui lòng thử lại!!!",
                    Data = null
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy người dùng!!!",
                        Data =null
                    });
                }

                var success = await _userRepository.DeleteUser(id);
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

        [HttpGet("checkusername/{username}")]
        public async Task<IActionResult> CheckUsernameAvailability(string username)
        {
            try
            {
                var user = await _userRepository.CheckUser(username);
                if(user != null)
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
        public async Task<IActionResult> CheckUserExists([FromQuery] string username,  [FromQuery] string email)
        {
            try
            {
                var userCount = await _userRepository.CheckUserExists(username, email);
                return Ok(new ResponseMessageModel<int>
                {
                    StatusCode = 200,
                    Message = "Thành công!!!",
                    Data = userCount
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
    }
}
