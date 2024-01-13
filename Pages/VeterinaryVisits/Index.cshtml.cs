using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryVisits
{
    public class IndexModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public IndexModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IList<VeterinaryVisit> VeterinaryVisit { get; set; } = default!;

        public async Task OnGetAsync()
        {
            VeterinaryVisit = await _context.VeterinaryVisit
                .Include(v => v.Animal.Member)
                .Include(v => v.VeterinaryClinic).ToListAsync();
        }
    }
}
