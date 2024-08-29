using LibraryApp.MVVM;
using LibraryApp.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LibraryApp.Model.Entities;
using LibraryApp.Model.BusinessLogicLayer;

namespace LibraryApp.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private readonly SubscriberBLL subscriberBLL = new SubscriberBLL();
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly PersonnelBLL personnelBLL = new PersonnelBLL();
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Personnel> Personnel { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public Subscriber SelectedSubscriber { get; set; }
        public Book SelectedBook { get; set; }
        public Personnel SelectedPersonnel { get; set; }
        public Author SelectedAuthor { get; set; }

        public ICommand AddSubscriberCommand { get; set; }
        public ICommand EditSubscriberCommand { get; set; }
        public ICommand DeregisterSubscriberCommand { get; set; }
        public ICommand AddBookCommand { get; set; }
        public ICommand EditBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand AddPersonnelCommand { get; set; }
        public ICommand EditPersonnelCommand { get; set; }
        public ICommand DeregisterPersonnelCommand { get; set; }
        public ICommand AddAuthorToBookCommand { get; set; }
        public StartViewModel()
        {
            AddSubscriberCommand = new RelayCommand<object>(AddSubscriber);
            EditSubscriberCommand = new RelayCommand<object>(EditSubscriber, canExecute => SelectedSubscriber != null);
            DeregisterSubscriberCommand = new RelayCommand<object>(DeregisterSubscriber);
            AddBookCommand = new RelayCommand<object>(AddBook);
            EditBookCommand = new RelayCommand<object>(EditBook, canExecute => SelectedBook != null);
            DeleteBookCommand = new RelayCommand<object>(DeleteBook);
            AddPersonnelCommand = new RelayCommand<object>(AddPersonnel);
            EditPersonnelCommand = new RelayCommand<object>(EditPersonnel, canExecute => SelectedPersonnel != null);
            DeregisterPersonnelCommand = new RelayCommand<object>(DeregisterPersonnel);
            AddAuthorToBookCommand = new RelayCommand<object>(AddAuthorToBook);

            Subscribers = new ObservableCollection<Subscriber>(subscriberBLL.GetSubscribers());
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            Personnel = new ObservableCollection<Personnel>(personnelBLL.GetPersonnel());
            Authors = new ObservableCollection<Author>(authorBLL.GetAuthors());
            Authors.Insert(0, new Author { AuthorName = "Select author" });
            Authors.Insert(1, new Author { AuthorName = "Add new" });
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
            subscriberBLL.ToggleRegistered(SelectedSubscriber);
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
            var currentPage = obj as StartPage;
            if (SelectedAuthor == null || SelectedAuthor.Equals("Select author"))
            {
                Console.WriteLine("No author selected");
                return;
            }
            else if (SelectedAuthor.Equals("Add new"))
                currentPage?.NavigationService?.Navigate(new EditAuthorPage());
            else
                authorBLL.AddAuthorToBook(SelectedAuthor, SelectedBook);
        }
    }
}
