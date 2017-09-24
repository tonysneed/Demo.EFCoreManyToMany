using System.Collections.Generic;
using EfCoreManyToMany.Data.Models;

namespace EfCoreManyToMany.Data.Contexts
{
    public static class BookstoreData
    {
        public static List<Author> Authors;
        public static List<Book> Books;
        public static List<BookAuthor> BookAuthors;

        static BookstoreData()
        {
            Authors = new List<Author>
            {
                new Author
                {
                    AuthorId = 1,
                    Name = "Martin Fowler",
                    BookAuthors = new List<BookAuthor>(),
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Albert Einstein",
                    BookAuthors = new List<BookAuthor>(),
                },
                new Author
                {
                    AuthorId = 3,
                    Name = "Eric Evans",
                    BookAuthors = new List<BookAuthor>(),
                },
            };
            BookAuthors = new List<BookAuthor>();
            Books = CreateBooks();
            Authors[0].BookAuthors.Add(BookAuthors[0]);
            Authors[0].BookAuthors.Add(BookAuthors[2]);
            Authors[1].BookAuthors.Add(BookAuthors[1]);
            Authors[1].BookAuthors.Add(BookAuthors[4]);
            Authors[2].BookAuthors.Add(BookAuthors[3]);
        }

        private static List<Book> CreateBooks()
        {
            var martinFowler = Authors[0];
            var albertEinstein = Authors[1];
            var ericEvans = Authors[2];

            var books = new List<Book>();
            var book1 = new Book
            {
                BookId = 1,
                Title = "Refactoring",
            };
            BookAuthors.Add(new BookAuthor { Author = martinFowler, Book = book1, BookId = book1.BookId, AuthorId = martinFowler.AuthorId });
            BookAuthors.Add(new BookAuthor { Author = albertEinstein, Book = book1, BookId = book1.BookId, AuthorId = albertEinstein.AuthorId });
            book1.BookAuthors = new List<BookAuthor>
            {
                BookAuthors[0],
                BookAuthors[1],
            };
            books.Add(book1);

            var book2 = new Book
            {
                BookId = 2,
                Title = "Patterns of Enterprise Application Architecture",
            };
            BookAuthors.Add(new BookAuthor { Author = martinFowler, Book = book2, BookId = book2.BookId, AuthorId = martinFowler.AuthorId });
            book2.BookAuthors = new List<BookAuthor>
            {
                BookAuthors[2],
            };
            books.Add(book2);

            var book3 = new Book
            {
                BookId = 3,
                Title = "Domain-Driven Design",
            };
            BookAuthors.Add(new BookAuthor { Author = ericEvans, Book = book3, BookId = book3.BookId, AuthorId = ericEvans.AuthorId });
            book3.BookAuthors = new List<BookAuthor>
            {
                BookAuthors[3],
            };
            books.Add(book3);

            var book4 = new Book
            {
                BookId = 4,
                Title = "Quantum Networking",
            };
            BookAuthors.Add(new BookAuthor { Author = albertEinstein, Book = book4, BookId = book4.BookId, AuthorId = albertEinstein.AuthorId });
            book4.BookAuthors = new List<BookAuthor>
            {
                BookAuthors[4],
            };
            books.Add(book4);
            return books;
        }
    }
}