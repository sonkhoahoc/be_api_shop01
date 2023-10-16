﻿using be_api_shop01.Entities;
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

        [HttpGet("category-product/{id}")]
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

        [HttpPost("category-product-create")]
        public async Task<IActionResult> AddCategory_Product([FromBody] Category_Product category)
        {
            try
            {
                var category_product = await _repository.AddCategory_Product(category);
                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Thành công",
                    Data = category_product
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

        [HttpPut("category-product-put/{id}")]
        public async Task<IActionResult> UpdatetCategory_Product(long id,[FromBody] Category_Product category)
        {
            try
            {
                var categories = await _repository.UpdateCategory_Product(id, category);
                
                if(categories == null)
                {
                    return Ok(new ResponseMessageModel<Category_Product>
                    {
                        StatusCode = 404,
                        Message = "Không thấy",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Category_Product>
                {
                    StatusCode = 200,
                    Message = "Thành công ",
                    Data = categories
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

        [HttpDelete("category-product-delete/{id}")]
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
