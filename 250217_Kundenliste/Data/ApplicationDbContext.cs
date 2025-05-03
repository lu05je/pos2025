using _250217_Kundenliste.Models;
using Microsoft.EntityFrameworkCore;

namespace _250217_Kundenliste.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; } = null!;

        public DbSet<Artikel> Artikel { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
