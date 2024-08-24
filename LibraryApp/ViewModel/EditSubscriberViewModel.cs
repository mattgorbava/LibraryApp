using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System.Collections.ObjectModel;

namespace LibraryApp.ViewModel
{
    public class EditSubscriberViewModel : BaseViewModel
    {

        private readonly SubscriberBLL subscriberBLL = new SubscriberBLL();

        public ObservableCollection<Subscriber> Subscribers { get; set; }

        public RelayCommand AddSubscriberCommand => new RelayCommand(execute => AddSubscriber(), canExecute => TextBoxFieldsNotNull());
        public RelayCommand ToggleRegisteredCommand => new RelayCommand(execute => ToggleRegistered(), canExecute => SelectedSubscriber != null);
        public RelayCommand EditSubscriberCommand => new RelayCommand(execute => EditSubscriber(), canExecute => SelectedSubscriber != null);

        public EditSubscriberViewModel()
        {
            Subscribers = new ObservableCollection<Subscriber>(subscriberBLL.GetSubscribers());
        } 

        private Subscriber selectedSubscriber;

        public Subscriber SelectedSubscriber
        {
            get { return selectedSubscriber; }
            set
            {
                selectedSubscriber = value;
                Name = selectedSubscriber.Name;
                CNP = selectedSubscriber.CNP;
                Address = selectedSubscriber.Address;
                PhoneNumber = selectedSubscriber.PhoneNumber;
                OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string cnp;

        public string CNP
        {
            get { return cnp; }
            set
            {
                cnp = value;
                OnPropertyChanged();
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private void AddSubscriber()
        {
            subscriberBLL.AddSubscriber(new Subscriber
            {
                Name = name,
                CNP = cnp,
                Address = address,
                PhoneNumber = phoneNumber
            });
        }

        private void ToggleRegistered()
        {
            subscriberBLL.ToggleRegistered(selectedSubscriber);
        }

        private void EditSubscriber()
        {
            subscriberBLL.EditSubscriber(new Subscriber
            {
                PersonId = selectedSubscriber.PersonId,
                Name = name,
                CNP = cnp,
                Address = address,
                PhoneNumber = phoneNumber,
                IsRegistered = selectedSubscriber.IsRegistered
            });
        }

        private void ToggleDeregistered()
        {
            subscriberBLL.ToggleRegistered(selectedSubscriber);
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(CNP) && 
                !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(PhoneNumber);
        }
    }
}
