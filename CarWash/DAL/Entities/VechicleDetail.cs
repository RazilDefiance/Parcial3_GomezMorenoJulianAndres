using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class VechicleDetail : Vehicle
    {

        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate{ get; set; }
    }
}
