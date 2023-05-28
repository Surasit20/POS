using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ModelDTO
{
    public class OrderItemDTO
    {

        public int OrdertItemId { get; set; }

        [Required]
        public int No { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public ProductDTO Product { get; set; }
        public OrderDTO Order { get; set; }
    }
}
