using Invoicing.DTOObjects.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    [Table("InvoicesHdr")]

    public class InvoiceHdrDTO : BaseDTO
    {
        [Key]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDClient { get; set; }

        public ClientDTO Client { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDStore { get; set; }

        public StoreDTO Store { get; set; }
    }
}
