using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Model.Entities
{
    [PrimaryKey("BorrowId")]
    public class SubscriberBook
    {
        public int BorrowId { get; set; }
        public int PersonId { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsActive { get; set; }
    }
}
