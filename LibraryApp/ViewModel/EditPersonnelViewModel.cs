using LibraryApp.Model.BusinessLogicLayer;
using LibraryApp.Model.Entities;
using LibraryApp.MVVM;
using LibraryApp.View;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryApp.ViewModel
{
    public class EditPersonnelViewModel: BaseViewModel
    {
        private readonly PersonnelBLL personnelBLL = new PersonnelBLL();

        public ICommand SaveCommand { get; set; }

        public EditPersonnelViewModel()
        { 
            SaveCommand = new RelayCommand<object>(AddPersonnel, canExecute => TextBoxFieldsNotNull());
        }

        public EditPersonnelViewModel(Personnel personnel)
        {
            SaveCommand = new RelayCommand<object>(EditPersonnel, canExecute => TextBoxFieldsNotNull());
            PersonnelId = personnel.PersonnelId;
            Name = personnel.Name;
            EmploymentDate = personnel.EmploymentDate.ToString("M/d/yyyy h:mm:ss tt");
        }

        private int PersonnelId { get; set; }
        public string Name { get; set; }
        public string EmploymentDate { get; set; }


        private void AddPersonnel(object? obj)
        {
            Personnel toBeAdded = new Personnel
            {
                Name = this.Name,
                EmploymentDate = DateTime.ParseExact(this.EmploymentDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            };
            personnelBLL.AddPersonnel(toBeAdded);

            MessageBox.Show("Personnel added successfully!");
            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        private void EditPersonnel(object? obj)
        {
            personnelBLL.EditPersonnel(new Personnel
            { 
                PersonnelId = this.PersonnelId,
                Name = this.Name,
                EmploymentDate = DateTime.ParseExact(this.EmploymentDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            });
            MessageBox.Show("Personnel edited successfully!");

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new StartPage());
        }

        private bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
}
