using System.ComponentModel.DataAnnotations;

namespace proiectClinica.Models
{
    public class VeterinaryVisit
    {
        public int Id { get; set; }
        [Display(Name = "Pet")]
        public int? AnimalId { get; set; }
        [Display(Name = "Pet")]
        public Animal? Animal { get; set; }
        [Display(Name = "Clinic")]
        public int? VeterinaryClinicId { get; set; }
        [Display(Name = "Clinic")]
        public VeterinaryClinic? VeterinaryClinic { get; set; }
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Simptomele trebuie să înceapă cu majusculă și să conțină între 3 și 100 de caractere.")]
        public string Symptoms { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Diagnosticul trebuie să înceapă cu majusculă și să conțină între 3 și 100 de caractere.")]
        public string Diagnostic {  get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$", ErrorMessage = "Tratamentul trebuie să înceapă cu majusculă și să conțină între 3 și 100 de caractere.")]
        public string Treatment { get; set; }
    }
}
