using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjectsNet6.Models
{
    public class Store
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")]
        public string City { get; set; }

        [MaxLength(100, ErrorMessage = "The length of the field should be less than 100")]
        public string Address { get; set; }
    }
}
