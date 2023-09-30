using Invoicing.DTOObjects.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    [Table("ProductPrices")]

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
