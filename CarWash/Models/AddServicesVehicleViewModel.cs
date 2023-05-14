using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.Models
{
    public class AddServicesVehicleViewModel : EditServicesVehicleViewModel
    {
        [Display(Name = "Services")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ServiceId { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
    }
}
