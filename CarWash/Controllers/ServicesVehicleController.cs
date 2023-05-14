using CarWash.DAL;
using CarWash.DAL.Entities;
using CarWash.Helpers;
using CarWash.Models;
using CarWash.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Data;

namespace CarWash.Controllers
{
    [Authorize(Roles = "Client")]
    public class ServicesVehicleController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IDropDownListHelper _dropDownListHelper;


        public ServicesVehicleController(DataBaseContext context, IUserHelper userHelper, IDropDownListHelper dropDownListHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _dropDownListHelper = dropDownListHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            AddServicesVehicleViewModel addServicesVehicleViewModel = new()
            {
                Services = await _dropDownListHelper.GetDDLServicesAsync(),
            };

            return View(addServicesVehicleViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateService(AddServicesVehicleViewModel addServicesVehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var serreg = await _context.Services
                    //    .Where(s => s.Name.Contains(addServicesVehicleViewModel.Services))
                    //    .FirstOrDefaultAsync();

                    Vehicle vehicle = new()
                    {
                        Id = Guid.NewGuid(),
                        Owner = addServicesVehicleViewModel.Owner,
                        Plate = addServicesVehicleViewModel.Plate,
                        CreateDate = DateTime.Now,
                    };

                

                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There is already a product with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            addServicesVehicleViewModel.Services = await _dropDownListHelper.GetDDLServicesAsync();
            return View(addServicesVehicleViewModel);
        }


    }

}
