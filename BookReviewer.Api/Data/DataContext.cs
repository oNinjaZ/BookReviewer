using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Data;

public class DataContext : DbContext
{
    public DbSet<Author>? Author { get; set; }
    public DbSet<Book>? Book { get; set; }
    public DbSet<BookGenre>? BookGenre { get; set; }
    public DbSet<BookTag>? BookTag { get; set; }
    public DbSet<Genre>? Genre { get; set; }
    public DbSet<Review>? Review { get; set; }
    public DbSet<Reviewer>? Reviewer { get; set; }
    public DbSet<Tag>? Tag { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });
        modelBuilder.Entity<BookGenre>()
            .HasOne(b => b.Book)
            .WithMany(bg => bg.BookGenres)
            .HasForeignKey(b => b.BookId);
        modelBuilder.Entity<BookGenre>()
            .HasOne(g => g.Genre)
            .WithMany(bg => bg.BookGenres)
            .HasForeignKey(g => g.GenreId);

        modelBuilder.Entity<BookTag>()
            .HasKey(bt => new { bt.BookId, bt.TagId });
        modelBuilder.Entity<BookTag>()
            .HasOne(b => b.Book)
            .WithMany(bg => bg.BookTags)
            .HasForeignKey(b => b.BookId);
        modelBuilder.Entity<BookTag>()
            .HasOne(t => t.Tag)
            .WithMany(bt => bt.BookTags)
            .HasForeignKey(t => t.TagId);
    }
}