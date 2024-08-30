using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Model.Entities
{
    [PrimaryKey("BookId", "AuthorName")]
    public class BookAuthor
    {
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public string AuthorName { get; set; }
        public virtual Author Author { get; set; }
    }
}
