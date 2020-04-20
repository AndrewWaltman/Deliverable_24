using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Deliverable_24.EntityModels
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ANDREW-DESKTOP\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }

        public static void Seed(ModelBuilder model)
        {
            model.Entity<Items>()
                .HasData((new Items[]
                {
                    new Items()
                    {
                        Id = 1,
                        Name = "Regular Covfefe",
                        Description = "A regular covfefe",
                        Quantity = 5,
                        Price = 5.00M
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Irregular Covfefe",
                        Description = "A not normal Covfefe",
                        Quantity = 3,
                        Price = 7.00M
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "Super Rare Covfefe",
                        Description = "Extremely rare covfefe",
                        Quantity = 2,
                        Price = 100.00M
                    }
                }));
        }
    }
}
