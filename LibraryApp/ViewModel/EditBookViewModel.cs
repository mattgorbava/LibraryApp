using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using LibraryApp.View;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace LibraryApp.ViewModel
{
    public class EditBookViewModel: BaseViewModel
    {
        private readonly BookBLL bookBLL = new BookBLL();
        public ICommand SaveCommand { get; set; }
        
        public EditBookViewModel()
        {
           SaveCommand = new RelayCommand<object>(AddBook, canExecute => TextBoxFieldsNotNull());
        }

        public EditBookViewModel(Book book)
        {
            SaveCommand = new RelayCommand<object>(EditBook, canExecute => TextBoxFieldsNotNull());
            BookId = book.BookId;
            Title = book.Title;
            ReleaseYear = book.ReleaseYear;
            Publisher = book.Publisher;
            FieldOfInterest = book.FieldOfInterest;
        }

        public string BookId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string FieldOfInterest { get; set; }

        private void AddBook(object? obj)
        {
            Book toBeAdded = new Book()
            {
                BookId = this.BookId,
                Title = this.Title,
                ReleaseYear = this.ReleaseYear,
                Publisher = this.Publisher,
                FieldOfInterest = this.FieldOfInterest
            };
            bookBLL.AddBook(toBeAdded);
            MessageBox.Show("Book added successfully!");

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        private void EditBook(object? obj)
        {
            bookBLL.EditBook(new Book()
            {
                BookId = this.BookId,
                Title = this.Title,
                ReleaseYear = this.ReleaseYear,
                Publisher = this.Publisher,
                FieldOfInterest = this.FieldOfInterest
            });
            MessageBox.Show("Book edited successfully!");

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Title) && releaseYear != null &&
                !string.IsNullOrEmpty(Publisher) && !string.IsNullOrEmpty(FieldOfInterest);
        }
    }
}
