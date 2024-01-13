using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryVisits
{
    public class EditModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public EditModel(proiectVetApp.Data.proiectVetAppContext context)
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
            VeterinaryVisit = veterinaryvisit;
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
            ViewData["VeterinaryClinicId"] = new SelectList(_context.VeterinaryClinic, "Id", "Name");
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

            _context.Attach(VeterinaryVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinaryVisitExists(VeterinaryVisit.Id))
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

        private bool VeterinaryVisitExists(int id)
        {
            return _context.VeterinaryVisit.Any(e => e.Id == id);
        }
    }
}
