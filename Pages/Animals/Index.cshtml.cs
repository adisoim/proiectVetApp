using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;

namespace proiectVetApp.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public IndexModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Animal = await _context.Animal
                .Include(a => a.Member).ToListAsync();
        }
    }
}
