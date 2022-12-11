﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Areas.Staff.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public DeleteModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FirstOrDefaultAsync(m => m.Name == id);

            if (staff == null)
            {
                return NotFound();
            }
            else 
            {
                Staff = staff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.FindAsync(id);

            if (staff != null)
            {
                Staff = staff;
                _context.Staff.Remove(Staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
