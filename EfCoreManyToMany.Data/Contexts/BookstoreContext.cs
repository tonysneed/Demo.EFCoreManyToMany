using EfCoreManyToMany.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreManyToMany.Data.Contexts
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookstoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new
                {
                    x.BookId, x.AuthorId
                });
        }
    }
}