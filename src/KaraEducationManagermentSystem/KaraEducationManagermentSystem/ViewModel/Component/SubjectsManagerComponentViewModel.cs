using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Component
{
    class SubjectsManagerComponentViewModel : ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;
        public SubjectsManagerComponentViewModel()
        {
            // Initialize Subject Command
            AddNewSubjectCommand = new RelayCommand(AddNewSubject);
        }
        public School SchoolObject
        {
            get => m_SchoolObject; set
            {
                if (m_SchoolObject != value)
                {
                    m_SchoolObject = value;
                    RaisePropertyChanged("SchoolObject");
                }
            }
        }
        public KaraMongodbModel EduModel
        {
            get => m_Model;
            set
            {
                if (m_Model != value)
                {
                    m_Model = value;
                    RaisePropertyChanged("EduModel");
                }
            }
        }

        #region AddNewSubjectCommand

        public RelayCommand AddNewSubjectCommand { get; internal set; }

        public void AddNewSubject(object param)
        {
            CreateNewSubjectDialog dialog = new CreateNewSubjectDialog();
            var vm = dialog.DataContext as CreateNewSubjectViewModel;
            if (vm != null)
            {
                dialog.ShowDialog();
                var dgResult = vm.CloseWindowFlag;

                if (dgResult == true)
                {
                    if (vm.NewSubject != null)
                    {
                        SchoolObject.ListSubject.Add(vm.NewSubject);
                    }
                }
            }
        }

       
        #endregion
    }
}
