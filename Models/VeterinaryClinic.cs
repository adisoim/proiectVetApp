using System.ComponentModel.DataAnnotations;

namespace proiectClinica.Models
{
    public class VeterinaryClinic
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z0-9][a-zA-Z0-9\s-]*$", ErrorMessage = "Numele cabinetului veterinar trebuie să înceapă cu majusculă sau cifră și să conțină între 3 și 50 de caractere.")]
        public string Name { get; set; }
        [RegularExpression(@"^.{3,100}$", ErrorMessage = "Adresa trebuie să conțină între 3 și 100 de caractere.")]
        public string Address { get; set; }
        [DataType(DataType.Time)]
        public DateTime Opens { get; set; }
        [DataType(DataType.Time)]
        public DateTime Closes { get; set; }
        public ICollection<VeterinaryVisit>? VeterinaryVisits { get; set; }
    }
}
