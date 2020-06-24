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
                    .HasName("PK__Departam__0E65B7A64EEC1011");

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
                    .HasConstraintName("FK__Departame__TypeI__45F365D3");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Posts__F8DCBD4DA818A572");

                entity.Property(e => e.IdPost).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NamePost)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypesOfDep>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__TypesOfD__9A39EABCA37169A5");

                entity.Property(e => e.IdType).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C926384B9CB3F6");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__DepId__4AB81AF0");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Users__PostId__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
