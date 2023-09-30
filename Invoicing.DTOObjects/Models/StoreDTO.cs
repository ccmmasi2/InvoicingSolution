using Invoicing.DTOObjects.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    [Table("Stores")]
    public class StoreDTO : BaseDTO
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(100, ErrorMessage = "The length of the field should be less than 100")]
        public string Address { get; set; }
    }
}
