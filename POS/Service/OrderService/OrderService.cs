using Shared.Entity;
using Shared.ModelOData;
using System.Net.Http;
using System.Text.Json;
using System;

namespace Frontend.Service.OrderService
{
   
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Product>> GetProductsAsync(string qry)
        {
            var response = await _http.GetAsync($"ProductOData{qry}");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ProductApiResponse>(responseContent);
                return data.Product;
            }
            else
            {
                return new List<Product>();
            }
        }

		public async Task<List<Order>> GetOrdersAsync()
		{
			var response = await _http.GetAsync($"OrderOData");
			if (response.IsSuccessStatusCode)
			{
				var responseContent = await response.Content.ReadAsStringAsync();
				var data = JsonSerializer.Deserialize<OrderApiResponse>(responseContent);
				return data.Order;
			}
			else
			{
				return new List<Order>();
			}
		}
	}
}
