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
    class SchoolFinishNewViewModel:ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SchoolFinishNewViewModel()
        {
            // Initialize Create new school command
            FinishCreateNewSchoolCommand = new RelayCommand(FinishCreateNewSchool);
        }
        #region Create New School Command

        /// <summary>
        /// Finish Create new school command
        /// </summary>
        public RelayCommand FinishCreateNewSchoolCommand { get; internal set; }

        /// <summary>
        /// NewSchoolObject
        /// </summary>
        public School NewSchoolObject { get; internal set; }

        /// <summary>
        /// Create new schoool command execution
        /// </summary>
        /// <param name="param"></param>
        private void FinishCreateNewSchool(object param)
        {
            CloseWindowFlag = true;

        }

        #endregion
    }
}
