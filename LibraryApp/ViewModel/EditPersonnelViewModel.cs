using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModel
{
    public class EditPersonnelViewModel: BaseViewModel
    {
        private readonly PersonnelBLL personnelBLL = new PersonnelBLL();

        public ObservableCollection<Personnel> Personnel { get; set; }

        public RelayCommand AddPersonnelCommand => new RelayCommand(execute => AddPersonnel(), canExecute => TextBoxFieldsNotNull());
        public RelayCommand EditPersonnelCommand => new RelayCommand(execute => EditPersonnel(), canExecute => SelectedPersonnel != null);
        public RelayCommand ToggleDeregisteredCommand => new RelayCommand(execute => ToggleDeregistered(), canExecute => SelectedPersonnel != null);

        public EditPersonnelViewModel()
        {
            //Personnel = new ObservableCollection<Personnel>(personnelBLL.GetPersonnel());
        }

        private Personnel selectedPersonnel;

        public Personnel SelectedPersonnel
        {
            get { return selectedPersonnel; }
            set
            {
                selectedPersonnel = value;
                Name = selectedPersonnel.Name;
                EmploymentDate = selectedPersonnel.EmploymentDate;
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

        private DateTime employmentDate;

        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }


        private void AddPersonnel()
        {
            personnelBLL.AddPersonnel(new Personnel 
            {
                Name = name,
                EmploymentDate = employmentDate 
            });
        }

        private void EditPersonnel()
        {
            personnelBLL.EditPersonnel(new Personnel
            { 
                PersonnelId = selectedPersonnel.PersonnelId,
                Name = name, 
                EmploymentDate = employmentDate, 
                IsDeregistered = selectedPersonnel.IsDeregistered    
            });
        }

        private void ToggleDeregistered()
        {
            selectedPersonnel.IsDeregistered = !selectedPersonnel.IsDeregistered;
            personnelBLL.EditPersonnel(selectedPersonnel);
        }

        private bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(name) /*&& vezi cum e DateOnly cand nu ii dai valoare (ex: la bool e false default), nu e null*/;
        }
    }
}
