using DevTrackR.ShippingOrders.Core.Entities;
using MongoDB.Driver;

namespace DevTrackR.ShippingOrders.Infrastructure.Persistence
{
    public class DbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;

        private List<ShippingService> _shippingServices = new()
        {
            new ShippingService("Envio municipal", 1m, 5m),
            new ShippingService("Envio estadual", 5m, 10m),
            new ShippingService("Envio federal", 15m, 20m)
        };

        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public void Populate()
        {
            if (_collection.CountDocuments(c => true) > 0)
                return;

            _collection.InsertMany(_shippingServices);
        }
    }
}
