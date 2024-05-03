//Peter Van Horn
//Web Services Final
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Customers
{
    [Authorize(Policy = "ServiceOnly")]
    public class IndexModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public IndexModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Credential).ToListAsync();
        }
    }
}
