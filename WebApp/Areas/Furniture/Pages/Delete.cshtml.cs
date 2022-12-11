using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Areas.Furniture.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public DeleteModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Furniture Furniture { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Furnitures == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furnitures.FirstOrDefaultAsync(m => m.Type == id);

            if (furniture == null)
            {
                return NotFound();
            }
            else 
            {
                Furniture = furniture;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Furnitures == null)
            {
                return NotFound();
            }
            var furniture = await _context.Furnitures.FindAsync(id);

            if (furniture != null)
            {
                Furniture = furniture;
                _context.Furnitures.Remove(Furniture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
