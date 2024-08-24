using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Model.Entities
{
    [PrimaryKey("BookId", "AuthorId")]
    public class BookAuthor
    {
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
