using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using LibraryApp.View;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Navigation;

namespace LibraryApp.ViewModel
{
    class AllEntitiesViewModel: BaseViewModel 
    {
        NavigationService navigationService;

        private readonly SubscriberBLL subscriberBLL = new SubscriberBLL();
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly PersonnelBLL personnelBLL = new PersonnelBLL();
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        private readonly BookAuthorBLL bookAuthorBLL = new BookAuthorBLL();

        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Personnel> Personnel { get; set; }
        public ObservableCollection<Author> Author { get; set; }
        public ObservableCollection<BookAuthor> BookAuthor { get; set; }

        //private Subscriber selectedSubscriber;
        //public Subscriber SelectedSubscriber
        //{
        //    get { return selectedSubscriber; }
        //    set
        //    {
        //        selectedSubscriber = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Book selectedBook;
        //public Book SelectedBook
        //{
        //    get { return selectedBook; }
        //    set
        //    {
        //        selectedBook = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Personnel selectedPersonnel;
        //public Personnel SelectedPersonnel
        //{
        //    get { return selectedPersonnel; }
        //    set
        //    {
        //        selectedPersonnel = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Author selectedAuthor;
        //public Author SelectedAuthor
        //{
        //    get { return selectedAuthor; }
        //    set
        //    {
        //        selectedAuthor = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private BookAuthor selectedBookAuthor;
        //public BookAuthor SelectedBookAuthor
        //{
        //    get { return selectedBookAuthor; }
        //    set
        //    {
        //        selectedBookAuthor = value;
        //        OnPropertyChanged();
        //    }
        //}

        public Subscriber SelectedSubscriber {  get; set; }
        public Book SelectedBook { get; set; }
        public Personnel SelectedPersonnel { get; set; }
        public Author SelectedAuthor { get; set; }
        public BookAuthor SelectedBookAuthor { get; set; }


        public RelayCommand AddSubscriberCommand { get; set; }
        public RelayCommand EditSubscriberCommand {  get; set; }
        public RelayCommand DeleteSubscriberCommand {  get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand EditBookCommand { get; set; }
        public RelayCommand DeleteBookCommand { get; set; }
        public RelayCommand AddPersonnelCommand { get; set; }
        public RelayCommand EditPersonnelCommand { get; set; }
        public RelayCommand DeletePersonnelCommand { get; set; }
        public RelayCommand AddAuthorCommand { get; set; }
        public RelayCommand EditAuthorCommand { get; set; }
        public RelayCommand DeleteAuthorCommand { get; set; }
        public RelayCommand AddBookAuthorCommand { get; set; }
        public RelayCommand EditBookAuthorCommand { get; set; }
        public RelayCommand DeleteBookAuthorCommand { get; set; }

        private void AddSubscriber()
        {
            navigationService.Navigate(new EditSubscriberPage());
        }

        public AllEntitiesViewModel()
        {
            navigationService = NavigationService.GetNavigationService(Application.Current.MainWindow);

            Subscribers = new ObservableCollection<Subscriber>(subscriberBLL.GetSubscribers());
            Books = new ObservableCollection<Book>(bookBLL.GetBooks());
            Personnel = new ObservableCollection<Personnel>(personnelBLL.GetPersonnel());
            Author = new ObservableCollection<Author>(authorBLL.GetAuthors());
            BookAuthor = new ObservableCollection<BookAuthor>(bookAuthorBLL.GetBookAuthors());
        }
    }
}
