using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Areas.Furniture.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public CreateModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Furniture Furniture { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Furnitures.Add(Furniture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
