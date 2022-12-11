using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Areas.Medication.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public DetailsModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

      public Models.Medication Medication { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Medications == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications.FirstOrDefaultAsync(m => m.Name == id);
            if (medication == null)
            {
                return NotFound();
            }
            else 
            {
                Medication = medication;
            }
            return Page();
        }
    }
}
