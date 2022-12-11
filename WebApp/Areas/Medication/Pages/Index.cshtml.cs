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
    public class IndexModel : PageModel
    {
        private readonly WebApp.Models.pharmacyContext _context;

        public IndexModel(WebApp.Models.pharmacyContext context)
        {
            _context = context;
        }

        public IList<Models.Medication> Medication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medications != null)
            {
                Medication = await _context.Medications.ToListAsync();
            }
        }
    }
}
