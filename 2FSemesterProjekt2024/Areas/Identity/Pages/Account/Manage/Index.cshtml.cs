// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using _2FSemesterProjekt2024.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Required(ErrorMessage ="Phone number is required")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "First name is required")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Address is required")]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Vehicle info is required")]
            [Display(Name = "Vehicle info")]
            public string VehicleInfo { get; set; }

            [Required(ErrorMessage = "License number is required")]
            [Display(Name = "License number")]
            public string LicenseNumber { get; set; }

            [Display(Name = "Rating")]
            public decimal Rating { get; }

            [Display(Name = "Points")]
            public int Points { get; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                VehicleInfo = user.VehicleInfo,
                LicenseNumber = user.LicenseNumber,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }



            bool updateUser = false;

            if (user.FirstName != Input.FirstName)
            {
                user.FirstName = Input.FirstName;
                updateUser = true;
            }

            if (user.LastName != Input.LastName)
            {
                user.LastName = Input.LastName;
                updateUser = true;
            }

            if (user.Address != Input.Address)
            {
                user.Address = Input.Address;
                updateUser = true;
            }

            if (user.VehicleInfo != Input.VehicleInfo)
            {
                user.VehicleInfo = Input.VehicleInfo;
                updateUser = true;
            }

            if (user.LicenseNumber != Input.LicenseNumber)
            {
                    user.LicenseNumber = Input.LicenseNumber;
                    updateUser = true;
            }


            if (updateUser)
            {

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update profile information.";
                    return RedirectToPage();
                }
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
