using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_api_shop01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListCart()
        {
            try
            {
                var cartList = await _cartRepository.GetListCart();
                return Ok(new ResponseMessageModel<List<Cart>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = cartList
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(long id)
        {
            try
            {
                var cart = await _cartRepository.GetCartById(id);
                if(cart == null)
                {
                    return Ok(new ResponseMessageModel<Cart>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Cart>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = cart
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

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] Cart cart)
        {
            try
            {
                var createCart = await _cartRepository.CreateCart(cart);
                return Ok(new ResponseMessageModel<Cart>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = createCart
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(long id, [FromBody] Cart cart)
        {
            try
            {
                var updateCart = await _cartRepository.UpdateCart(id, cart);

                if(updateCart == null)
                {
                    return Ok(new ResponseMessageModel<Cart>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Cart>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = updateCart
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            try
            {
                var deleteCart = await _cartRepository.DeleteCart(id);
                if (!deleteCart)
                {
                    return Ok(new ResponseMessageModel<Cart>
                    {
                        StatusCode = 404,
                        Message = "",
                        Data = null
                    });
                }

                return Ok(new ResponseMessageModel<Cart>
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
