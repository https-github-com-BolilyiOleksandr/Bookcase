using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServerApp.Models.Bookcase
{
    public partial class BookcaseContext : DbContext
    {
        public BookcaseContext()
        {
        }

        public BookcaseContext(DbContextOptions<BookcaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<AuthorsBooks> AuthorsBooks { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Bookcase;User ID=sa;Password=LlvljehaLDA1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authors_Countries");
            });

            modelBuilder.Entity<AuthorsBooks>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId });

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks_Authors");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks_Books");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasMaxLength(50);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Genres");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Languages");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Publishers");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Ratings");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Country)
                    .HasName("UQ__Countrie__067B300915FEFF55")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasIndex(e => e.Genre)
                    .HasName("UQ__Genres__F1410CF354FF9BCC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasIndex(e => e.Language)
                    .HasName("UQ__Language__C3D592506824C141")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasIndex(e => e.Publisher)
                    .HasName("UQ__Publishe__C25E15AB641C8C00")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasIndex(e => e.Rating)
                    .HasName("UQ__Ratings__45BE90D584DC59D4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
