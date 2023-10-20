using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _proReponsitory;

        public ProductsController(IProductsRepository proReponsitory)
        {
            _proReponsitory = proReponsitory;
        }

        [HttpGet("product-list")]
        public async Task<IActionResult> GetListProduct()
        {
            try
            {
                var pro = await _proReponsitory.ProductList();
                return Ok(new ResponseMessageModel<List<Products>>
                {
                    StatusCode = 200,
                    Message = "Gọi danh sách sản phẩm thành công!!!",
                    Data  = pro
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

        [HttpGet("product/category/{cate_id}")]
        public async Task<ActionResult> GetListSizeByProId(long cate_id)
        {
            try
            {
                var p = await _proReponsitory.ProductListByCate_Id(cate_id);
                var response = new ResponseMessageModel<List<Products>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách thành công!!!",
                    Data = p
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

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            try
            {
                var pro = await _proReponsitory.ProductById(id);

                if(pro == null)
                {
                    return Ok(new ResponseMessageModel<Products>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy sản phẩm!!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Products>
                {
                    StatusCode = 200,
                    Message = "Gọi sản phẩm theo id thành công!!!",
                    Data = pro
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

        [HttpGet("product-count")]
        public async Task<IActionResult> GetTotalProduct()
        {
            try
            {
                var p = await _proReponsitory.GetTotalProduct();
                return Ok(new ResponseMessageModel<long>
                {
                    StatusCode = 200,
                    Message = "Lấy dữ liệu thành công!!!",
                    Data = p
                });
            }
            catch (Exception) 
            {
                    return Ok(new ResponseMessageModel<string>
                    {
                        StatusCode = 500,
                        Message = "Có lỗi trong quá trình xử lý!!!",
                        Data = null
                    });
            }
        }

        [HttpPost("product-create")]
        public async Task<IActionResult> CreateProduct([FromBody] Products product)
        {
            try
            {
                var pro = await _proReponsitory.CreateProduct(product);
                return Ok(new ResponseMessageModel<Products>
                {
                    StatusCode = 200,
                    Message = "thêm sản phẩm thành công!!!",
                    Data = pro
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

        [HttpPut("product-put/{id}")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] Products products)
        {
            try
            {
                var pro = await _proReponsitory.UpdateProduct(id,products);

                if(pro == null)
                {
                    return Ok(new ResponseMessageModel<Products>
                    {
                        StatusCode = 404,
                        Message = " Không tìm thấy sản phẩm !!!",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Products>
                {
                    StatusCode = 200,
                    Message = "Sửa sản phẩm thành công!!!",
                    Data = pro
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

        [HttpDelete("product-delete/{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                var pro = await _proReponsitory.DeleteProduct(id);

                if (!pro)
                {
                    var response = new ResponseMessageModel<Products>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy sản phẩm!!!",
                        Data = null
                    };
                    return NotFound(response);
                }   

                var newss = new ResponseMessageModel<Products>
                {
                    StatusCode = 200,
                    Message = "Xóa sản phẩm thành công!!!",
                    Data = null
                };
                return Ok(newss);
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
