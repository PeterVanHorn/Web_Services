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
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CId", "LastName");
            ViewData["ServiceProviderId"] = new SelectList(_context.ServiceProviders, "SPId", "BusinessName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            Timeslot timeslot = new Timeslot
            {
                DayId = id,
                CustomerId = Timeslot.CustomerId,
                ServiceProviderId = Timeslot.ServiceProviderId,
            };
            
            _context.Timeslots.Add(timeslot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}