using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JwtOnRazorPages.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPostLogout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToPage("/Index");
        }

    }
}
