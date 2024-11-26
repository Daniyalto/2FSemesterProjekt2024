using _2FSemesterProjekt2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using _2FSemesterProjekt2024.Services.Interfaces;

public class LoginModel : PageModel
{
    private readonly IAuthService _authService;

    public LoginModel(IAuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public LoginData LoginData { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Check if LoginData is null
        if (LoginData == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid data submission.");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_authService.ValidateCredentials(LoginData.Email, LoginData.Password, out string userType, out int userId))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, LoginData.Email),
                new Claim(ClaimTypes.Role, userType),
                new Claim("UserId", userId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToPage($"/Profile/{userType}Profile");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return Page();
    }
}

