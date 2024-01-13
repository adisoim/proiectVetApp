using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryClinics
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DeleteModel(proiectVetApp.Data.proiectVetAppContext context)
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

            var veterinaryclinic = await _context.VeterinaryClinic.FirstOrDefaultAsync(m => m.Id == id);

            if (veterinaryclinic == null)
            {
                return NotFound();
            }
            else
            {
                VeterinaryClinic = veterinaryclinic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryclinic = await _context.VeterinaryClinic.FindAsync(id);
            if (veterinaryclinic != null)
            {
                VeterinaryClinic = veterinaryclinic;
                _context.VeterinaryClinic.Remove(VeterinaryClinic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
