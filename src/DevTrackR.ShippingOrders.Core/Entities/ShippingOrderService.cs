namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingOrderService : EntityBase
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public ShippingOrderService(string title, decimal price) : base()
        {
            Title = title;
            Price = price;
        }
    }
}
