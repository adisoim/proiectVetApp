using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryVisits
{
    public class DeleteModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public DeleteModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaryvisit = await _context.VeterinaryVisit.FindAsync(id);
            if (veterinaryvisit != null)
            {
                VeterinaryVisit = veterinaryvisit;
                _context.VeterinaryVisit.Remove(VeterinaryVisit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
