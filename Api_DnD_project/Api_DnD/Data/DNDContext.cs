using Api_DnD.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api_DnD.Data
{
    public class DNDContext : DbContext
    {
        public DNDContext(DbContextOptions<DNDContext> options) : base(options)
        {
        }

        public DbSet<Arme> Armes { get; set; }
        // Ambiguïté entre System.Action et notre objet Action
        public DbSet<Api_DnD.Model.Action> Actions { get; set; }
        public DbSet<Armure> Armures { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Enchantement> Enchantements { get; set; }
        public DbSet<Perso> Persos { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<PNJ> PNJ { get; set; }
        public DbSet<Key> Key {get;set;}
        public DbSet<Monstre> Monstres { get; set; }
        public DbSet<Campagne> Campagnes { get; set; }
        public DbSet<Quete> Quetes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arme>().ToTable("Arme");
            modelBuilder.Entity<Armure>().ToTable("Armure");
            modelBuilder.Entity<Classes>().ToTable("Classes");
            modelBuilder.Entity<Enchantement>().ToTable("Enchantement");
            modelBuilder.Entity<Perso>().ToTable("Perso");
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<PNJ>().ToTable("PNJ");
            modelBuilder.Entity<Key>().ToTable("Key");
            modelBuilder.Entity<Monstre>().ToTable("Monstre");
            modelBuilder.Entity<Campagne>().ToTable("Campagne");
            modelBuilder.Entity<Quete>().ToTable("Quete");
        }
    }
}
