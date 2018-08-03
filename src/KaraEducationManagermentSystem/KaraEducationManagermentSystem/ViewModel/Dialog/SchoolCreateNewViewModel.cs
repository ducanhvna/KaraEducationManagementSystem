using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class SchoolCreateNewViewModel : ViewModelBase, IManageSchoolBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SchoolCreateNewViewModel()
        {
            // Initialize new object
            SchoolObject = new School()
            {
                AcademicYear = "",
                ListClassRoom = new ObservableCollection<EduClassRoom>(),
                Name = "",
                Teachers = new ObservableCollection<EduTeacher>(),
                ListClass = new ObservableCollection<EduClass>(),
                ListSubject = new ObservableCollection<EduSubject>(),
                TimeTable = new EduTimeTable()

            };
            // Initialize NextDialog command
            NextDialogCommand = new RelayCommand(NextDialog);

            // Initizelize Close buton Command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);

            // Initialize Ok button command
            CreateNewCommand = new RelayCommand(CreateNew);
        }
        #region Display Area
        public string Name { get
            {
                
                return SchoolObject?.Name;
            }
            set
            {
                if(SchoolObject.Name != value)
                {
                    SchoolObject.Name = value;
                    RaisePropertyChanged("NewSchoolObject");
                }
            }
        }

        public string AcademicYear
        {
            get
            {
                return SchoolObject?.AcademicYear;
            }
            set
            {
                if(SchoolObject?.AcademicYear != value)
                {
                    SchoolObject.AcademicYear = value;
                    RaisePropertyChanged("AcademicYear");
                }
            }
        }
        #endregion
        /// <summary>
        /// Next Dialog command
        /// </summary>
        public RelayCommand NextDialogCommand { get; internal set; }
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

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
                m_Model = value;
            }
        }

        /// <summary>
        /// Next Dialog Command execution
        /// </summary>
        /// <param name="param"></param>
        public void NextDialog(object param)
        {
            // Initialize Dialog 
            CreateSchoolItemsDialog dialog = new CreateSchoolItemsDialog();

            // Close window
            CloseWindowFlag = false;

            // Get ViewModel
            var viewModel = dialog.DataContext as SchoolCreateItemsViewModel;
            if(viewModel == null)
            {
                return;
            }

            // Assign model
            viewModel.SchoolObject = SchoolObject;

         

            // Show dialog
            var result = dialog.ShowDialog();

            CloseWindowFlag = viewModel.CloseWindowFlag;
        }

        #region CloseWithoutSaveCommand
        /// <summary>
        /// CloseWithoutSaveCommand
        /// </summary>
        public RelayCommand CloseWithoutSaveCommand { get; internal set; }

        /// <summary>
        /// CloseWithoutSave command execution
        /// </summary>
        /// <param name="param"></param>
        private void CloseWithoutSave(object param)
        {
            SchoolObject = null;
            CloseWindowFlag = false;
        }
        #endregion

        #region CreateNewCommand
        /// <summary>
        /// Create new command
        /// </summary>
        public RelayCommand CreateNewCommand { get; internal set; }

        /// <summary>
        /// Create new command execution
        /// </summary>
        /// <param name="param"></param>
        private void CreateNew(object param)
        {
            CloseWindowFlag = true;
        }
        #endregion
    }
}
