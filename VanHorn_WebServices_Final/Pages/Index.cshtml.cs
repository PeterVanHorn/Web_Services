using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DomainContext _context;

        public IndexModel(DomainContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public Business Business { get; set; }

        public void OnGet()
        {
            _context.Database.EnsureCreated();
            var customer = _context.Customers.Where(c => c.FirstName == User.Identity.Name).FirstOrDefault();
            var business = _context.Businesses.Where(b => b.BusinessName == User.Identity.Name).FirstOrDefault();
            Customer = customer;
            Business = business;
            
        }
    }
}
