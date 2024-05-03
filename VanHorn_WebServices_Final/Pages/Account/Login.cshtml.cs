//Peter Van Horn
//Web Services Final
//05/03/2024

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using VanHorn_WebServices_Final.Models;
using Credential = VanHorn_WebServices_Final.Models.Credential;

namespace VanHorn_WebServices_Final.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public LoginModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Credential Credential { get; set; }
        public IList<Customer> Customers { get; set; } = default!;
        public IList<Business> Businesses { get; set; } = default!;
        public void OnGet()
        {
            _context.Database.EnsureCreated();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid) return Page();

            Customers = await _context.Customers.ToListAsync();
            Businesses = await _context.Businesses.ToListAsync();

            foreach(var customer in Customers)
            {
                Credential cred = await _context.Credentials
                    .FirstOrDefaultAsync(d => d.CustomerId == customer.CId);
                if (Credential.UserName == cred.UserName && Credential.Password == cred.Password)
                {
                    // create security context
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, customer.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, customer.CId.ToString()),
                    new Claim("Customer", "True")
                };
                    var identity = new ClaimsIdentity(claims, "ThisCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("ThisCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Index");
                }
            }

            //if (Credential.UserName == "customer" && Credential.Password == "password")
            //{
            //    // create security context
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, "customer"),
            //        new Claim("Customer", "True")
            //    };
            //    var identity = new ClaimsIdentity(claims, "ThisCookieAuth");
            //    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            //    await HttpContext.SignInAsync("ThisCookieAuth", claimsPrincipal);

            //    return RedirectToPage("/Index");
            //}

            foreach (var business in Businesses)
            {
                Credential cred = await _context.Credentials
                    .FirstOrDefaultAsync(d => d.BusinessId == business.SPId);
                if (Credential.UserName == cred.UserName && Credential.Password == cred.Password)
                {
                    // create security context
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, business.BusinessName),
                    new Claim(ClaimTypes.NameIdentifier, business.SPId.ToString()),
                    new Claim("Service", "True")
                };
                    var identity = new ClaimsIdentity(claims, "ThisCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("ThisCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
