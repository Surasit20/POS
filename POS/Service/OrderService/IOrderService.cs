using Shared.Entity;

namespace Frontend.Service.OrderService
{
    public interface IOrderService
    {
        public Task<List<Product>> GetProductsAsync(string qry) ;
        public Task<List<Product>> GetProductByIdAsync(int Id);
        public Task<List<Product>> GetProductByName(string name);
        public Task<List<Order>> GetOrdersAsync();


	}
}
