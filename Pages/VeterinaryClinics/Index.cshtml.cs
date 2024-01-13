using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.VeterinaryClinics
{
    public class IndexModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public IndexModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IList<VeterinaryClinic> VeterinaryClinic { get; set; } = default!;

        public async Task OnGetAsync()
        {
            VeterinaryClinic = await _context.VeterinaryClinic.ToListAsync();
        }
    }
}
