using LibraryApp.MVVM;
using LibraryApp.View;
using System.Collections.ObjectModel;

namespace LibraryApp.ViewModel
{
	public class MainWindowViewModel : BaseViewModel
	{
		private Object? _currentPage;

		public Object? CurrentPage
		{
			get { return _currentPage; }
			set
			{
				_currentPage = value;
				OnPropertyChanged();
			}
		}

		public MainWindowViewModel()
		{
			var startPage = new StartPage();
			CurrentPage = startPage;
		}
	}
}
