using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;
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

        
    }
}
