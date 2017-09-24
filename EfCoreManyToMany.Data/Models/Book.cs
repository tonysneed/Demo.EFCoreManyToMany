using System.Collections.Generic;

namespace EfCoreManyToMany.Data.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}