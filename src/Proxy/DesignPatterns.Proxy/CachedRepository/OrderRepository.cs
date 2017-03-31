using System;

namespace DesignPatterns.Proxy.CachedRepository
{
	public class OrderRepository : Repository<Order>
    {
        public override Order GetById(int id)
        {
            return new Order
            {
                Id = id,
                CustomerId = 1,
                OrderDate = DateTime.Now
            };
        }
    }
}
