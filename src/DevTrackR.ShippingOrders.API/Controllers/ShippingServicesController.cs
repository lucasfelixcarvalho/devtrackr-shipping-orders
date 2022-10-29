using DevTrackR.ShippingOrders.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-services")]
    public class ShippingServicesController : ControllerBase
    {
        private readonly IShippingServiceService _shippingServiceService;

        public ShippingServicesController(IShippingServiceService shippingServiceService)
        {
            _shippingServiceService = shippingServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var shippingServices = await _shippingServiceService.GetAll();

            return Ok(shippingServices);
        }
    }
}