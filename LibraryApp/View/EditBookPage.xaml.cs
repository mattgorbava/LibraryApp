using LibraryApp.Model.Entities;
using LibraryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp.View
{
    public partial class EditBookPage : Page
    {
        public EditBookPage()
        {
            InitializeComponent();
            AddBookLabel.Visibility = System.Windows.Visibility.Visible;
        }
        public EditBookPage(Book book)
        {
            InitializeComponent();
            DataContext = new EditBookViewModel(book);
            EditBookLabel.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
