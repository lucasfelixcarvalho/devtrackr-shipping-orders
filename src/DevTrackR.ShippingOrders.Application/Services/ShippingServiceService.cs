using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingServiceService : IShippingServiceService
    {
        public Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = new List<ShippingService>()
            {
                new ShippingService("Selo", 0, 1.2m),
                new ShippingService("Envio Simples", 2.2m, 5.0m),
                new ShippingService("Envio Com Tracking", 5.0m, 5.5m)
            };

            return Task.FromResult(shippingServices.Select(s => ShippingServiceViewModel.FromEntity(s)).ToList());
        }
    }
}
