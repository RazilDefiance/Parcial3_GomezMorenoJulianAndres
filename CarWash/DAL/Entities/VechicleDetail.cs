using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class VechicleDetail : Entity
    {
        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate{ get; set; }
    }

    //public Vehicle Vehicles { get; set; }
}
