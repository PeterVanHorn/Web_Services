//Peter Van Horn
//Web Services Final
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CId == id);
            var timeslots = await _context.Timeslots
                .Where(t => t.CustomerId == customer.CId)
                .ToListAsync();

            //foreach (var timeslot in timeslots)
            //{
            //    if (timeslot != null && timeslot.CustomerId != customer.CId)
            //    {
            //        timeslots.Remove(timeslot);
            //    }
            //}
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
                Customer.Timeslots = timeslots;
            }
            return Page();
        }
    }
}
