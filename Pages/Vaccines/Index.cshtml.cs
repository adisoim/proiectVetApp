using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.Vaccines
{
    public class IndexModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public IndexModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IList<Vaccine> Vaccine { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Vaccine = await _context.Vaccine
                .Include(v => v.Animal.Member).ToListAsync();
        }
    }
}
