//Peter Van Horn
//Web Services Final
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Days
{
    public class EditModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public EditModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Day Day { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day =  await _context.Days.FirstOrDefaultAsync(m => m.Id == id);
            if (day == null)
            {
                return NotFound();
            }
            Day = day;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(Day.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DayExists(string id)
        {
            return _context.Days.Any(e => e.Id == id);
        }
    }
}
