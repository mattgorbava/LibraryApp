namespace LibraryApp.Model.Entities
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public DateTime EmploymentDate { get; set; }
        public bool IsDeregistered { get; set; }
    }
}
