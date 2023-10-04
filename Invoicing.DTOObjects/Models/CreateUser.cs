using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjects.Models
{
    public class CreateUser
    {
        [Key]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string DocumentNumber { get; set; }
        public int DocumentTypeId { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string PhoneNumber { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 100")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string Password { get; set; } = string.Empty;

        public DateTime? FirstLoginDate { get; set; } 
    }
}
