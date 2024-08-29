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
        }

        public EditSubscriberPage(Subscriber subscriber)
        {
            InitializeComponent();
            DataContext = new EditSubscriberViewModel(subscriber);
            
        }
    }
}
