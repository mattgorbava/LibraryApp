using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;
using LibraryApp.ViewModel;
using System.Windows.Controls;
using LibraryApp.View;
using System.Windows.Input;
using System.Windows;

namespace LibraryApp.ViewModel
{
    public class EditSubscriberViewModel : BaseViewModel
    {
        //private MainWindowViewModel mainWindowVM = new MainWindowViewModel();
        private readonly SubscriberBLL subscriberBLL = new SubscriberBLL();

        public ICommand SaveCommand { get; set; }
        public EditSubscriberViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddSubscriber, canExecute => TextBoxFieldsNotNull());
        } 

        public EditSubscriberViewModel(Subscriber subscriber)
        {
            SaveCommand = new RelayCommand<object>(EditSubscriber, canExecute => TextBoxFieldsNotNull());
            PersonId = subscriber.PersonId;
            Name = subscriber.Name;
            CNP = subscriber.CNP;
            Address = subscriber.Address;
            PhoneNumber = subscriber.PhoneNumber;
        }

        private int PersonId { get; set; }
        public string Name { get; set; }
        public string CNP { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        private void AddSubscriber(object? obj)
        {
            Subscriber subscriber = new Subscriber()
            {
                Name = Name,
                CNP = CNP,
                Address = Address,
                PhoneNumber = PhoneNumber,
                IsRegistered = true
            };
            subscriberBLL.AddSubscriber(subscriber);
            MessageBox.Show("Subscriber added successfully!");

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        private void EditSubscriber(object? obj)
        {
            Subscriber subscriber = new Subscriber()
            {
                PersonId = PersonId,
                Name = Name,
                CNP = CNP,
                Address = Address,
                PhoneNumber = PhoneNumber,
                IsRegistered = true
            };
            subscriberBLL.EditSubscriber(subscriber);
            MessageBox.Show("Subscriber edited successfully!");

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(CNP) && 
                !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(PhoneNumber);
        }
    }
}
