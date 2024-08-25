using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;

namespace LibraryApp.ViewModel
{
    class EditAuthorViewModel: BaseViewModel
    {
        private readonly AuthorBLL authorBLL = new AuthorBLL();

        public ObservableCollection<Author> Authors { get; set; }
        
        public EditAuthorViewModel()
        {
            Authors = new ObservableCollection<Author>(authorBLL.GetAuthors());
        }
        public EditAuthorViewModel(Book book) { }

        public RelayCommand AddAuthorCommand => new RelayCommand(execute => AddAuthor(), canExecute => string.IsNullOrEmpty(Name));
        public RelayCommand DeleteAuthorCommand => new RelayCommand(execute => DeleteAuthor(), canExecute => SelectedAuthor != null);

        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set 
            {
                selectedAuthor = value;
                Name = selectedAuthor.Name;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged();
            }
        }

        private void AddAuthor()
        {
            authorBLL.AddAuthor(new Author { Name = name });
        }

        private void DeleteAuthor()
        {
            authorBLL.RemoveAuthor(selectedAuthor);
        }
    }
}
