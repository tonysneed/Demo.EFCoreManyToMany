using System.Collections.Generic;

namespace EfCoreManyToMany.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}