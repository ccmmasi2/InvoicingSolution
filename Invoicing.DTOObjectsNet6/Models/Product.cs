using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjectsNet6.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Code { get; set; }

        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Name { get; set; }

        public int? IDCategory { get; set; }

        [ForeignKey("IDCategory")]
        public Category Category { get; set; }
    }
}
