using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;
using proiectVetApp.Data;

namespace proiectVetApp.Pages.Disinfestations
{
    public class DetailsModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DetailsModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public Disinfestation Disinfestation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disinfestation = await _context.Disinfestation.FirstOrDefaultAsync(m => m.Id == id);
            if (disinfestation == null)
            {
                return NotFound();
            }
            else
            {
                Disinfestation = disinfestation;
            }
            return Page();
        }
    }
}
