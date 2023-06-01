using Shared.Entity;
using Shared.ModelDTO;
using Shared.ModelOData;

namespace Frontend.Service.OrderService
{
    public interface IOrderService
    {
        public Task<ProductApiResponse> GetProductsAsync(string qry, string nextPage);
        public Task<bool> PutProductAsync(Product product);
        public Task<List<Product>> GetProductByIdAsync(int Id);
        public Task<List<Product>> GetProductByName(string name);
        public Task<List<Order>> GetOrdersAsync();
        public Task<Product> AddProduct(ProductDTO productDTO);
        public Task<bool> DeleteProduct(int Id);
        public Task<ProductApiResponse> ConvertJsonToObj(HttpResponseMessage response);
    }
}
