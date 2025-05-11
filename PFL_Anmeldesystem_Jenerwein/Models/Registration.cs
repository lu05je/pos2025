using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFL_Anmeldesystem_Jenerwein.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)] 
        public string Firstname { get; set; }

        [Required]
        [MaxLength(20)] 
        public string Lastname { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? AdmittedDate { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [NotMapped]
        public List<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();

        [NotMapped]
        public string? DepartmentChoice { get; set; }
    }
}
