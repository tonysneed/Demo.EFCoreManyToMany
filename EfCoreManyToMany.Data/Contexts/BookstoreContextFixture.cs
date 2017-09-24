using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EfCoreManyToMany.Data.Contexts
{
    public class BookstoreContextFixture : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<BookstoreContext> _options;

        public BookstoreContextFixture()
        {
            // In-memory database only exists while the connection is open
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            _options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseSqlite(_connection)
                .Options;
        }

        public BookstoreContext GetContext(bool seedData)
        {
            var context = new BookstoreContext(_options);
            context.Database.EnsureCreated();
            if (seedData)
            {
                EnsureSeedData(context);
            }
            return context;
        }

        private void EnsureSeedData(BookstoreContext context)
        {
            context.Books.AddRange(BookstoreData.Books);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}