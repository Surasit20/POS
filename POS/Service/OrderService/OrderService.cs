using Shared.Entity;
using Shared.ModelOData;
using System.Net.Http;
using System.Text.Json;
using System;
using Shared.Common;

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
            var response = await _http.GetAsync($"{BaseODataCommon.Product}{qry}");
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
			var response = await _http.GetAsync($"{BaseODataCommon.Order}");
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

        public async Task<List<Product>> GetProductByIdAsync(int Id)
        {
            var response = await _http.GetAsync($"{BaseODataCommon.Product}({Id})");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<Product>(responseContent);
                return new List<Product>() { data};
            }
            else
            {
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetProductByName(string name)
        {
            var response = await _http.GetAsync($"{BaseODataCommon.Product}?$filter=contains(name,'{name}') ");
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
    }
}
