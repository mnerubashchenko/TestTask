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
            modelBuilder.Entity<Departaments>(entity =>
            {
                entity.HasKey(e => e.IdDep)
                    .HasName("PK__Departam__0E65B7A6E0E626BF");

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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Departame__TypeI__3D5E1FD2");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Posts__F8DCBD4D886F8E9B");

                entity.Property(e => e.IdPost).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NamePost)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypesOfDep>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__TypesOfD__9A39EABC90E7B5EC");

                entity.Property(e => e.IdType).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C9263836B7A52E");

                entity.Property(e => e.IdUser).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LastnameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelUser).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Users__DepId__4222D4EF");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__PostId__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
