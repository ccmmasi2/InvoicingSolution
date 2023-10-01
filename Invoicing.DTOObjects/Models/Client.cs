using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjects.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 100")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(100, ErrorMessage = "The length of the field should be less than 100")]
        public string Email { get; set; }
    }
}
