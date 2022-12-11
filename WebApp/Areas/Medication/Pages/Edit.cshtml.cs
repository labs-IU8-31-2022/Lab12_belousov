using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Areas.Medication.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public EditModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Medication Medication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Medications == null)
            {
                return NotFound();
            }

            var medication =  await _context.Medications.FirstOrDefaultAsync(m => m.Name == id);
            if (medication == null)
            {
                return NotFound();
            }
            Medication = medication;
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

            _context.Attach(Medication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(Medication.Name))
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

        private bool MedicationExists(string id)
        {
          return _context.Medications.Any(e => e.Name == id);
        }
    }
}
