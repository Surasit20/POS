using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity
{
    public class OrderItem
    {
        [Key]
        public int OrdertItemId { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }

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

        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
