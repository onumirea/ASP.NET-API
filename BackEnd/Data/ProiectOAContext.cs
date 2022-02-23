using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Data
{
    public class ProiectOAContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProiectOAContext(DbContextOptions options) : base(options) { }

        public DbSet<Autor> Autori { get; set; }
        public DbSet<Reteta> Retete { get; set; }
        public DbSet<Recenzie> Recenzii { get; set; }
        public DbSet<Informatii_nutritionale> Informatii_Nutritionale { get; set; }
        public DbSet<Ingredient> Ingrediente { get; set; }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<RetetaIngredient> RetetaIngrediente { get; set; }
        public DbSet<IngredientMagazin> IngredientMagazine { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many
            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Retete)
                .WithOne(r => r.Autor);
            modelBuilder.Entity<Reteta>()
                .HasMany(r1 => r1.Recenzii)
                .WithOne(r2 => r2.Reteta);
            //One to One
            modelBuilder.Entity<Magazin>()
                .HasOne(m => m.Adresa)
                .WithOne(ad => ad.Magazin);
            modelBuilder.Entity<Reteta>()
               .HasOne(re => re.Informatii_Nutritionale)
               .WithOne(inf => inf.Reteta);
            //Many to Many
            modelBuilder.Entity<RetetaIngredient>().HasKey(ri => new { ri.RetetaId, ri.IngredientId });
            modelBuilder.Entity<RetetaIngredient>()
               .HasOne(ri => ri.Reteta)
               .WithMany(r => r.RetetaIngrediente)
               .HasForeignKey(ri => ri.RetetaId);
            modelBuilder.Entity<RetetaIngredient>()
               .HasOne(ri => ri.Ingredient)
               .WithMany(i => i.RetetaIngrediente)
               .HasForeignKey(ri => ri.IngredientId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IngredientMagazin>().HasKey(im => new { im.IngredientId, im.MagazinId });
            modelBuilder.Entity<IngredientMagazin>()
                .HasOne(im => im.Ingredient)
                .WithMany(i => i.IngredientMagazine)
                .HasForeignKey(im => im.IngredientId);
            modelBuilder.Entity<IngredientMagazin>()
                .HasOne(im => im.Magazin)
                .WithMany(m => m.IngredientMagazine)
                .HasForeignKey(im => im.MagazinId);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
        }
    }
}

