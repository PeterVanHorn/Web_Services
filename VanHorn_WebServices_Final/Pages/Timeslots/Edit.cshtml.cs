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
    public class EditModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public EditModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Timeslot Timeslot { get; set; } = default!;
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeslot =  await _context.Timeslots.FirstOrDefaultAsync(m => m.TId == id);
            if (timeslot == null)
            {
                return NotFound();
            }
            Timeslot = timeslot;
           ViewData["ServiceProviderId"] = new SelectList(_context.ServiceProviders, "SPId", "SPId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.FirstName == User.Identity.Name);
            Timeslot.CustomerId = Customer.CId;
            Timeslot.IsTaken = true;
            _context.Attach(Timeslot).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeslotExists(Timeslot.TId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Customers/Details", new {id = Customer.CId});
        }

        private bool TimeslotExists(int id)
        {
            return _context.Timeslots.Any(e => e.TId == id);
        }
    }
}
