using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Businesses
{
    public class IndexModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public IndexModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IList<Business> Business { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Business = await _context.Businesses.ToListAsync();
        }
    }
}
