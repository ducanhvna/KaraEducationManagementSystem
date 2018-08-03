using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.ViewModel.Component;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class ManageSchoolItemsViewModel:ViewModelBase,IManageSchoolBase
    {
        /// <summary>
        /// Current selected items
        /// </summary>
        private int m_currentItemIndex;
        private TeacherManagerComponentViewModel m_TeacherManagerViewModel;
        private ClassroomManagerComponentViewModel m_ClassRoomManagerViewModel;
        private ClassManagerComponentViewModel m_ClassManagerViewModel;
        private SubjectsManagerComponentViewModel m_SubjectsManagerViewModel;

        public School FocusSchoolObject { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ManageSchoolItemsViewModel()
        {
            // Initialize Subject select command 
            SubjectSelectCommand = new RelayCommand(SubjectSelect);

            // Initialize Class Select command
            ClassSelectCommand = new RelayCommand(ClassSelect);

            // Initialize Class room selected command
            ClassRoomSelectCommand = new RelayCommand(ClassRoomSelect);

            // Initialize Teacher select command
            TeacherSelectCommand = new RelayCommand(TeacherSelect);
        }


        #region Display Area
        /// <summary>
        /// Current Item Index Properties
        /// </summary>
        public int CurrentItemIndex
        {
            get
            {
                return m_currentItemIndex;
            }
            set
            {
                if (m_currentItemIndex != value)
                {
                    m_currentItemIndex = value;
                    RaisePropertyChanged("CurrentItemIndex");
                }
            }
        }
        #endregion

        #region Subject Area

        /// <summary>
        /// Subject Selected Command
        /// </summary>
        public RelayCommand SubjectSelectCommand { get; internal set; }

        /// <summary>
        /// Sublected Select Command execution
        /// </summary>
        /// <param name="param"></param>
        private void SubjectSelect(object param)
        {
            CurrentItemIndex = 0;
        }
        #endregion

        #region Class Area
        /// <summary>
        /// Class Select Command
        /// </summary>
        public RelayCommand ClassSelectCommand { get; internal set; }

        /// <summary>
        /// Click button Class Command execution
        /// </summary>
        /// <param name="param"></param>
        private void ClassSelect(object param)
        {
            CurrentItemIndex = 1;
        }
        #endregion

        #region Class Room Area
        /// <summary>
        /// ClassRoomSelectCommand
        /// </summary>
        public RelayCommand ClassRoomSelectCommand { get; internal set; }

        /// <summary>
        /// ClassRoomSelect
        /// </summary>
        /// <param name="param"></param>
        private void ClassRoomSelect(object param)
        {
            CurrentItemIndex = 2;
        }
        #endregion


        #region Teacher Area
        public RelayCommand TeacherSelectCommand { get; internal set; }
        private void TeacherSelect(object param)
        {
            CurrentItemIndex = 3;
        }
        #endregion

        #region CloseDialogCommand
        /// <summary>
        /// CloseDialogCommand
        /// </summary>
        public RelayCommand CloseDialogCommand { get; internal set; }

        /// <summary>
        /// CloseDialog
        /// </summary>
        /// <param name="param"></param>
        private void CloseDialog(object param)
        {
            CloseWindowFlag = false;
        }



        #endregion

        #region Usercontrol ViewModels

        /// <summary>
        /// SubjectsManagerViewModel
        /// </summary>
        public SubjectsManagerComponentViewModel SubjectsManagerViewModel
        {
            get
            {
                return m_SubjectsManagerViewModel;
            }
            set
            {
                if (m_SubjectsManagerViewModel != value)
                {
                    m_SubjectsManagerViewModel = value;
                    RaisePropertyChanged("SubjectsManagerViewModel");
                }
            }

        }

        /// <summary>
        /// ClassManagerViewModel
        /// </summary>
        public ClassManagerComponentViewModel ClassManagerViewModel
        {
            get
            {
                return m_ClassManagerViewModel;

            }
            set
            {
                if (m_ClassManagerViewModel != value)
                {
                    m_ClassManagerViewModel = value;
                    RaisePropertyChanged("ClassManagerViewModel");
                }
            }
        }

        /// <summary>
        /// ClassRoomManagerViewModel
        /// </summary>
        public ClassroomManagerComponentViewModel ClassRoomManagerViewModel
        {
            get
            {
                return m_ClassRoomManagerViewModel;
            }
            set
            {
                if (m_ClassRoomManagerViewModel != value)
                {
                    m_ClassRoomManagerViewModel = value;
                    RaisePropertyChanged("ClassRoomManagerViewModel");
                }
            }
        }

        /// <summary>
        /// TeacherManagerViewModel
        /// </summary>
        public TeacherManagerComponentViewModel TeacherManagerViewModel
        {
            get
            {
                return m_TeacherManagerViewModel;
            }
            set
            {
                if (m_TeacherManagerViewModel != value)
                {
                    m_TeacherManagerViewModel = value;
                    RaisePropertyChanged("TeacherManagerViewModel");
                }
            }
        }

        #endregion

        #region Common Infomation
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

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
        /// EduModel
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

        #endregion
    }
}
