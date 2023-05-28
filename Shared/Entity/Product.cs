using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Entity
{
    public class Product
    {

        public int ProductId { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [StringLength(2000, MinimumLength = 2)]
        public string? ImageUrl { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Unit { get; set; }

        [JsonIgnore]
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
