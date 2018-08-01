using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNS.Helpers;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;

namespace KaraEducationManagermentSystem.ViewModel
{
    class ViewModelSchoolTabItem
    {
        private KaraMongodbModel m_Model;

        public ViewModelSchoolTabItem(KaraMongodbModel model)
        {
            this.m_Model = model;

            // Initialize Create new school Command
            CreateNewSchoolCommand = new RelayCommand(CreateNewSchool);
        }

        #region Create new school

        SchoolCreateNewViewModel CreateNewSchoolViewModel;

        /// <summary>
        /// Command to Create new school
        /// </summary>
        public RelayCommand CreateNewSchoolCommand
        {
            get; private set;
        }


        /// <summary>
        /// Create new school command execution 
        /// </summary>
        /// <param name="param"></param>
        private void CreateNewSchool(object param)
        {

            // Initialize dialog
            CreateNewSchoolDialog frmDialog = new CreateNewSchoolDialog();

            // Get Datacontext
            CreateNewSchoolViewModel = frmDialog.DataContext as SchoolCreateNewViewModel;

            if(CreateNewSchoolViewModel== null)
            {
                return;
            }
            // Assign Model
            CreateNewSchoolViewModel.Model = m_Model;

            // Show dialog
            frmDialog.ShowDialog();

            // Release object
            CreateNewSchoolViewModel = null;
        }
        
        #endregion
    }
}
