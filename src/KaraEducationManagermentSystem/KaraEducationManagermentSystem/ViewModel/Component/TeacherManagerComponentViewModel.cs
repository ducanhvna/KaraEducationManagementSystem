using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Component
{
    class TeacherManagerComponentViewModel:ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

        /// <summary>
        /// Constructor
        /// </summary>
        public TeacherManagerComponentViewModel()
        {
            // Initialize Teacher Command
            AddNewTeacherCommand = new RelayCommand(AddNewTeacher);
        }

        /// <summary>
        /// School Object
        /// </summary>
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

        /// <summary>
        /// Edu Model
        /// </summary>
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

        #region AddNewTeacherCommand


        public RelayCommand AddNewTeacherCommand { get; internal set; }

        /// <summary>
        /// AddNewTeacher
        /// </summary>
        /// <param name="param"></param>
        public void AddNewTeacher(object param)
        {
            // Initialize dialog
            CreateNewTeacherDialog dialog = new CreateNewTeacherDialog();

            // Get data context
            var vm = dialog.DataContext as CreateNewTeacherDialogViewModel;
            if (vm != null)
            {

                // Show dialog
                 dialog.ShowDialog();
                var dgResult = vm.CloseWindowFlag;
                if (dgResult == true)
                {
                    if (vm.NewTeacher != null)
                    {
                        // Add teacher to school Object
                        SchoolObject.Teachers.Add(vm.NewTeacher);
                    }
                }
            }
        }


        #endregion
    }
}
