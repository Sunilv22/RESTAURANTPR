using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESTAURANTPROJ.Models
{
    public partial class restaurantContext : DbContext
    {
        public restaurantContext()
        {
        }

        public restaurantContext(DbContextOptions<restaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Ordermenu> Ordermenus { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SQKRGQ09\\SQLEXPRESS;Database=restaurant;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Itemno)
                    .HasName("pk_menu");

                entity.ToTable("menu");

                entity.Property(e => e.Itemno).HasColumnName("itemno");

                entity.Property(e => e.Menu1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Ordermenu>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__ordermen__080E37751A7A4319");

                entity.ToTable("ordermenu");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Itemno).HasColumnName("itemno");

                entity.Property(e => e.Menu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("menu");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ItemnoNavigation)
                    .WithMany(p => p.Ordermenus)
                    .HasForeignKey(d => d.Itemno)
                    .HasConstraintName("fk_emp");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pk_registration");

                entity.ToTable("registration");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
