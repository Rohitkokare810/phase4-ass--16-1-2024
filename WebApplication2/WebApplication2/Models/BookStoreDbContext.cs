using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategories { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:rohitkokareserver.database.windows.net,1433;Initial Catalog=BookStoreDb;Persist Security Info=False;User ID=RohitKokare;Password=Rohit@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Author__C69006289ACA1A05");

                entity.ToTable("Author");

                entity.Property(e => e.Aid)
                    .ValueGeneratedNever()
                    .HasColumnName("AId");

                entity.Property(e => e.Aname)
                    .HasMaxLength(50)
                    .HasColumnName("AName");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Book__C6DE0CC16A262429");

                entity.ToTable("Book");

                entity.Property(e => e.Bid)
                    .ValueGeneratedNever()
                    .HasColumnName("BId");

                entity.Property(e => e.Bname)
                    .HasMaxLength(50)
                    .HasColumnName("BName");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => e.Baid)
                    .HasName("PK__BookAuth__31BC6FE8E991379D");

                entity.ToTable("BookAuthor");

                entity.Property(e => e.Baid)
                    .ValueGeneratedNever()
                    .HasColumnName("BAId");

                entity.Property(e => e.Aid).HasColumnName("AId");

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK__BookAuthor__AId__693CA210");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(e => e.Bcid)
                    .HasName("PK__BookCate__31387BDA7317EDBE");

                entity.ToTable("BookCategory");

                entity.Property(e => e.Bcid)
                    .ValueGeneratedNever()
                    .HasColumnName("BCId");

                entity.Property(e => e.Bcat)
                    .HasMaxLength(50)
                    .HasColumnName("BCat");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Publishe__C57755409AFE003F");

                entity.ToTable("Publisher");

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("PId");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .HasColumnName("PName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
