using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.ValueObjects;
using System.Text.Json;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        public Task<string> Add(AddShippingOrderInputModel model)
        {
            var shippingOrder = model.ToEntity();
            var shippingServices = model.Services.Select(s => s.ToEntity()).ToList();
            shippingOrder.SetupServices(shippingServices);

            Console.WriteLine(JsonSerializer.Serialize(shippingOrder, new JsonSerializerOptions { WriteIndented = true }));
            
            return Task.FromResult(shippingOrder.TrackingCode);
        }

        public Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = new ShippingOrder("Pedido 1", 5.2m, new DeliveryAddress("Rua A", "1123", "12345-678", "São Paulo", "SP", "Brasil"));

            return Task.FromResult(ShippingOrderViewModel.FromEntity(shippingOrder));
        }
    }
}
