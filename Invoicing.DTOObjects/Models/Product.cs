﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoicing.DTOObjects.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Code { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int IDCategory { get; set; }

        [ForeignKey("IDCategory")]
        public Category Category { get; set; }
    }
}