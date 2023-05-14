using CarWash.DAL.Entities;
using CarWash.Enum;
using CarWash.Helpers;
using CarWash.Services;
using Microsoft.EntityFrameworkCore;

namespace CarWash.DAL
{
    public class Seeder
    {
        private readonly DataBaseContext _context;
        private readonly IUserHelper _userHelper;

        public Seeder(DataBaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("First Name Admin", "Last Name Role", "admin@yopmail.com", "Phone 3002323232", "Add Street Fighter", "Doc 102030", UserType.Admin);
            await PopulateUserAsync("First Name Client", "Last Name Role", "client@yopmail.com", "Phone 3502323232", "Address Street Fighter 2", "Doc 405060", UserType.Client);

            await _context.SaveChangesAsync();
        }

        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service { Name = "Lavada Simple", Price=25000, CreateDate = DateTime.Now });
                _context.Services.Add(new Service { Name = "Lavada + Polishada", Price = 50000, CreateDate = DateTime.Now });
                _context.Services.Add(new Service { Name = "Lavada + Aspirada de Cojinería", Price = 30000, CreateDate = DateTime.Now });
                _context.Services.Add(new Service { Name = "Lavada Full", Price = 65000, CreateDate = DateTime.Now });
                _context.Services.Add(new Service { Name = "Lavada en seco del Motor", Price = 80000, CreateDate = DateTime.Now });
                _context.Services.Add(new Service { Name = "Lavada Chasis", Price = 90000, CreateDate = DateTime.Now });
            }
        }

        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.Client.ToString());
        }

        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string address, string document, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    CreatedDate = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }
    }
}
