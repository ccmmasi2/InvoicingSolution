using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    public class InvoiceDtl
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string InvoiceNum { get; set; }

        [ForeignKey("InvoiceNum")]
        public InvoiceHdr InvoiceHdr { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int Order { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDProduct { get; set; }

        [ForeignKey("IDProduct")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Required field")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int QTY { get; set; }
    }
}
