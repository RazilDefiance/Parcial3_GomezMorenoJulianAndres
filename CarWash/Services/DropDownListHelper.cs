using CarWash.DAL;
using CarWash.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Services
{
    public class DropDownListHelper : IDropDownListHelper
    {
        public readonly DataBaseContext _context;

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
        {
            List<SelectListItem> listServices = await _context.Services
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString(),
                })
                .OrderBy(s => s.Text)
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Select the service...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listServices;
        }
    }
}
