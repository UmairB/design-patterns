using Microsoft.Extensions.Caching.Memory;

namespace DesignPatterns.Proxy.CachedRepository
{
	public class CachedOrderRepository : OrderRepository
    {
        private readonly IMemoryCache cache;

        public CachedOrderRepository()
        {
            var options = new MemoryCacheOptions();
            var cache = new MemoryCache(options);

            this.cache = cache;
        }

        public override Order GetById(int id)
        {
            var key = $"OrderEntity-{id}";
            var entity = this.cache.GetOrCreate(key, c => base.GetById(id));

            return entity;
        }
    }
}
