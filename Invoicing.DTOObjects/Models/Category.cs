﻿using System.ComponentModel.DataAnnotations;

namespace Invoicing.DTOObjects.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "The length of the field should be less than 50")] 
        public string Name { get; set; }
    }
}
