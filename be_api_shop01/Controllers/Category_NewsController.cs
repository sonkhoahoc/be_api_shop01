using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using be_api_shop01.Models.Common;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_NewsController : ControllerBase
    {
        private readonly ICategory_NewsRepository _reponsitory;

        public Category_NewsController(ICategory_NewsRepository reponsitory)
        {
            _reponsitory = reponsitory;
        }

        [HttpGet("category-news-list")]
        public async Task<IActionResult> GettAllCategory_News()
        {
            try
            {
                var category_news = await _reponsitory.GetAllCategory_News();
                var reponse = new ResponseMessageModel<List<Category_News>>
                {
                    StatusCode = 200,
                    Message = "Hiện thị danh sách loại tin tức thành công!!!",
                    Data = category_news
                };
                return Ok(reponse);
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

        [HttpGet("category-news/{id}")]
        public async Task<IActionResult> GetCategory_NewsById(long id)
        {
            try
            {
                var category_news = await _reponsitory.GetCategory_NewsById(id);
                if(category_news == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy loại tin tức!!!",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<Category_News>
                {
                    StatusCode = 200,
                    Message = "Hiển thị loại tin tức theo id thành công!!!",
                    Data = category_news
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

        [HttpPost("category-news-create")]
        public async Task<IActionResult> AddCategory_News([FromBody] Category_News category_news)
        {
            try
            {
                var category = await _reponsitory.AddCategory_News(category_news);
                var responses = new ResponseMessageModel<long>
                {
                    StatusCode = 201,
                    Message = "Thêm loại tin tức thành công",
                    Data = category
                };
                return CreatedAtAction(nameof(GetCategory_NewsById), new { id = category }, responses);
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

        [HttpPut("category-news-put/{id}")]
        public async Task<IActionResult> UpdateCategory_News(long id, [FromBody] Category_News category_news)
        {
            try
            {
                await _reponsitory.UpdateCategory_News(id, category_news);
                var responses = new ResponseMessageModel<string>
                {
                        StatusCode = 200,
                        Message = "Sửa loại tin tức thành công!!!",
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

        [HttpDelete("category-news-delete/{id}")]
        public async Task<IActionResult> DeleteCategory_News(long id)
        {
            try
            {
                var id_delete = await _reponsitory.DeleteCategory_News(id);
                if (!id_delete)
                {
                    var response = new ResponseMessageModel<string>
                    {
                            StatusCode = 404,
                            Message = "Không tìm thấy loại tin tức!!!",
                            Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Xoá thành công loại tin tức",
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
