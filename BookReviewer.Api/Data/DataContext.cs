using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Data;

public class DataContext : DbContext
{
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Genre> Genre { get; set; } = default!;
    public DbSet<Review> Review { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;
    public DbSet<Tag> Tag { get; set; } = default!;
    public DbSet<AuthorBook> AuthorBook { get; set; } = default!;
    public DbSet<BookGenre> BookGenre { get; set; } = default!;
    public DbSet<BookTag> BookTag { get; set; } = default!;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorBook>()
            .HasKey(ab => new { ab.AuthorId, ab.BookId });
        modelBuilder.Entity<AuthorBook>()
            .HasOne(a => a.Author)
            .WithMany(ab => ab.AuthorBooks)
            .HasForeignKey(a => a.AuthorId);
        modelBuilder.Entity<AuthorBook>()
            .HasOne(b => b.Book)
            .WithMany(ab => ab.AuthorBooks)
            .HasForeignKey(b => b.BookId);

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