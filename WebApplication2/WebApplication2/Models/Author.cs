using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Aid { get; set; }
        public string? Aname { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
