using Shared.Entity;
using System.Text.Json.Serialization;

namespace Shared.ModelOData
{
	public class OrderApiResponse
	{
		[JsonPropertyName("@odata.count")]
		public int Count { get; set; }

		[JsonPropertyName("value")]
		public List<Order> Order { get; set; }
	}
}
