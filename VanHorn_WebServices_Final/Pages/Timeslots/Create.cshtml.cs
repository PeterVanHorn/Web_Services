using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CId", "CId");
        ViewData["ServiceProviderId"] = new SelectList(_context.ServiceProviders, "SPId", "SPId");
            return Page();
        }

        [BindProperty]
        public Timeslot Timeslot { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Timeslots.Add(Timeslot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
