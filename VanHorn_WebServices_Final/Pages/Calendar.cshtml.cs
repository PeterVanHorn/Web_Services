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
    }
}
