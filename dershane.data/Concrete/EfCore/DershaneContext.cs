using dershane.entity;
using Microsoft.EntityFrameworkCore;
namespace dershane.data.Concrete.EfCore
{
    public class DershaneContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dershaneDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OgrenciBolum>()
            .HasKey(c => new { c.BolumId, c.OgrenciId });

        }
    }
}