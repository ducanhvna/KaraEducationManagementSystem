using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreateNewClassRoomDialogViewModel: ViewModelBase
    {
        public EduClassRoom NewClassRoom { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateNewClassRoomDialogViewModel()
        {
            // Initialize new class room
            NewClassRoom = new EduClassRoom();

            // Initialize Ok button command
            CreateNewCommand = new RelayCommand(CreateNew);

            // Initialize Cancel button command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);
        }
        #region CloseWithoutSaveCommand
        /// <summary>
        /// CloseWithoutSaveCommand
        /// </summary>
        public RelayCommand CloseWithoutSaveCommand { get; internal set; }

        /// <summary>
        /// CloseWithoutSave
        /// </summary>
        /// <param name="param"></param>
        private void CloseWithoutSave(object param)
        {
            NewClassRoom = null;
            CloseWindowFlag = false;
        }
        #endregion

        #region CreateNewCommand
        public RelayCommand CreateNewCommand { get; internal set; }

        private void CreateNew(object param)
        {
            CloseWindowFlag = true;
        }
        #endregion
    }
}
