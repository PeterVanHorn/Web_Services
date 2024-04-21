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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day =  await _context.Days.FirstOrDefaultAsync(m => m.DId == id);
            if (day == null)
            {
                return NotFound();
            }
            Day = day;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(Day.DId))
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

        private bool DayExists(int id)
        {
            return _context.Days.Any(e => e.DId == id);
        }
    }
}
