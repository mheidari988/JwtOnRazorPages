using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JwtOnRazorPages.Pages
{
    public class LoginModel(IConfiguration configuration, ITokenService tokenService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Username == "admin" && Password == "admin")
            {
                var token = tokenService.GenerateJwtToken(Username, configuration);
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Path = "/",
                    SameSite = SameSiteMode.Lax
                });
                return RedirectToPage("/Secret");
            }
            return Page();
        }
    }
}