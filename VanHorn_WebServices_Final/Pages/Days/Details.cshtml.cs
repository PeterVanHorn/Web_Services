using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Days
{
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Day Day { get; set; } = default!;
        public IList<Timeslot> Timeslots { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            _context.Database.EnsureCreated();
            Timeslots = await _context.Timeslots.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days.FirstOrDefaultAsync(m => m.Id == id);
            if (day == null)
            {
                Day newDay = new Day() { Id = id, Timeslots = [] };
                _context.Days.Add(newDay);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Days/Details", new { id = id });
            }
            else
            {
                Day = day;
            }
            return Page();
        }
    }
}
