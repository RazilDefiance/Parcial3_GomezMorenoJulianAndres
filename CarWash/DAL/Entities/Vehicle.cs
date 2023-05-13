﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class Vehicle : Entity
    {
        [Display(Name = "Owner")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Owner { get; set; }

        [Display(Name = "Number Plate")]
        [MaxLength(10)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public int Plate { get; set; }
    }
}
