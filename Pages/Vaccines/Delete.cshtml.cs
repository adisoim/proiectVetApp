using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;
using proiectVetApp.Data;

namespace proiectVetApp.Pages.Vaccines
{
    public class DeleteModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DeleteModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vaccine Vaccine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine.FirstOrDefaultAsync(m => m.Id == id);

            if (vaccine == null)
            {
                return NotFound();
            }
            else
            {
                Vaccine = vaccine;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine != null)
            {
                Vaccine = vaccine;
                _context.Vaccine.Remove(Vaccine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
