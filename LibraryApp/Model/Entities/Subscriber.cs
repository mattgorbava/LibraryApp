using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Model.Entities
{
    public class Subscriber
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string CNP { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsRegistered { get; set; }
    }
}
