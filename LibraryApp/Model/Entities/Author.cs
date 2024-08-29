using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Model.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AuthorName { get; set; }
    }
}
