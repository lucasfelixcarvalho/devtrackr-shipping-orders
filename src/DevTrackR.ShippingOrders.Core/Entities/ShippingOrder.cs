using DevTrackR.ShippingOrders.Core.Enums;
using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingOrder : EntityBase
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public DateTime PostedAt { get; set; }
        public decimal WeightInKg { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public ShippingOrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ShippingOrderService> Services { get; set; }

        public ShippingOrder(string description, decimal weightInKg, DeliveryAddress deliveryAddress)
        {
            TrackingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.Now;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;
            Status = ShippingOrderStatus.Started;
            Services = new();
        }

        public void SetupServices(List<ShippingService> services)
        {
            foreach(var service in services)
            {
                decimal servicePrice = service.FixedPrice + service.PricePerKg * WeightInKg;

                Services.Add(new ShippingOrderService(service.Title, servicePrice));
                TotalPrice += servicePrice;
            }
        }

        private static string GenerateTrackingCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            var code = new char[10];
            var random = new Random();

            for (var i = 0; i < 5; i++) {
                code[i] = chars[random.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++) {
                code[i] = numbers[random.Next(numbers.Length)];
            }

            return new String(code);
        }
    }
}