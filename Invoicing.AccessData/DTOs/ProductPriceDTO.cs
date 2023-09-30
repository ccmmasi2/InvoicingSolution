using Invoicing.AccessData.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.AccessData.DTOs
{
    public class ProductPriceDTO : BaseDTO
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDProduct { get; set; }

        public ProductDTO Product { get; set; }

        [Required(ErrorMessage = "Required field")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime EndDate { get; set; }
    }
}
