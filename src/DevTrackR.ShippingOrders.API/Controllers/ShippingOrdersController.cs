using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _shippingOrderService;

        public ShippingOrdersController(IShippingOrderService shippingOrderService)
        {
            _shippingOrderService = shippingOrderService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code) {
            var shippingOrder = await _shippingOrderService.GetByCode(code);
            
            if (shippingOrder is null)
            {
                return NotFound();
            }

            return Ok(shippingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model) {
            var code = await _shippingOrderService.Add(model);

            return CreatedAtAction(
                nameof(GetByCode),
                new { code },
                model
            );
        }
    }
}