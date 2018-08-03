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
    class ClassroomManagerComponentViewModel : ViewModelBase, IManageSchoolBase
    {
        // School Object
        private School m_SchoolObject;

        // Model
        KaraMongodbModel m_Model;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassroomManagerComponentViewModel()
        {
            // Add new class room command Initialize
            AddNewClassRoomCommand = new RelayCommand(AddNewClassRoom);
        }

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
            set
            {
                if (m_Model != value)
                {
                    m_Model = value;
                    RaisePropertyChanged("EduModel");
                }
            }
        }

        #region AddNewClassRoomCommand

        /// <summary>
        /// New class room Command
        /// </summary>
        public RelayCommand AddNewClassRoomCommand { get; internal set; }

        /// <summary>
        /// Add new class room command
        /// </summary>
        /// <param name="param"></param>
        public void AddNewClassRoom(object param)
        {
            // Initialize dialog
            CreateNewClassRoomDialog dialog = new CreateNewClassRoomDialog();

            // get view model
            var vm = dialog.DataContext as CreateNewClassRoomDialogViewModel;

            // case vm is not null
            if (vm != null)
            {
                // show dialog
                dialog.ShowDialog();

                var dgResult = vm.CloseWindowFlag;
                if (dgResult == true)
                {
                    if (vm.NewClassRoom != null)
                    {
                        // Add new class room
                        SchoolObject.ListClassRoom.Add(vm.NewClassRoom);
                    }
                }
            }
        }


        #endregion
    }
}
