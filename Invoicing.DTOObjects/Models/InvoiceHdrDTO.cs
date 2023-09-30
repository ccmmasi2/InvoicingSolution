using Invoicing.DTOObjects.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjects.Models
{
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
