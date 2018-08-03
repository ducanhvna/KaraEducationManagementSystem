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
            set  {
                if(m_Model!= value)
                {
                    m_Model = value;
                    RaisePropertyChanged("EduModel");
                }
            }
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
       
    }
}