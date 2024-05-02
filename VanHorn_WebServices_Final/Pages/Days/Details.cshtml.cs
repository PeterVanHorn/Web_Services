using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Differencing;
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
            Timeslots = await _context.Timeslots.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days.FirstOrDefaultAsync(m => m.Id == id);
            if (day == null)
            {
                TimeSpan start1 = new TimeSpan(8, 00, 0);
                TimeSpan start2 = new TimeSpan(10, 00, 0);
                TimeSpan start3 = new TimeSpan(1, 00, 0);
                TimeSpan start4 = new TimeSpan(3, 00, 0);
                TimeSpan duration = new TimeSpan(2, 00, 0);
                Timeslot t1 = new Timeslot
                {
                    DayId = id,
                    StartTime = start1,
                    Duration = duration,
                    IsTaken = false
                };
                Timeslot t2 = new Timeslot
                {
                    DayId = id,
                    StartTime = start2,
                    Duration = duration,
                    IsTaken = false
                };
                Timeslot t3 = new Timeslot
                {
                    DayId = id,
                    StartTime = start3,
                    Duration = duration,
                    IsTaken = false
                };
                Timeslot t4 = new Timeslot
                {
                    DayId = id,
                    StartTime = start4,
                    Duration = duration,
                    IsTaken = false
                };
                List<Timeslot> Slist = new List<Timeslot> { t1, t2, t3, t4};
                Day newDay = new Day() { Id = id, Timeslots = Slist };
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