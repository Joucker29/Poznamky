using Microsoft.EntityFrameworkCore;

namespace Poznamky.Data
{
    public class NasDatovyKontext : DbContext
    {
        public DbSet<Poznamky.Models.Poznamkyy> Poznamky { get; set; }
        public DbSet<Poznamky.Models.Users> Users { get; set; }

        public NasDatovyKontext(DbContextOptions<NasDatovyKontext> options) : base(options) {}
    }
}