using Microsoft.EntityFrameworkCore;

namespace proiectVetApp.Data
{
    public class proiectVetAppContext : DbContext
    {
        public proiectVetAppContext(DbContextOptions<proiectVetAppContext> options)
            : base(options)
        {
        }

        public DbSet<proiectClinica.Models.Animal> Animal { get; set; } = default!;
        public DbSet<proiectClinica.Models.Member> Member { get; set; } = default!;
        public DbSet<proiectClinica.Models.Disinfestation> Disinfestation { get; set; } = default!;
        public DbSet<proiectClinica.Models.Vaccine> Vaccine { get; set; } = default!;
        public DbSet<proiectClinica.Models.VeterinaryClinic> VeterinaryClinic { get; set; } = default!;
        public DbSet<proiectClinica.Models.VeterinaryVisit> VeterinaryVisit { get; set; } = default!;
    }
}
