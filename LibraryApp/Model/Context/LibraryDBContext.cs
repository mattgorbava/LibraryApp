using Microsoft.EntityFrameworkCore;
using LibraryApp.Model.Entities;

namespace LibraryApp.Model.Context
{
    internal class LibraryDBContext : DbContext
    {
        public DbSet<Subscriber> Subscriber { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ND1IOQ4;Database=UpdatedLibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
