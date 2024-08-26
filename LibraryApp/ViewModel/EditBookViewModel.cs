using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;

namespace LibraryApp.ViewModel
{
    public class EditBookViewModel: BaseViewModel
    {
        private readonly BookBLL bookBLL = new BookBLL();
        public ObservableCollection<Book> Books { get; set; }
        
        public EditBookViewModel()
        {
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
        }

        public RelayCommand AddBookCommand => new RelayCommand(execute => AddBook(), canExecute => TextBoxFieldsNotNull());
        public RelayCommand EditBookCommand => new RelayCommand(execute => EditBook(), canExecute => SelectedBook != null);
        public RelayCommand DeleteBookCommand => new RelayCommand(execute => DeleteBook(), canExecute => SelectedBook != null);
        public RelayCommand ToggleLostCommand => new RelayCommand(execute => ToggleLost(), canExecute => SelectedBook != null);
        public RelayCommand ToggleLendableCommand => new RelayCommand(execute => ToggleLendable(), canExecute => SelectedBook != null);

        private Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set 
            {
                selectedBook = value;
                BookId = selectedBook.BookId;
                Title = selectedBook.Title;
                ReleaseYear = selectedBook.ReleaseYear;
                Publisher = selectedBook.Publisher;
                FieldOfInterest = selectedBook.FieldOfInterest;
                OnPropertyChanged();
            }
        }

        private string bookId;

        public string BookId
        {
            get { return bookId; }
            set 
            {
                bookId = value;
                OnPropertyChanged();
            }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set 
            {
                title = value; 
                OnPropertyChanged();
            }
        }

        private int releaseYear;

        public int ReleaseYear
        {
            get { return releaseYear; }
            set 
            {
                releaseYear = value;
                OnPropertyChanged();
            }
        }

        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set 
            { 
                publisher = value;
                OnPropertyChanged();
            }
        }

        private string fieldOfInterest;

        public string FieldOfInterest
        {
            get { return fieldOfInterest; }
            set 
            { 
                fieldOfInterest = value;
                OnPropertyChanged();
            }
        }

        private void AddBook()
        {
            Book toBeAdded = new Book()
            {
                BookId = bookId,
                Title = Title,
                ReleaseYear = ReleaseYear,
                Publisher = Publisher,
                FieldOfInterest = FieldOfInterest
            };
            bookBLL.AddBook(toBeAdded);
            Books.Add(toBeAdded);
        }

        private void EditBook()
        {
            bookBLL.EditBook(new Book()
            {
                BookId = selectedBook.BookId,
                Title = Title,
                ReleaseYear = ReleaseYear,
                Publisher = Publisher,
                FieldOfInterest = FieldOfInterest
            });
        }
        
        private void DeleteBook()
        {
            bookBLL.DeleteBook(selectedBook);
            //Books.Remove(selectedBook);
        }

        private void ToggleLost()
        {
            selectedBook.IsLost = !selectedBook.IsLost;
            bookBLL.EditBook(selectedBook);
        }

        private void ToggleLendable()
        {
            selectedBook.IsLendable = !selectedBook.IsLendable;
            bookBLL.EditBook(selectedBook);
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Title) && releaseYear != null &&
                !string.IsNullOrEmpty(Publisher) && !string.IsNullOrEmpty(FieldOfInterest);
        }
    }
}
