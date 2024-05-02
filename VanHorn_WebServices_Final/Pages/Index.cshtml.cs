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

        public void OnGet()
        {
            _context.Database.EnsureCreated();
        }
    }
}
