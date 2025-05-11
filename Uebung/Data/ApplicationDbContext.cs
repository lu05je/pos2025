using Microsoft.EntityFrameworkCore;
using Uebung.Models;

namespace Uebung.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Objekt> Objekte { get; set; }
        public DbSet<ListenObjekt> ListenObjekte { get; set; }
    }
}
