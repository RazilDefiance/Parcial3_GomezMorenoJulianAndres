using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.Models
{
    public class AddServicesVehicleViewModel : EditServicesVehicleViewModel
    {
        public IEnumerable<SelectListItem> Services { get; set; }
    }
}
