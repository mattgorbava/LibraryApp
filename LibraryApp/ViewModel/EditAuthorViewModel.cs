using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using LibraryApp.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryApp.ViewModel
{
    public class EditAuthorViewModel: BaseViewModel
    {
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        public ICommand SaveCommand { get; set; }
        public string Name { get; set; }
        public Book SelectedBook { get; set; }

        public EditAuthorViewModel(Book book)
        {
            SaveCommand = new RelayCommand<object>(AddAuthor, canExecute => !String.IsNullOrEmpty(Name));
            SelectedBook = book;
        }

        private void AddAuthor(object? obj)
        {
            Author toBeAdded = new Author
            {
                AuthorName = this.Name
            };
            authorBLL.AddAuthor(toBeAdded);
            authorBLL.AddAuthorToBook(toBeAdded, SelectedBook);

            MessageBox.Show("Author added successfully!");
            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }
    }
}
