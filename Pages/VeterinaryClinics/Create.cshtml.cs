using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryClinics
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public CreateModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VeterinaryClinic VeterinaryClinic { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VeterinaryClinic.Add(VeterinaryClinic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
