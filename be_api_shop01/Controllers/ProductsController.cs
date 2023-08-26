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

        [HttpGet]
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

        [HttpGet("id")]
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

        [HttpPost]
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

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] Products products)
        {
            try
            {
                var pro = await _proReponsitory.UpdateProduct(products);

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

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                var pro = await _proReponsitory.DeleteProduct(id);

                if (!pro)
                {
                    return Ok(new ResponseMessageModel<Products>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy sản phẩm!!!",
                        Data  = null
                    });
                }

                return Ok(new ResponseMessageModel<Products>
                {
                    StatusCode = 200,
                    Message = "Xóa sản phẩm thành công!!!",
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
