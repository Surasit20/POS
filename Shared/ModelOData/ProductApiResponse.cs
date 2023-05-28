using Shared.Entity;
using System.Text.Json.Serialization;

namespace Shared.ModelOData
{
	public class ProductApiResponse
	{
		[JsonPropertyName("@odata.count")]
		public int Count { get; set; }

		[JsonPropertyName("value")]
		public List<Product> Product { get; set; }
	}
}
