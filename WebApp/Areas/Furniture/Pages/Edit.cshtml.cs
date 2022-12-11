using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Areas.Furniture.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public EditModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Furniture Furniture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Furnitures == null)
            {
                return NotFound();
            }

            var furniture =  await _context.Furnitures.FirstOrDefaultAsync(m => m.Type == id);
            if (furniture == null)
            {
                return NotFound();
            }
            Furniture = furniture;
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

            _context.Attach(Furniture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitureExists(Furniture.Type))
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

        private bool FurnitureExists(string id)
        {
          return _context.Furnitures.Any(e => e.Type == id);
        }
    }
}
