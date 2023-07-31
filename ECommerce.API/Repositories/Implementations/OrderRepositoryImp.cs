using ECommerce.API.Entities;

namespace ECommerce.API.Repositories.Implementations
{
    public class OrderRepositoryImp : IOrderRepository
    {
        public Task<bool> AddOrder(OrderHeader header)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid)
        {
            throw new NotImplementedException();
        }
    }
}
