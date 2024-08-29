using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;

namespace LibraryApp.ViewModel
{
    class EditAuthorViewModel: BaseViewModel
    {
        //private readonly AuthorBLL authorBLL = new AuthorBLL();

        //public ObservableCollection<Author> Authors { get; set; }
        
        //public RelayCommand AddAuthorCommand;
        //public RelayCommand DeleteAuthorCommand;
        
        //public EditAuthorViewModel()
        //{
        //    //Authors = new ObservableCollection<Author>(authorBLL.GetAuthors());
        //    AddAuthorCommand = new RelayCommand(execute => AddAuthor(), canExecute => !string.IsNullOrEmpty(Name));
        //    DeleteAuthorCommand = new RelayCommand(execute => DeleteAuthor(), canExecute => SelectedAuthor != null);
        //}
        //public EditAuthorViewModel(Book book) 
        //{ 
        //    selectedBook = book;
        //    //Authors = new ObservableCollection<Author>(authorBLL.GetAuthors());
        //    AddAuthorCommand = new RelayCommand(execute => AddAuthorToBook(), canExecute => SelectedAuthor != null);
        //    DeleteAuthorCommand = new RelayCommand(execute => RemoveAuthorFromBook(), canExecute => SelectedAuthor != null);
        //}

        //private Author selectedAuthor;
        //public Author SelectedAuthor
        //{
        //    get { return selectedAuthor; }
        //    set 
        //    {
        //        selectedAuthor = value;
        //        Name = selectedAuthor.Name;
        //        OnPropertyChanged();
        //    }
        //}
        //private Book selectedBook;

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set 
        //    { 
        //        name = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private void AddAuthor()
        //{
        //    authorBLL.AddAuthor(new Author { Name = name });
        //}

        //private void DeleteAuthor()
        //{
        //    authorBLL.RemoveAuthor(selectedAuthor);
        //}
        //private void AddAuthorToBook()
        //{
        //    authorBLL.AddAuthorToBook(selectedAuthor, selectedBook);
        //}
        //private void RemoveAuthorFromBook()
        //{
        //    authorBLL.RemoveAuthorFromBook(selectedAuthor, selectedBook);
        //}
    }
}
