using System.ComponentModel.DataAnnotations;

namespace proiectClinica.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        [Display(Name = "Pet")]
        public int? AnimalId { get; set; }
        [Display(Name = "Pet")]
        public Animal? Animal { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Numele vaccinului trebuie să înceapă cu majusculă și să conțină între 3 și 50 de caractere.")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime VaccineDate { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Numele medicului veterinar trebuie să înceapă cu majusculă și să conțină între 3 și 30 de caractere.")]
        public string Vet {  get; set; }
    }
}
