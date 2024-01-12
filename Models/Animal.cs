using System.ComponentModel.DataAnnotations;

namespace proiectClinica.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Display(Name = "Owner")]
        public int? MemberId { get; set; }
        [Display(Name = "Owner")]
        public Member? Member { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă și să conțină între 3 și 50 de caractere.")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Specia trebuie să înceapă cu majusculă și să conțină între 3 și 30 de caractere.")]
        public string Species { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Rasa trebuie să înceapă cu majusculă și să conțină între 3 și 30 de caractere.")]
        public string Race { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Disinfestation>? Disinfestations { get; set; }
        public ICollection<Vaccine>? Vaccines { get; set;}
        public ICollection<VeterinaryVisit>? VeterinaryVisit { get; set; }
    }
}
