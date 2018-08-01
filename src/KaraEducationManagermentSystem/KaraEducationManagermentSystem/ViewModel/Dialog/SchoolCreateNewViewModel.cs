using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class SchoolCreateNewViewModel : ViewModelBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SchoolCreateNewViewModel()
        {
            // Initialize NextDialog command
            NextDialogCommand = new RelayCommand(NextDialog);
        }
        #region Display Area
        public string Name { get
            {
                
                return NewSchoolObject?.Name;
            }
            set
            {
                if(NewSchoolObject.Name != value)
                {
                    NewSchoolObject.Name = value;
                    RaisePropertyChanged("NewSchoolObject");
                }
            }
        }

        public string AcademicYear
        {
            get
            {
                return NewSchoolObject?.AcademicYear;
            }
            set
            {
                if(NewSchoolObject?.AcademicYear != value)
                {
                    NewSchoolObject.AcademicYear = value;
                    RaisePropertyChanged("AcademicYear");
                }
            }
        }
        #endregion
        /// <summary>
        /// Next Dialog command
        /// </summary>
        public RelayCommand NextDialogCommand { get; internal set; }
        public School NewSchoolObject { get; internal set; }

        /// <summary>
        /// Next Dialog Command execution
        /// </summary>
        /// <param name="param"></param>
        public void NextDialog(object param)
        {
            // Initialize Dialog 
            CreateSchoolItemsDialog dialog = new CreateSchoolItemsDialog();

            // Close window
            CloseWindowFlag = true;

            // Get ViewModel
            var viewModel = dialog.DataContext as SchoolCreateItemsViewModel;
            if(viewModel == null)
            {
                return;
            }

            // Assign model
            viewModel.NewSchoolObject = NewSchoolObject;

            NewSchoolObject = null;

            // Show dialog
            var result = dialog.ShowDialog();


        }
    }
}
