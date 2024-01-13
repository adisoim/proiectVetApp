using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryClinics
{
    public class DetailsModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DetailsModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

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
    }
}
