using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryVisits
{
    public class DetailsModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DetailsModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public VeterinaryVisit VeterinaryVisit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryvisit = await _context.VeterinaryVisit.FirstOrDefaultAsync(m => m.Id == id);
            if (veterinaryvisit == null)
            {
                return NotFound();
            }
            else
            {
                VeterinaryVisit = veterinaryvisit;
            }
            return Page();
        }
    }
}
