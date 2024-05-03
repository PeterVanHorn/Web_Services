using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Timeslots
{
    public class CreateModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Timeslot Timeslot { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            TimeSpan time1 = new TimeSpan(8, 00, 0);
            TimeSpan time2 = new TimeSpan(10, 00, 0);
            TimeSpan time3 = new TimeSpan(1, 00, 0);
            TimeSpan time4 = new TimeSpan(3, 00, 0);
            List<TimeSpan> Startlist = new List<TimeSpan> { time1, time2, time3, time4 };
            ViewData["StartTimes"] = new SelectList(Startlist);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CId", "LastName");
            ViewData["ServiceProviderId"] = new SelectList(_context.Businesses, "SPId", "BusinessName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            TimeSpan duration = new TimeSpan(2, 00, 0);
            Timeslot timeslot = new Timeslot
            {
                DayId = id,
                CustomerId = Timeslot.CustomerId,
                ServiceProviderId = Timeslot.ServiceProviderId,
                StartTime = Timeslot.StartTime,
                Duration = duration
            };
            
            _context.Timeslots.Add(timeslot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}