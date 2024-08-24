using LibraryApp.Model.DataAccessLayer;
using LibraryApp.Model.Entities;
using System.Collections.ObjectModel;

namespace LibraryApp.Model.BusinessLogicLayer
{
    public class PersonnelBLL
    {
        private readonly PersonnelDAL personnelDAL;
        public PersonnelBLL()
        {
            personnelDAL = new PersonnelDAL();
        }
        public ObservableCollection<Personnel> GetPersonnel()
        {
            ObservableCollection<Personnel> personnelList = new ObservableCollection<Personnel>();
            foreach (var personnel in personnelDAL.GetAllPersonnel())
                personnelList.Add(personnel);
            return personnelList;
        }

        public void AddPersonnel(Personnel personnel)
        {
            personnelDAL.AddPersonnel(personnel);
        }

        public void EditPersonnel(Personnel personnel)
        {
            personnelDAL.EditPersonnel(personnel);
        }

        public void DeregisterPersonnel(Personnel personnel)
        {
            personnelDAL.DeregisterPersonnel(personnel);
        }
    }
}
