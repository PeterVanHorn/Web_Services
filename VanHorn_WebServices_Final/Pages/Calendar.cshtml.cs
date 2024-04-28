using Azure.Core;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VanHorn_WebServices_Final.Models;

namespace VanHorn_WebServices_Final.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly DomainContext _context;

        public CalendarModel(DomainContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostCheckDayExistence(string id)
        {
            try
            {
                // Check if a day object exists for the given date
                var existingDay = await _context.Days.FirstOrDefaultAsync(d => d.Id == id);

                if (existingDay != null)
                {
                    // If a day object exists, return its ID
                    return new JsonResult(new { exists = true, dayId = existingDay.Id });
                }
                else
                {
                    // If no day object exists, return false
                    return new JsonResult(new { exists = false });
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return StatusCode(500, new { error = "An error occurred while processing the request." });
            }
            
        }
    }
}
