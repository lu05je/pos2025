using Microsoft.EntityFrameworkCore;
using PFL_Anmeldesystem_Jenerwein.Models;

namespace PFL_Anmeldesystem_Jenerwein.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Registration> Registrations { get; set; } = null!;

    }
}
