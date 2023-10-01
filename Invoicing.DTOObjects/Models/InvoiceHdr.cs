using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    public class InvoiceHdr
    {
        [Key]
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
