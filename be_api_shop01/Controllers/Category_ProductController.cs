using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using be_api_shop01.Models;

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
                var response = new ResponseMessageModel<List<Category_Product>>
                {
                    StatusCode = 200,
                    Message = "Hiện thị danh sách loại sản phẩm thành công!!!",
                    Data = category_product
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory_ProductById(long id)
        {
            try
            {
                var category_product = await _repository.GetCategory_ProductById(id);
                if (category_product == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy loại sản phẩm!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Hiển thị loại sản phẩm theo id thành công!!!",
                    Data = category_product
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

        [HttpPost]
        public async Task<IActionResult> AddCategory_Product([FromBody] Category_Product category)
        {
            try
            {
                var category_product = await _repository.AddCategory_Product(category);
                var response = new ResponseMessageModel<long>
                {
                    StatusCode = 201,
                    Message = "Thêm loại tin tức thành công",
                    Data = category_product
                };
                return CreatedAtAction(nameof(GetCategory_ProductById), new { id = category_product }, response);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetCategory_Product(long id, Category_Product category)
        {
            try
            {
                await _repository.UpdateCategory_Product(id, category);
                var response = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Sửa loại sản phẩm thành công!!!",
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory_Product(long id)
        {
            try
            {
                var is_delete = await _repository.DeleteCategory_Product(id);
                if (!is_delete)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy sản phẩm tức!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Xoá thành công loại sản phẩm",
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
