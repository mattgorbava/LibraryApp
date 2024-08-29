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
        
        public EditBookViewModel(Subscriber subscriber)
        {
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            LendBookCommand = new RelayCommand<Subscriber>(LendBook, canExecute => SelectedBook != null);
            ReturnBookCommand = new RelayCommand<Subscriber>(ReturnBook, canExecute => SelectedBook != null);
            EditBookCommand = new RelayCommand<object>(EditBook, canExecute => 1==0);
            ToggleLostCommand = new RelayCommand<object>(ToggleLost, canExecute => 1==0);
            ToggleLendableCommand = new RelayCommand<object>(ToggleLendable, canExecute => 1==0);
        }

        public EditBookViewModel()
        {
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            AddBookCommand = new RelayCommand<object>(AddBook, canExecute => TextBoxFieldsNotNull());
            DeleteBookCommand = new RelayCommand<object>(DeleteBook, canExecute => SelectedBook != null);
            EditBookCommand = new RelayCommand<object>(EditBook, canExecute => SelectedBook != null);
            ToggleLostCommand = new RelayCommand<object>(ToggleLost, canExecute => SelectedBook != null);
            ToggleLendableCommand = new RelayCommand<object>(ToggleLendable, canExecute => SelectedBook != null);
        }

        public RelayCommand<object> AddBookCommand;
        public RelayCommand<object> EditBookCommand;
        public RelayCommand<object> DeleteBookCommand;
        public RelayCommand<object> ToggleLostCommand;
        public RelayCommand<object> ToggleLendableCommand;

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

        private void AddBook(object? parameter)
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

        private void EditBook(object? parameter)
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
        
        private void DeleteBook(object? parameter)
        {
            bookBLL.DeleteBook(selectedBook);
            //Books.Remove(selectedBook);
        }

        private void ToggleLost(object? parameter)
        {
            selectedBook.IsLost = !selectedBook.IsLost;
            bookBLL.EditBook(selectedBook);
        }

        private void ToggleLendable(object? parameter)
        {
            selectedBook.IsLendable = !selectedBook.IsLendable;
            bookBLL.EditBook(selectedBook);
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Title) && releaseYear != null &&
                !string.IsNullOrEmpty(Publisher) && !string.IsNullOrEmpty(FieldOfInterest);
        }
        public void LendBook(Subscriber subscriber)
        {
            bookBLL.LendBook(SelectedBook, subscriber);

        }

        public void ReturnBook(Subscriber subscriber)
        {
            bookBLL.ReturnBook(SelectedBook, subscriber);
        }
    }
}
