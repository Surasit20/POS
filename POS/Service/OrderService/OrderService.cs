using Shared.Entity;
using Shared.ModelOData;
using System.Net.Http;
using System.Text.Json;
using System;
using Shared.Common;
using Shared.ModelDTO;
using System.Xml.Linq;

namespace Frontend.Service.OrderService
{

    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        public OrderService(HttpClient http)
        {
            _http = http;
        }


        public async Task<ProductApiResponse> GetProductsAsync(string qry)
        {
            try
            {
                var response = await _http.GetAsync($"{BaseODataCommon.Product}{qry}&count=true");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ProductApiResponse>(responseContent);
                    return data!;
                }
                else
                {
                    return new ProductApiResponse();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ProductApiResponse();
            }

        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                var response = await _http.GetAsync($"{BaseODataCommon.Order}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<OrderApiResponse>(responseContent);
                    return data!.Order;
                }
                else
                {
                    return new List<Order>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Order>();
            }
        }

        public async Task<List<Product>> GetProductByIdAsync(int Id)
        {
            try
            {
                var response = await _http.GetAsync($"{BaseODataCommon.Product}({Id})");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Product>(responseContent);
                    return new List<Product>() { data! };
                }
                else
                {
                    return new List<Product>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }

        }

        public async Task<List<Product>> GetProductByName(string name)
        {
            try
            {
                var response = await _http.GetAsync($"{BaseODataCommon.Product}?$filter=contains(name,'{name}') ");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ProductApiResponse>(responseContent);
                    return data!.Product;
                }
                else
                {
                    return new List<Product>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
        }

        public async Task<Product> AddProduct(ProductDTO productDTO)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseODataCommon.Product}", productDTO);
                //var response = await _http.PostAsJsonAsync($"{BaseODataCommon.Product}?ProductId={productDTO.ProductId}&Name={productDTO.Name}&Description={productDTO.Description}&PurchasePrice={productDTO.PurchasePrice}&SellingPrice={productDTO.SellingPrice}&ImageUrl={productDTO.ImageUrl}&Unit={productDTO.Unit}", "");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Product>(responseContent);
                    return data!;
                }
                else
                {
                    return new Product();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Product();
            }
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseODataCommon.Product}/{Id}");
                if (response.IsSuccessStatusCode || response.StatusCode.Equals(204))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
