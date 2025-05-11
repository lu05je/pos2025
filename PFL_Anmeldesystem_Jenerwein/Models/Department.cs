using System.ComponentModel.DataAnnotations;

namespace PFL_Anmeldesystem_Jenerwein.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }
        public string? Longname { get; set; }
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
