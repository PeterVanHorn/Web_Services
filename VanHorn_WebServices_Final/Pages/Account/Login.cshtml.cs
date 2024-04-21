using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Credential = VanHorn_WebServices_Final.Models.Credential;

namespace VanHorn_WebServices_Final.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // verify
            if (Credential.UserName == "customer" && Credential.Password == "password")
            {
                // create security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "customer"),
                    new Claim("Customer", "True")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            if (Credential.UserName == "service" && Credential.Password == "password")
            {
                // create security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "service"),
                    new Claim("Service", "True")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
