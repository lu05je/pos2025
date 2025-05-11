/*
 * @author: Prof. Mag. Robert Gröbl
 * @date: 02.05.2023
 * @description: POS Fachklausur 2022/23 
 * 
 * Model class used in all projects of PCRTestsystem (Testdaten objects) 
 */

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebClientTestperson.Models
{
    public enum Status
    {
        angemeldet,
        getestet,
        ausgewertet
    }

    public class Testdaten
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("plz")]
        [Required(ErrorMessage = "PLZ is required!")]
        [Range(5000, 5999, ErrorMessage = "PLZ must be between 5000 and 5999!")]
        public int PLZ { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email address is required!")]
        [EmailAddress]
        public string? Email { get; set; }

        [JsonPropertyName("gebTag")]
        [Required(ErrorMessage = "Date of birth is required!")]
        [DataType(DataType.Date)]
        [DefaultValue(null)]
        public DateTime GebTag { get; set; }

        [JsonPropertyName("code")]
        [DefaultValue(null)]
        public string? Code { get; set; }

        [JsonPropertyName("testzeitSoll")]
        [DefaultValue(null)]
        public DateTime? TestzeitSoll { get; set; }

        [JsonPropertyName("testzeitIst")]
        [DefaultValue(null)]
        public DateTime? TestzeitIst { get; set; }

        [JsonPropertyName("auswertzeit")]
        [DefaultValue(null)]
        public DateTime? Auswertzeit { get; set; }

        [JsonPropertyName("ctWert")]
        [DefaultValue(0.00)]
        [Range(0.00, 40.00)]
        public double CTWert { get; set; }


        [JsonPropertyName("status")]
        [DefaultValue(Status.angemeldet)]
        public Status Status { get; set; }
    }
}
