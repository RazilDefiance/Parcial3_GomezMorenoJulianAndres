using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class Service : Entity
    {
        [Display(Name = "Service")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public decimal Price { get; set; }

        // Relationship

        [Display(Name = "Vehicles")]
        public ICollection<Vehicle> Vehicles { get; set; }

 
    }
}
