using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _reponsitory;

        public NewsController(INewsRepository reponsitory)
        {
            _reponsitory = reponsitory;
        }

        [HttpGet("news-list")]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var news = await _reponsitory.GetAllNews();
                var response = new ResponseMessageModel<List<News>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách tin tức thành công!!!",
                    Data = news
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

        [HttpGet("news/category/{category_id}")]
        public async Task<IActionResult> GetListNewsByCategory_Id(long category_id)
        {
            try
            {
                var news = await _reponsitory.GetListNewsByCategory_Id(category_id);
                var response = new ResponseMessageModel<List<News>>
                {
                    StatusCode = 200,
                    Message = "Hiển thị danh sách tin tức theo loại tin tức thành công!!!",
                    Data = news
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

        [HttpGet("news/{id}")]
        public async Task<IActionResult> GetNewsById(long id)
        {
            try
            {
                var news = await _reponsitory.GetNewsById(id);
                if(news == null)
                {
                    var response = new ResponseMessageModel<string>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy tin tức",
                        Data = null
                    };
                    return NotFound(response);
                }

                var responses = new ResponseMessageModel<News>
                {
                    StatusCode = 200,
                    Message = "Hiển thị tin thức theo id thành công!!!",
                    Data = news
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

        [HttpGet("news-count")]
        public async Task<ActionResult> GetTotalNews()
        {
            try
            {
                var n = await _reponsitory.GetTotalNews();

                return Ok(new ResponseMessageModel<long>
                {
                    StatusCode = 200,
                    Message = "Thành công!!!",
                    Data = n
                });
            }
            catch(Exception)
            {
                return Ok(new ResponseMessageModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý!!!",
                    Data = null
                });
            }
        }

        [HttpPost("news-create")]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            try
            {
                var add_news = await _reponsitory.AddNews(news);
                var response = new ResponseMessageModel<long>
                {
                    StatusCode = 200,
                    Message = "Thêm tin tức thành công!!!",
                    Data = add_news
                };
                return CreatedAtAction(nameof(GetNewsById), new { id = add_news }, response);   
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

        [HttpPut("news-put/{id}")]
        public async Task<IActionResult> UpdateNews(long id,[FromBody] News news)
        {
            try
            {
                await _reponsitory.UpdateNews(id , news);
                var response = new ResponseMessageModel<string>
                {
                    StatusCode = 200,
                    Message = "Sửa tin tức thành công!!!",
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

        [HttpDelete("news-delete/{id}")]
        public async Task<IActionResult> DeleteNews(long id)
        {
            try
            {
                var is_delete = await _reponsitory.DeleteNews(id);

                if (!is_delete)
                {
                    var response = new ResponseMessageModel<News>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy tin tức!!!",
                        Data = null
                    };
                    return NotFound(response);
                };

                var responses = new ResponseMessageModel<News>
                {
                    StatusCode = 200,
                    Message = "Xoá tin tức thành công!!!",
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
