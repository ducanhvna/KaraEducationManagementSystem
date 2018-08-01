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
            FinishNewSchoolDialog dialog = new FinishNewSchoolDialog();

            // Close window
            CloseWindowFlag = true;

            // Get ViewModel
            var viewModel = dialog.DataContext as SchoolFinishNewViewModel;
            if(viewModel == null)
            {
                return;
            }

            // Assign model
            viewModel.NewSchoolObject = NewSchoolObject;

            // Show dialog
            dialog.ShowDialog();
            
        }
    }
}
