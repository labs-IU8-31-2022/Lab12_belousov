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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public DetailsModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

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
    }
}
