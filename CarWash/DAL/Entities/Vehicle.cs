using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
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

        // Relationship

        [Display(Name = "ServiceID")]
        public Service ServiceReg { get; set; }

        [Display(Name = "Details")]
        public ICollection<VehicleDetail> VehicleDetails { get; set; }
    }
}
