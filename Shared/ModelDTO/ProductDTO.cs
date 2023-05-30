using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ModelDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; } = 0;

        [StringLength(300, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [StringLength(2000, MinimumLength = 2)]
        public string? ImageUrl { get; set; } = String.Empty;

        [StringLength(50, MinimumLength = 1)]
        public string Unit { get; set; }

        public ICollection<OrderItemDTO> OrderItem { get; set; } = new List<OrderItemDTO>();
    }
}
