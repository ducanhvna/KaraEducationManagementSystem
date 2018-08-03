using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Component;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class SchoolCreateItemsViewModel : ViewModelBase, IManageSchoolBase
    {
        /// <summary>
        /// Current Item Index
        /// </summary>
        private int m_currentItemIndex = 0;

        /// <summary>
        /// School Object
        /// </summary>
        private School m_SchoolObject = new School();
        KaraMongodbModel m_Model;
        private SubjectsManagerComponentViewModel m_SubjectsManagerViewModel;
        private ClassManagerComponentViewModel m_ClassManagerViewModel;
        private ClassroomManagerComponentViewModel m_ClassRoomManagerViewModel;
        private TeacherManagerComponentViewModel m_TeacherManagerViewModel;

        /// <summary>
        /// SchoolObject
        /// </summary>
        public School SchoolObject
        {
            get => m_SchoolObject; set
            {
                if (m_SchoolObject != value)
                {
                    m_SchoolObject = value;
                    SubjectsManagerViewModel.SchoolObject = m_SchoolObject;
                    ClassManagerViewModel.SchoolObject = m_SchoolObject;
                    ClassRoomManagerViewModel.SchoolObject = m_SchoolObject;
                    TeacherManagerViewModel.SchoolObject = m_SchoolObject;

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
            set => m_Model = value;
        }

        #region Contructor
        /// <summary>
        /// SchoolCreateItemsViewModel
        /// </summary>
        public SchoolCreateItemsViewModel()
        {
            // Initialize Subject select command 
            SubjectSelectCommand = new RelayCommand(SubjectSelect);

            // Initialize Class Select command
            ClassSelectCommand = new RelayCommand(ClassSelect);

            // Initialize Class room selected command
            ClassRoomSelectCommand = new RelayCommand(ClassRoomSelect);

            // Initialize Teacher select command
            TeacherSelectCommand = new RelayCommand(TeacherSelect);

            // Initialize Next command
            NextDialogCommand = new RelayCommand(NextDialog);

            // View model for subobject
            SubjectsManagerViewModel = new SubjectsManagerComponentViewModel();

            // ClassManagerViewModel
            ClassManagerViewModel = new ClassManagerComponentViewModel();

            // ClassRoomManagerViewModel
            ClassRoomManagerViewModel = new ClassroomManagerComponentViewModel();

            // TeacherManagerViewModel
            TeacherManagerViewModel = new TeacherManagerComponentViewModel();
        }
        #endregion

        #region Display Area
        /// <summary>
        /// CurrentItemIndex
        /// </summary>
        public int CurrentItemIndex
        {
            get
            {
                return m_currentItemIndex;
            }
            set
            {
                if(m_currentItemIndex != value)
                {
                    m_currentItemIndex = value;
                    RaisePropertyChanged("CurrentItemIndex");
                }
            }
        }
        #endregion

        #region Subject Area
        /// <summary>
        /// SubjectSelectCommand
        /// </summary>
        public RelayCommand SubjectSelectCommand { get; internal set; }

        /// <summary>
        /// SubjectSelect
        /// </summary>
        /// <param name="param"></param>
        private void SubjectSelect(object param)
        {
            CurrentItemIndex = 0;
        }


        #endregion

        #region Class Area
        /// <summary>
        /// ClassSelectCommand
        /// </summary>
        public RelayCommand ClassSelectCommand { get; internal set; }

        /// <summary>
        /// ClassSelect
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
        /// <summary>
        /// TeacherSelectCommand
        /// </summary>
        public RelayCommand TeacherSelectCommand { get; internal set; }

        /// <summary>
        /// TeacherSelect
        /// </summary>
        /// <param name="param"></param>
        private void TeacherSelect(object param)
        {
            CurrentItemIndex = 3;
        }
        #endregion

        #region Next 
        /// <summary>
        /// NextDialogCommand
        /// </summary>
        public RelayCommand NextDialogCommand { get; internal set; }

        /// <summary>
        /// Next Dialog Command execution
        /// </summary>
        /// <param name="param"></param>
        public void NextDialog(object param)
        {
            switch (CurrentItemIndex)
            {
                case 0:
                case 1:
                case 2:
                    CurrentItemIndex++;
                    break;
                case 3:
                    // Initialize Dialog 
                    FinishNewSchoolDialog dialog = new FinishNewSchoolDialog();

                    // Close window
                    CloseWindowFlag = false;

                    // Get ViewModel
                    var viewModel = dialog.DataContext as SchoolFinishNewViewModel;
                    if (viewModel == null)
                    {
                        return;
                    }

                    // Assign model
                    viewModel.NewSchoolObject = SchoolObject;

                    // Show dialog
                    dialog.ShowDialog();

                    CloseWindowFlag = viewModel.CloseWindowFlag;
                    break;
                default:
                    break;

            }
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
                if(m_SubjectsManagerViewModel!= value)
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
                if(m_ClassManagerViewModel != value)
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
                if(m_ClassRoomManagerViewModel != value)
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
                if(m_TeacherManagerViewModel != value)
                {
                    m_TeacherManagerViewModel = value;
                    RaisePropertyChanged("TeacherManagerViewModel");
                }
            }
        }

        #endregion
    }
}