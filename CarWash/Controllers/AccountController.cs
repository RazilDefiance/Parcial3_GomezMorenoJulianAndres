using CarWash.DAL;
using CarWash.DAL.Entities;
using CarWash.Enum;
using CarWash.Helpers;
using CarWash.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataBaseContext _context;
        //private readonly IAzureBlobHelper _azureBlobHelper;

        public AccountController(IUserHelper userHelper, DataBaseContext context /*IAzureBlobHelper azureBlobHelper*/)
        {
            _userHelper = userHelper;
            _context = context;
            //_azureBlobHelper = azureBlobHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(loginViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Wrong email or password.");
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Unauthorized()
        {
            return View();
        }

        public async Task<IActionResult> EditUser()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);

            if (user == null) return NotFound();

            EditUserViewModel editUserViewModel = new()
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ImageId = user.ImageId,
                Id = Guid.Parse(user.Id),
                Document = user.Document
            };

            return View(editUserViewModel);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Guid imageId = editUserViewModel.ImageId;

        //        if (editUserViewModel.ImageFile != null) imageId = await _azureBlobHelper.UploadAzureBlobAsync(editUserViewModel.ImageFile, "users");

        //        User user = await _userHelper.GetUserAsync(User.Identity.Name);

        //        user.FirstName = editUserViewModel.FirstName;
        //        user.LastName = editUserViewModel.LastName;
        //        user.Address = editUserViewModel.Address;
        //        user.PhoneNumber = editUserViewModel.PhoneNumber;
        //        user.ImageId = imageId;
        //        user.Document = editUserViewModel.Document;

        //        IdentityResult result = await _userHelper.UpdateUserAsync(user);
        //        if (result.Succeeded) return RedirectToAction("Index", "Home");
        //        else ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
        //    }

        //    //await FillDropDownListLocation(editUserViewModel);

        //    return View(editUserViewModel);
        //}

        //private async Task FillDropDownListLocation(EditUserViewModel addUserViewModel)
        //{
        //    addUserViewModel.Services = await _ddlHelper.GetDDLServicesAsync();
        //}

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                if (changePasswordViewModel.OldPassword == changePasswordViewModel.NewPassword)
                {
                    ModelState.AddModelError(string.Empty, "You must enter a different password.");
                    return View(changePasswordViewModel);
                }

                User user = await _userHelper.GetUserAsync(User.Identity.Name);

                if (user != null)
                {
                    IdentityResult result = await _userHelper.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
                    if (result.Succeeded) return RedirectToAction("EditUser");
                    else ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                }
                else ModelState.AddModelError(string.Empty, "User not found.");
            }

            return View(changePasswordViewModel);
        }
    }
}
