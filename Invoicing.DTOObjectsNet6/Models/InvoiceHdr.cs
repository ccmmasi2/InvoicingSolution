using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjectsNet6.Models
{
    public class InvoiceHdr
    {
        [Key]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDClient { get; set; }

        [ForeignKey("IDClient")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDStore { get; set; }

        [ForeignKey("IDStore")]
        public Store Store { get; set; }
    }
}
