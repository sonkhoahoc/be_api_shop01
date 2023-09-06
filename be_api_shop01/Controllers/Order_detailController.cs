using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_detailController : ControllerBase
    {
        private readonly IOrder_detailRepository _order_detail_repository;

        public Order_detailController(IOrder_detailRepository order_detail_repository)
        {
            _order_detail_repository = order_detail_repository;
        }

        [HttpGet("order-detail-list")]
        public async Task<IActionResult> GetListOrder_detail()
        {
            try
            {
                var o = await _order_detail_repository.GetListOrder_detail();
                return Ok(new ResponseMessageModel<List<Order_detail>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o
                });
            }
            catch(Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "",
                    Data = null
                });
            }
        }

        [HttpGet("order-detai/{id}")]
        public async Task<IActionResult> GetOrder_detailById(long id)
        {
            try
            {
                var o = await _order_detail_repository.GetOrder_detailById(id);

                if(o == null)
                {
                    return Ok(new ResponseMessageModel<Order_detail>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null,
                    });
                }

                return Ok(new ResponseMessageModel<Order_detail>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o,
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "",
                    Data = null
                });
            }
        }

        [HttpPost("order-detai-create")]
        public async Task<IActionResult> CreateOrder_detail([FromBody] Order_detail order_detail)
        {
            try
            {
                var o = await _order_detail_repository.CreateOrder_detail(order_detail);
                return Ok(new ResponseMessageModel<Order_detail>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o,
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "",
                    Data = null
                });
            }
        }

        [HttpPut("order-detai-put/{id}")]
        public async Task<IActionResult> ModifyOrder_detail(long id, [FromBody] Order_detail order_detail)
        {
            try
            {
                var o = await _order_detail_repository.ModifyOrder_detail(id, order_detail);

                if(o == null)
                {
                    return Ok(new ResponseMessageModel<Order_detail>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Order_detail>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o,
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "",
                    Data = null
                });
            }
        }

        [HttpDelete("order-detai-delete/{id}")]
        public async Task<IActionResult> DeleteOrder_deteail(long id)
        {
            try
            {
                var o = await _order_detail_repository.DeleteOrder_detail(id);

                if (!o)
                {
                    return Ok(new ResponseMessageModel<Order_detail>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Order_detail>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseMessageModel<string>
                {
                    StatusCode = 500,
                    Message = "",
                    Data = null
                });
            }
        }
    }
}
