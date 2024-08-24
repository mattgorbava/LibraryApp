using LibraryApp.Model.DataAccessLayer;
using LibraryApp.Model.Entities;
using System.Collections.ObjectModel;

namespace LibraryApp.Model.BusinessLogicLayer
{
    public class AuthorBLL
    {
        private readonly AuthorDAL authorDAL;

        public AuthorBLL()
        {
            authorDAL = new AuthorDAL();
        }

        public ObservableCollection<Author> GetAuthors()
        {
            ObservableCollection<Author> authors = new ObservableCollection<Author>();
            foreach (var author in authorDAL.GetAuthors())
                authors.Add(author);
            return authors;
        }

        public void AddAuthor(Author author)
        {
            authorDAL.AddAuthor(author);
        }

        public void RemoveAuthor(Author author)
        {
            authorDAL.DeleteAuthor(author);
        }
    }
}
