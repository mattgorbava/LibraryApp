using LibraryApp.Model.Entities;
using System.Windows.Controls;
using LibraryApp.ViewModel;

namespace LibraryApp.View
{
    public partial class EditAuthorPage : Page
    {
        public EditAuthorPage()
        {
            InitializeComponent();
        }
        public EditAuthorPage(Book book)
        {
            InitializeComponent();
            DataContext = new EditAuthorViewModel(book);
        }
    }
}
