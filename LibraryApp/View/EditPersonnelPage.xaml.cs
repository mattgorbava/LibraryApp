using LibraryApp.Model.Entities;
using LibraryApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for EditPersonnelPage.xaml
    /// </summary>
    public partial class EditPersonnelPage : Page
    {
        public EditPersonnelPage()
        {
            InitializeComponent();
            AddPersonnelLabel.Visibility = System.Windows.Visibility.Visible;
        }

        public EditPersonnelPage(Personnel personnel)
        {
            InitializeComponent();
            EditPersonnelLabel.Visibility = System.Windows.Visibility.Visible;
            DataContext = new EditPersonnelViewModel(personnel);
        }
    }
}
