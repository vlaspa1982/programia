using Microsoft.EntityFrameworkCore;
using ProgramiaMVC.Models;

namespace ProgramiaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<ObjednavkaPolozka> ObjednavkaPolozky { get; set; }
        public DbSet<Objednavka> Objednavky { get; set; }
        public DbSet<Zakaznik> Zakaznici { get; set; }
        public DbSet<ProduktObrazek> Obrazky { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Další konfigurace modelů (pokud potřebujete)
            modelBuilder.Entity<ObjednavkaPolozka>()
                .HasOne(p => p.Produkt)
                .WithMany()
                .HasForeignKey(p => p.ProduktId);

            modelBuilder.Entity<ObjednavkaPolozka>()
                .HasOne(o => o.Objednavka)
                .WithMany(o => o.Polozky)
                .HasForeignKey(o => o.ObjednavkaId);

            // Konfigurace vztahu mezi Objednavka a Zakaznik
            modelBuilder.Entity<Objednavka>()
                .HasOne(o => o.Zakaznik)  // Každá objednávka má jednoho zákazníka
                .WithMany(z => z.Objednavky)  // Zákazník může mít více objednávek
                .HasForeignKey(o => o.ZakaznikId);  // Cizí klíč ve sloupci ZakaznikId

            modelBuilder.Entity<Produkt>()
             .Property(p => p.Cena)
               .HasPrecision(18, 2); // 18 je celkový počet číslic, 2 je počet číslic za desetinnou čárkou

            modelBuilder.Entity<ObjednavkaPolozka>()
                .Property(o => o.CenaZaJednotku)
                .HasPrecision(18, 2);

            //modelBuilder.Entity<Produkt>()
            //    .HasMany(p => p.Obrazky)  // Produkt má mnoho obrázků
            //    .WithOne(o => o.Produkt)  
            //    .HasForeignKey(o => o.ProduktId);  // Cizí klíč ve sloupci ProduktId

            modelBuilder.Entity<Zakaznik>()
                .HasMany(z => z.Objednavky) // Zákazník má mnoho objednávek
                .WithOne(o => o.Zakaznik)
                .HasForeignKey(o => o.ZakaznikId);

            modelBuilder.Entity<Objednavka>()
                .HasMany(o => o.Polozky)
                .WithOne(p => p.Objednavka)
                .HasForeignKey(p => p.ObjednavkaId);
            
          
        }

    }


}
