using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreateNewStudentViewModel: ViewModelBase
    {

        public EduStudent NewStudent { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateNewStudentViewModel()
        {
            // Initialize new teacher object
            NewStudent = new EduStudent();

            // Initialize Cancel button command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);

            // Initialize Ok button command
            CreateNewCommand = new RelayCommand(CreateNew);
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
            NewStudent = null;
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
