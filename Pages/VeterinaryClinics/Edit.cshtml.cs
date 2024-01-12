using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;
using proiectVetApp.Data;

namespace proiectVetApp.Pages.VeterinaryClinics
{
    public class EditModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public EditModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VeterinaryClinic VeterinaryClinic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryclinic =  await _context.VeterinaryClinic.FirstOrDefaultAsync(m => m.Id == id);
            if (veterinaryclinic == null)
            {
                return NotFound();
            }
            VeterinaryClinic = veterinaryclinic;
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

            _context.Attach(VeterinaryClinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinaryClinicExists(VeterinaryClinic.Id))
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

        private bool VeterinaryClinicExists(int id)
        {
            return _context.VeterinaryClinic.Any(e => e.Id == id);
        }
    }
}
