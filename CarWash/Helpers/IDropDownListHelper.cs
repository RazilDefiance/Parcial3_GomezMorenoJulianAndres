using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.Helpers
{
    public interface IDropDownListHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();

    }
}
