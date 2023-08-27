using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using be_api_shop01.Models.Common;
using be_api_shop01.IRepository;
using be_api_shop01.Entities;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_FileController : ControllerBase
    {
        private readonly IProduct_FileRepository _product_file_repository;

        public Product_FileController(IProduct_FileRepository product_file_repository)
        {
            _product_file_repository = product_file_repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProduct_File()
        {
            try
            {
                var file = await _product_file_repository.GetListFile();
                return Ok(new ResponseMessageModel<List<Product_File>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = file
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("product/{product_id}")]
        public async Task<IActionResult> GetListProduct_FileByPro_Id(long product_id)
        {
            try
            {
                var file = await _product_file_repository.GetListFileByPro_Id(product_id);
                return Ok(new ResponseMessageModel<List<Product_File>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = file
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct_FileById(long id)
        {
            try
            {
                var file = await _product_file_repository.GetFikeById(id);

                if(file == null)
                {
                    return Ok(new ResponseMessageModel<Product_File>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Product_File>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = file
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct_File(long proId,[FromBody] Product_File file)
        {
            try
            {
                var files = await _product_file_repository.CreateFile(proId, file);
                return Ok(new ResponseMessageModel<Product_File>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = files
                });

            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct_FIle(long id,[FromBody] Product_File file)
        {
            try
            {
                var files = await _product_file_repository.UpdateFile(id, file);
                if(files == null)
                {
                    return Ok(new ResponseMessageModel<Product_File>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Product_File>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = files
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct_File(long id)
        {
            try
            {
                var files = await _product_file_repository.DeleteFile(id);

                if (!files)
                {
                    return Ok(new ResponseMessageModel<Product_File>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Product_File>
                {
                    StatusCode = 200,
                    Message = "Xoá size thành công!!!",
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý vui lòng thực hiện lại!!!",
                    Data = null
                });
            }
        }
    }
}
