using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrackR.ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingOrderRepository : IShippingOrderRepository
    {
        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrder>("shipping-orders");
        }

        public async Task AddAsync(ShippingOrder shippingOrder)
        {
            await _collection.InsertOneAsync(shippingOrder);
        }

        public async Task<ShippingOrder> GetByCodeAsync(string code)
        {
            return await _collection.Find(so => so.TrackingCode == code).SingleOrDefaultAsync();
        }
    }
}
