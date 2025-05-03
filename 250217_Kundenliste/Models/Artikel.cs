using System.ComponentModel.DataAnnotations;

namespace _250217_Kundenliste.Models
{
    public class Artikel
    {
        public int Id { get; set; }     //ID zur Identifikation in der Datenbank

        [Required(ErrorMessage = "Name ist erforderlich.")]
        [StringLength(100)] public string Name { get; set; }

        [StringLength(500)] public string? Beschreibung { get; set; }

        [Range(0.01, 10000.00)] public decimal? Preis { get; set; }

        [Range(0, 10000)] public int? Lagerbestand { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] public DateTime Erstellungsdatum { get; set; }
    }
}
