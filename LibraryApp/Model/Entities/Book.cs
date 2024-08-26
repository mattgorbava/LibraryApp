using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LibraryApp.Model.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string BookId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string FieldOfInterest { get; set; }
        public bool IsLost { get; set; }
        public bool IsLendable { get; set; }
        public int? PersonId { get; set; }
        public virtual Subscriber? Person { get; set; }
    }
}
