using Shared.Entity;
using System.ComponentModel.DataAnnotations;

namespace Shared.ModelDTO
{
    public class PurchaserDTO
    {

        public int PurchaserId { get; set; }
        [Required(ErrorMessage = "Please enter {0}.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter {0}.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter {0}.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter {0}.")]
        public string? TaxID { get; set; }
        public string? OfficeName { get; set; }
        public ICollection<Order>? Order { get; set; }
    }
}
