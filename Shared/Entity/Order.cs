using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity
{
    public class Order : Base
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int PurchaserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal Vat { get; set; }

        public string? Note { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int Status { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
        public Supplier Supplier { get; set; }
        public Purchaser Purchaser { get; set; }



    }

    public enum Status
    {
        Pending,
        Approved,
        Reject
    }
}

