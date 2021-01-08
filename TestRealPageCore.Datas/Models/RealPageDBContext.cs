using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestRealPageCore.Datas.Models
{
    public partial class RealPageDBContext : DbContext
    {
        public RealPageDBContext()
        {
        }

        public RealPageDBContext(DbContextOptions<RealPageDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Propertie> Properties { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=RealPageDB;user id=sa;password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Propertie>(entity =>
            {
                entity.HasKey(e => e.IdPropertie);

                entity.ToTable("Propertie");

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.Modified).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Propertie_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.Adress).HasMaxLength(255);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Modified).HasColumnType("date");

                entity.Property(e => e.Phone).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
