using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class VehicleDetail : Entity
    {
        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate { get; set; }

        // Relationship
        [Display(Name = "VechicleID")]
        public Vehicle VechicleReg { get; set; }
    }
}
