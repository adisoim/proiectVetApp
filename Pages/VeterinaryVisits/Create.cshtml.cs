using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryVisits
{
    public class CreateModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;
        private UserManager<IdentityUser> UserManager;

        public CreateModel(proiectVetApp.Data.proiectVetAppContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            this.UserManager = UserManager;
        }

        public IActionResult OnGet()
        {
            string userName = UserManager.GetUserName(User);

            ViewData["AnimalId"] = new SelectList(_context.Animal.Where(animal => animal.Member.Email == userName), "Id", "Name");
            ViewData["VeterinaryClinicId"] = new SelectList(_context.VeterinaryClinic, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public VeterinaryVisit VeterinaryVisit { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VeterinaryVisit.Add(VeterinaryVisit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
