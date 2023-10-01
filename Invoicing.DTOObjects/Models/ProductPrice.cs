using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    public class ProductPrice
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDProduct { get; set; }

        [ForeignKey("IDProduct")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Required field")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime EndDate { get; set; }
    }
}
