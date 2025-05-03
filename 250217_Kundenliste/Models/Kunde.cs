using System.ComponentModel.DataAnnotations;

namespace _250217_Kundenliste.Models
{
    public class Kunde
    {
        public int Id { get; set; }     //ID zur Identifikation in der Datenbank

        [StringLength(20)] public string Vorname { get; set; }

        [StringLength(20)] public string Nachname { get; set; }

        [EmailAddress] public string Email { get; set; }

        [Phone] public string Telefonnummer { get; set; }

        [StringLength(100)] public string Adresse { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] public DateTime Geburtsdatum { get; set; }

        public List<Artikel> ArtikelListe { get; set; }
    }
}
