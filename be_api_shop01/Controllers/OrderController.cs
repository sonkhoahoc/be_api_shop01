using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("order-list")]
        public async Task<IActionResult> GetistOrder()
        {
            try
            {
                var order = await _orderRepository.GetOrderList();
                return Ok(new ResponseMessageModel<List<Order>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = order
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

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderById(long id)
        {
            try
            {
                var order = await _orderRepository.GetOrderById(id);

                if(order == null)
                {
                    return Ok(new ResponseMessageModel<Order>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Order>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = order
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

        [HttpPost("order-create")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                var o = await _orderRepository.CreateOrder(order);
                return Ok(new ResponseMessageModel<Order>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o
                });
;            }
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

        [HttpPut("order-put/{id}")]
        public async Task<IActionResult> ModifyOrder(long id, [FromBody] Order order)
        {
            try
            {
                var o = await _orderRepository.UpdateOrder(id, order);

                if(o == null)
                {
                    return Ok(new ResponseMessageModel<Order>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Order>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = o
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

        [HttpDelete("order-delete/{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            try
            {
                var oder = await _orderRepository.DeleteOrder(id);

                if (!oder)
                {
                    return Ok(new ResponseMessageModel<Order>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Order>
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
