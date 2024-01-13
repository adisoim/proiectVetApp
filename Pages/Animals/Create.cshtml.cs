using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectClinica.Models;

namespace proiectVetApp.Pages.Animals
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

            ViewData["MemberId"] = new SelectList(_context.Set<Member>().Where(member => member.Email == userName), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Animal.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
