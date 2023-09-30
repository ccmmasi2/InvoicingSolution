using Invoicing.AccessData.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.AccessData.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Name { get; set; }
    }
}
