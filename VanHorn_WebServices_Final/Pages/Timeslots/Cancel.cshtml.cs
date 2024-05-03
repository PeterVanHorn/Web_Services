//Peter Van Horn
//Web Services Final
//05/03/2024
//Custom Cancel RazorPage sort of a combo of the default Delete and Edit pages

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Timeslots
{
    public class CancelModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public CancelModel(VanHorn_WebServices_Final.Models.DomainContext context)
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

            var timeslot = await _context.Timeslots.FirstOrDefaultAsync(m => m.TId == id);
            if (timeslot == null)
            {
                return NotFound();
            }
            Timeslot = timeslot;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CId == Timeslot.CustomerId);
            Timeslot.CustomerId = null;
            Timeslot.Customer = null;
            Timeslot.ServiceProviderId = null;
            Timeslot.ServiceProvider = null;
            Timeslot.IsTaken = false;
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
            return RedirectToPage("/Customers/Details", new { id = Customer.CId });
        }

        private bool TimeslotExists(int id)
        {
            return _context.Timeslots.Any(e => e.TId == id);
        }
    }
}
