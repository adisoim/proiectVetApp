using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectClinica.Models;
using proiectVetApp.Data;

namespace proiectVetApp.Pages.Disinfestations
{
    public class CreateModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public CreateModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Disinfestation Disinfestation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Disinfestation.Add(Disinfestation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
