//Peter Van Horn
//Web Services Final
//05/03/2024

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VanHorn_WebServices_Final.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("ThisCookieAuth");
            return RedirectToPage("/Index");
        }
    }
}
