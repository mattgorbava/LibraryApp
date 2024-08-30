using LibraryApp.Model.Entities;
using System.Windows.Controls;
using LibraryApp.ViewModel;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for EditAuthorPage.xaml
    /// </summary>
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
