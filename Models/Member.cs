using System.ComponentModel.DataAnnotations;

namespace proiectClinica.Models
{
    public class Member
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă și să conțină între 2 și 30 de caractere.")]
        public string? Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Adresa de email nu este validă.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}
