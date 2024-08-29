using LibraryApp.Model.Entities;
using LibraryApp.ViewModel;
using System.Windows.Controls;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for EditSubscriberPage.xaml
    /// </summary>
    public partial class EditSubscriberPage : Page
    {
        public EditSubscriberPage()
        {
            InitializeComponent();
            AddSubscriberLabel.Visibility = System.Windows.Visibility.Visible;
        }

        public EditSubscriberPage(Subscriber subscriber)
        {
            InitializeComponent();
            DataContext = new EditSubscriberViewModel(subscriber);
            EditSubscriberLabel.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
