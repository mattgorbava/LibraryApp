using LibraryApp.MVVM;
using LibraryApp.View;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LibraryApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        //private Object? _currentPage;
        //public Object? CurrentPage
        //{
        //    get => _currentPage;
        //    set
        //    {
        //        _currentPage = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public MainWindowViewModel()
        //{
        //    var startPage = new EditSubscriberPage();
        //    CurrentPage = startPage;
        //}

        private ObservableCollection<PageTemplate> pages;
        public ObservableCollection<PageTemplate> Pages
        {
            get => pages;
            set
            {
                pages = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Pages = new ObservableCollection<PageTemplate>
            {
                new PageTemplate{Header = "Subscribers", PageSource = "View/EditSubscriberPage.xaml"},
                new PageTemplate{Header = "Books", PageSource = "View/EditBookPage.xaml"},
                new PageTemplate{Header = "Personnel", PageSource = "View/EditPersonnelPage.xaml"},
                new PageTemplate{Header = "Authors", PageSource = "View/EditAuthorPage.xaml"}
            };
        }
    }

    public class PageTemplate
    {
        public string Header { get; set; }
        public string PageSource { get; set; }
    }
}
