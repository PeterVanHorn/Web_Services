﻿//Peter Van Horn
//Web Services Final
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages.Businesses
{
    public class EditModel : PageModel
    {
        private readonly VanHorn_WebServices_Final.Models.DomainContext _context;

        public EditModel(VanHorn_WebServices_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Business Business { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business =  await _context.Businesses.FirstOrDefaultAsync(m => m.SPId == id);
            if (business == null)
            {
                return NotFound();
            }
            Business = business;
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

            _context.Attach(Business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(Business.SPId))
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

        private bool BusinessExists(int id)
        {
            return _context.Businesses.Any(e => e.SPId == id);
        }
    }
}
