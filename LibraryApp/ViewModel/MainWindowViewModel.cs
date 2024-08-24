using LibraryApp.MVVM;
using LibraryApp.View;

namespace LibraryApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Object? _currentPage;
        public Object? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            var startPage = new EditSubscriberPage();
            CurrentPage = startPage;
        }
    }
}
