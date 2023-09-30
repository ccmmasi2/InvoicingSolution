using Invoicing.DTOObjects.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjects.Models
{
    public class InvoiceDtlDTO : BaseDTO
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string InvoiceNum { get; set; }

        public InvoiceHdrDTO InvoiceHdr { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int Order { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string IDProduct { get; set; }

        public ProductDTO Product { get; set; }

        [Required(ErrorMessage = "Required field")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int QTY { get; set; }
    }
}
