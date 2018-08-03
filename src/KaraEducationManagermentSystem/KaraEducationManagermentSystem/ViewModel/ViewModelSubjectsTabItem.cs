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

namespace KaraEducationManagermentSystem.ViewModel
{
    class ViewModelSubjectsTabItem:ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelSubjectsTabItem()
        {
            // Initialize Manager teacher command
            ManageSubjectCollectionsCommand = new RelayCommand(ManageSubjectCollections);
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

        #region Show Manage Dialog
        /// <summary>
        /// ShowManageClassCommand
        /// </summary>
        public RelayCommand ManageSubjectCollectionsCommand
        {
            get; internal set;
        }

        /// <summary>
        /// Show Manage class command execution
        /// </summary>
        /// <param name="param"></param>
        private void ManageSubjectCollections(object param)
        {
            ManageSchoolItemDialog dialog = new ManageSchoolItemDialog();
            // Get view model 

            var vm = dialog.DataContext as ManageSchoolItemsViewModel;
            if (vm != null)

            {
                // Set school Object
                vm.SchoolObject = SchoolObject;

                // Set model
                vm.EduModel = EduModel;

                // Set focus index
                vm.CurrentItemIndex = 0;

                // Show dialog
                dialog.ShowDialog();

                // Do nothing after close

            }
        }
        #endregion
    }
}
