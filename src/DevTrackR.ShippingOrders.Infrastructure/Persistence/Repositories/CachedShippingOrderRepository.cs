using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace DevTrackR.ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class CachedShippingOrderRepository : IShippingOrderRepository
    {
        private readonly ShippingOrderRepository proxiedRepository;
        private readonly IMemoryCache _memoryCache;

        public CachedShippingOrderRepository(ShippingOrderRepository decorated, IMemoryCache memoryCache)
        {
            proxiedRepository = decorated;
            _memoryCache = memoryCache;
        }

        public Task AddAsync(ShippingOrder shippingOrder)
        {
            return proxiedRepository.AddAsync(shippingOrder);
        }

        public Task<ShippingOrder> GetByCodeAsync(string code)
        {
            string key = $"shipping_order-{code}";

            return _memoryCache.GetOrCreateAsync(key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                    return proxiedRepository.GetByCodeAsync(code);
                });
        }
    }
}
