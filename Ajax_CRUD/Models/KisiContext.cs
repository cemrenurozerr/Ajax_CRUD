using Microsoft.EntityFrameworkCore;

namespace Ajax_CRUD.Models
{
    public class KisiContext:DbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public KisiContext(DbContextOptions<KisiContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasKey(x=>x.ID);
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi() { ID=1, Ad="Cansu", Soyad="Kümber"},
                new Kisi() { ID=2, Ad="Cemre", Soyad="Özer"}
            );
        }


    }
}
