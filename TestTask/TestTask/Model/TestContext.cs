using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTask.Model
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Departaments> Departaments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<TypesOfDep> TypesOfDep { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DRQFEK8\\SQLEXPRESS;Database=Test;Trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__Countrie__F99F104D50008097");

                entity.Property(e => e.IdCountry).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departaments>(entity =>
            {
                entity.HasKey(e => e.IdDep)
                    .HasName("PK__Departam__0E65B7A62FBF9639");

                entity.Property(e => e.IdDep).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.FullNameDep)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameDep)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Departaments)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Departame__TypeI__3F466844");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Posts__F8DCBD4D34FF6FF5");

                entity.Property(e => e.IdPost).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NamePost)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypesOfDep>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__TypesOfD__9A39EABC70859358");

                entity.Property(e => e.IdType).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C92638E559123F");

                entity.Property(e => e.IdUser).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LastnameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelUser)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__DepId__440B1D61");

                entity.HasOne(d => d.NationalityUserNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.NationalityUser)
                    .HasConstraintName("FK__Users__Nationali__44FF419A");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Users__PostId__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
