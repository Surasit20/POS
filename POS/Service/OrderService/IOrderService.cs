using Shared.Entity;

namespace Frontend.Service.OrderService
{
    public interface IOrderService
    {
        public Task<List<Product>> GetProductsAsync(string qry) ;
		public Task<List<Order>> GetOrdersAsync();
	}
}
