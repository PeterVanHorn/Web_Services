using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Days
{
    public class DeleteModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public DeleteModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Day Day { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days.FirstOrDefaultAsync(m => m.Id == id);

            if (day == null)
            {
                return NotFound();
            }
            else
            {
                Day = day;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days.FindAsync(id);
            if (day != null)
            {
                Day = day;
                _context.Days.Remove(Day);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
