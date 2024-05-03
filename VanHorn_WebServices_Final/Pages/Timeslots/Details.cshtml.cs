//Peter Van Horn
//Web Services Final
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Timeslots
{
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Timeslot Timeslot { get; set; } = default!;

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
            else
            {
                Timeslot = timeslot;
            }
            return Page();
        }
    }
}
