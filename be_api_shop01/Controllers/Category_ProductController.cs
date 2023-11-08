using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
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

        [HttpGet("category-product-list")]
        public async Task<IActionResult> GetListCategory()
        {
            try
            {
                var categories = await _repository.GetAllCategories();
                return Ok(new ResponseMessageModel<List<Category_Product>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách danh mục thành công!!!",
                    Data = categories
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("category-product-child/{parentId}")]
        public async Task<IActionResult> GetChildCategories(long parentId)
        {
            try
            {
                var child = await _repository.GetChildCategories(parentId);

                return Ok(new ResponseMessageModel<List<Category_Product>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách danh mục con thành công!!!",
                    Data = child
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(long id)
        {
            try
            {
                var category = await _repository.GetCategoryById(id);

                if (category == null)
                {
                    return Ok(new ResponseMessageModel<Category_Product>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy danh mục!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Lấy danh mục theo ID thành công!!!",
                    Data = category
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPost("category-product-create")]
        public async Task<IActionResult> CreateCategory([FromBody] Category_Product category)
        {
            try
            {
                var newCategory = await _repository.AddCategory(category);
                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Thêm danh mục thành công!!!",
                    Data = newCategory
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpPut("category-product-put/{id}")]
        public async Task<IActionResult> UpdateCategory(long id, [FromBody] Category_Product category)
        {
            try
            {
                var updatedCategory = await _repository.UpdateCategory(id, category);

                if (updatedCategory == null)
                {
                    return Ok(new ResponseMessageModel<Category_Product>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy danh mục!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Sửa danh mục thành công!!!",
                    Data = updatedCategory
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("category-product-delete/{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            try
            {
                var success = await _repository.DeleteCategory(id);

                if (!success)
                {
                    return Ok(new ResponseMessageModel<Category_Product>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy danh mục!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Xóa danh mục thành công!!!",
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thử lại!!!",
                    Data = null
                });
            }
        }
    }
}
