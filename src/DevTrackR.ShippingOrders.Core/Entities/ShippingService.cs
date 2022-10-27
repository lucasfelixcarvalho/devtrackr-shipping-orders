namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingService : EntityBase
    {
        public string Title { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal FixedPrice { get; set; }

        public ShippingService(string title, decimal pricePerKg, decimal fixedPrice) : base()
        {
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }
    }
}