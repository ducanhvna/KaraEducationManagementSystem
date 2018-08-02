using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel
{
    class ViewModelClassesTabItem:ViewModelBase
    {
        #region Contructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelClassesTabItem()
        {
            // Initialize Manage Command
            ManageClassCollectionsCommand = new RelayCommand(ManageClassCollections);

        }


        #endregion

        #region Show Manage Dialog
        /// <summary>
        /// ShowManageClassCommand
        /// </summary>
        public RelayCommand ManageClassCollectionsCommand
        {
            get; internal set;
        }

        /// <summary>
        /// Show Manage class command execution
        /// </summary>
        /// <param name="param"></param>
        private void ManageClassCollections(object param)
        {
            ManageSchoolItemDialog dialog = new ManageSchoolItemDialog();

            dialog.ShowDialog();
        }

        #endregion
    }
}
