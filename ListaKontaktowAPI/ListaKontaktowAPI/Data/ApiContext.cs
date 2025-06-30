using ListaKontaktowAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ListaKontaktowAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Kontakt> kontakty {  get; set; }
        public DbSet<User> Uzytkownicy { get; set; }
        public DbSet<SlownikKategorii> SlownikKategorii { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontakt>().HasKey(k => k.Email);

            modelBuilder.Entity<Kontakt>()
                .HasOne(k => k.Kategoria)
                .WithMany()
                .HasForeignKey(k => k.KategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasKey(k => k.Email);
        }
    }
}
