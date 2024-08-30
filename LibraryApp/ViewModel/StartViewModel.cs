using LibraryApp.MVVM;
using LibraryApp.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LibraryApp.Model.Entities;
using LibraryApp.Model.BusinessLogicLayer;
using Microsoft.Identity.Client;
using System.Windows;

namespace LibraryApp.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private readonly SubscriberBLL subscriberBLL = new SubscriberBLL();
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly PersonnelBLL personnelBLL = new PersonnelBLL();
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<Book> BorrowedBooks { get; set; }
        public ObservableCollection<Book> AvailableBooks { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Personnel> Personnel { get; set; }
        public ObservableCollection<Author> Authors { get; set; }

        private Subscriber selectedSubscriber;

        public Subscriber SelectedSubscriber
        {
            get { return selectedSubscriber; }
            set 
            { 
                selectedSubscriber = value;
                BorrowedBooks = new ObservableCollection<Book>(bookBLL.SelectBorrowedBooks(selectedSubscriber));
                OnPropertyChanged();
            }
        }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set 
            { 
                selectedBook = value;
                OnPropertyChanged();
            }
        }

        private Personnel selectedPersonnel;

        public Personnel SelectedPersonnel
        {
            get { return selectedPersonnel; }
            set 
            {
                selectedPersonnel = value;
                OnPropertyChanged();
            }
        }

        public Author SelectedAuthor { get; set; }

        public ICommand AddSubscriberCommand { get; set; }
        public ICommand EditSubscriberCommand { get; set; }
        public ICommand DeregisterSubscriberCommand { get; set; }
        public ICommand AddBookCommand { get; set; }
        public ICommand EditBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand ToggleLendableCommand { get; set; }
        public ICommand ToggleLostCommand { get; set; }
        public ICommand ToggleLentCommand { get; set; }
        public ICommand AddPersonnelCommand { get; set; }
        public ICommand EditPersonnelCommand { get; set; }
        public ICommand DeregisterPersonnelCommand { get; set; }
        public ICommand AddAuthorToBookCommand { get; set; }
        public ICommand LendBookCommand { get; set; }
        public ICommand ReturnBookCommand { get; set; }
        public StartViewModel()
        {
            AddSubscriberCommand = new RelayCommand<object>(AddSubscriber);
            EditSubscriberCommand = new RelayCommand<object>(EditSubscriber, canExecute => SelectedSubscriber != null);
            DeregisterSubscriberCommand = new RelayCommand<object>(DeregisterSubscriber, canExecute => SelectedSubscriber != null);
            LendBookCommand = new RelayCommand<object>(LendBook, canExecute => SelectedSubscriber != null);
            ReturnBookCommand = new RelayCommand<object>(ReturnBook, canExecute => SelectedSubscriber != null);
            
            AddBookCommand = new RelayCommand<object>(AddBook);
            EditBookCommand = new RelayCommand<object>(EditBook, canExecute => SelectedBook != null);
            DeleteBookCommand = new RelayCommand<object>(DeleteBook, canExecute => SelectedBook != null);
            ToggleLendableCommand = new RelayCommand<object>(ToggleLendable, canExecute => SelectedBook != null);
            ToggleLostCommand = new RelayCommand<object>(ToggleLost, canExecute => SelectedBook != null);
            ToggleLentCommand = new RelayCommand<object>(ToggleLent, canExecute => SelectedBook != null);

            AddPersonnelCommand = new RelayCommand<object>(AddPersonnel);
            EditPersonnelCommand = new RelayCommand<object>(EditPersonnel, canExecute => SelectedPersonnel != null);
            DeregisterPersonnelCommand = new RelayCommand<object>(DeregisterPersonnel);
            AddAuthorToBookCommand = new RelayCommand<object>(AddAuthorToBook, canExecute => SelectedBook != null);

            Subscribers = new ObservableCollection<Subscriber>(subscriberBLL.GetSubscribers());
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            Personnel = new ObservableCollection<Personnel>(personnelBLL.GetPersonnel());
            Authors = new ObservableCollection<Author>(authorBLL.GetAuthors());
            Authors.Insert(0, new Author { AuthorName = "<Add new>" });
            AvailableBooks = new ObservableCollection<Book>(bookBLL.SelectAvailableBooks(selectedSubscriber));
        }

        private void AddSubscriber(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditSubscriberPage());
        }

        private void EditSubscriber(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditSubscriberPage(SelectedSubscriber));
        }

        private void DeregisterSubscriber(object? obj)
        {
            if (SelectedSubscriber == null)
            {
                Console.WriteLine("No subscriber selected");
                return;
            }
            SelectedSubscriber.IsRegistered = !SelectedSubscriber.IsRegistered;
            subscriberBLL.EditSubscriber(SelectedSubscriber);
            Subscribers = new ObservableCollection<Subscriber>(subscriberBLL.GetSubscribers());
            OnPropertyChanged(nameof(Subscribers));
        }

        private void AddBook(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditBookPage());
        }

        private void EditBook(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditBookPage(SelectedBook));
        }

        private void DeleteBook(object? obj)
        {
            if (SelectedBook == null)
            {
                Console.WriteLine("No book selected");
                return;
            }
            bookBLL.DeleteBook(SelectedBook);
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }

        private void AddPersonnel(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPersonnelPage());
        }

        private void EditPersonnel(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPersonnelPage(SelectedPersonnel));
        }

        private void DeregisterPersonnel(object? obj)
        {
            if (SelectedPersonnel == null)
            {
                Console.WriteLine("No personnel selected");
                return;
            }
            personnelBLL.DeregisterPersonnel(SelectedPersonnel);
            Personnel = new ObservableCollection<Personnel>(personnelBLL.GetPersonnel());
            OnPropertyChanged(nameof(Personnel));
        }

        private void AddAuthorToBook(object? obj)
        {
            if (obj is not StartPage currentPage)
            {
                Console.WriteLine("Current page is not StartPage");
                return;
            }

            if (SelectedAuthor.AuthorName == null || SelectedAuthor.AuthorName.Equals("Select author"))
            {
                Console.WriteLine("No author selected");
                return;
            }
            else if (SelectedAuthor.AuthorName.Equals("<Add new>"))
                currentPage?.NavigationService?.Navigate(new EditAuthorPage(SelectedBook));
            else
                authorBLL.AddAuthorToBook(SelectedAuthor, SelectedBook);
        }

        private void ToggleLendable(object? obj)
        {
            //if (obj is not StartPage currentPage)
            //{
            //    Console.WriteLine("Current page is not StartPage");
            //    return;
            //}

            SelectedBook.IsLendable = !SelectedBook.IsLendable;
            bookBLL.EditBook(SelectedBook);
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }

        private void ToggleLost(object? obj)
        {
            //if (obj is not StartPage currentPage)
            //{
            //    Console.WriteLine("Current page is not StartPage");
            //    return;
            //}

            SelectedBook.IsLost = !SelectedBook.IsLost;
            bookBLL.EditBook(SelectedBook);
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }

        private void ToggleLent(object? obj)
        {
            //if (obj is not StartPage currentPage)
            //{
            //    Console.WriteLine("Current page is not StartPage");
            //    return;
            //}

            SelectedBook.IsLent = !SelectedBook.IsLent;
            bookBLL.EditBook(SelectedBook);
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }

        private void LendBook(object? obj)
        {
            if (SelectedBook == null)
            {
                MessageBox.Show("No book selected");
                return;
            }
            if (SelectedBook.IsLent || !SelectedBook.IsLendable || SelectedBook.IsLost)
            {
                MessageBox.Show("Book not available");
                return;
            }

            bookBLL.LendBook(SelectedBook, SelectedSubscriber);
            SelectedBook.IsLent = true;
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }

        private void ReturnBook(object? obj)
        {
            if (SelectedBook == null)
            {
                MessageBox.Show("No book selected");
                return;
            }

            bookBLL.ReturnBook(SelectedBook, SelectedSubscriber);
            SelectedBook.IsLent = false;
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            OnPropertyChanged(nameof(Books));
        }
    }
}
