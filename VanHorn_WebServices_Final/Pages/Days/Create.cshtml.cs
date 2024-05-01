using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Days
{
    public class CreateModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Day Day { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Days.Add(Day);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
