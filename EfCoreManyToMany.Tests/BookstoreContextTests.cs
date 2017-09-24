using EfCoreManyToMany.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfCoreManyToMany.Tests
{
    [Collection("BookstoreContext")]
    public class BookstoreContextTests
    {
        private readonly BookstoreContextFixture _fixture;

        public BookstoreContextTests(BookstoreContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Get_Book_With_Authors()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: true);

            // Act
            var book1 = context.Books.Find(1);

            // Assert
            Assert.Collection(book1.BookAuthors,
                ba => Assert.Equal(BookstoreData.Authors[0].Name, ba.Author.Name),
                ba => Assert.Equal(BookstoreData.Authors[1].Name, ba.Author.Name)
            );
        }

        [Fact]
        public void Set_Book_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.Entry(book).State = EntityState.Unchanged;

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(book).State);
            Assert.Equal(EntityState.Detached, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Detached, context.Entry(author).State);
        }

        [Fact]
        public void Set_BookAuthor_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.Entry(bookAuthor).State = EntityState.Unchanged;

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Detached, context.Entry(book).State);
            Assert.Equal(EntityState.Detached, context.Entry(author).State);
        }

        [Fact]
        public void Set_Author_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.Entry(author).State = EntityState.Unchanged;

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(author).State);
            Assert.Equal(EntityState.Detached, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Detached, context.Entry(book).State);
        }

        [Fact]
        public void Set_Author_BookAuthor_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.Entry(author).State = EntityState.Unchanged;
            context.Entry(bookAuthor).State = EntityState.Unchanged;

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(author).State);
            Assert.Equal(EntityState.Unchanged, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Detached, context.Entry(book).State);
        }

        [Fact]
        public void Set_BookAuthor_Author_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.Entry(bookAuthor).State = EntityState.Unchanged;
            context.Entry(author).State = EntityState.Unchanged;

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(author).State);
            Assert.Equal(EntityState.Unchanged, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Detached, context.Entry(book).State);
        }

        [Fact]
        public void TrackGraph_Set_State_Unchanged()
        {
            // Arrange
            var context = _fixture.GetContext(seedData: false);
            var book = BookstoreData.Books[0];
            var bookAuthor = book.BookAuthors[0];
            var author = bookAuthor.Author;

            // Act
            context.ChangeTracker.TrackGraph(book, n =>
            {
                n.Entry.State = EntityState.Unchanged;
            });

            // Assert
            Assert.Equal(EntityState.Unchanged, context.Entry(author).State);
            Assert.Equal(EntityState.Unchanged, context.Entry(bookAuthor).State);
            Assert.Equal(EntityState.Unchanged, context.Entry(book).State);
        }
    }
}
