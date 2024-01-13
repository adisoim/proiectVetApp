using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.Disinfestations
{
    public class EditModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public EditModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            Disinfestation = disinfestation;
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
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

            _context.Attach(Disinfestation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisinfestationExists(Disinfestation.Id))
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

        private bool DisinfestationExists(int id)
        {
            return _context.Disinfestation.Any(e => e.Id == id);
        }
    }
}
