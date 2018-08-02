using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class OpenExistedDialogViewModel: ViewModelBase
    {
        private ObservableCollection<School> m_ListSchool;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OpenExistedDialogViewModel()
        {
            Model = ViewModelMainWindow.SharedModel;
        }
        #endregion

        #region Model Area

        /// <summary>
        /// Model
        /// </summary>
        public KaraMongodbModel Model
        {
            get
            {
                return m_Model;
                ;
            }
            internal set
            {
                if (m_Model != value)
                {
                    m_Model = value;
                    ListSchool = Model.SchoolCollection;
                }
            }
        }

        private KaraMongodbModel m_Model;
        private School m_SelectedSchool;

        #endregion
        #region Initalize Display Area
        public ObservableCollection<School> ListSchool
        {
            get
            {
                return m_ListSchool;
            }
            set
            {
                if (m_ListSchool != value)
                {
                    m_ListSchool = value;
                    RaisePropertyChanged("ListSchool");
                }
            }
        }

        /// <summary>
        /// Selected School
        /// </summary>
        public School SelectedSchool
        {
            get
            {
                return m_SelectedSchool;
            }
            set
            {
                if(m_SelectedSchool != value)
                {
                    m_SelectedSchool = value;
                    RaisePropertyChanged("SelectedSchool");
                }
            }
        }


        #endregion

        #region Open Command
        public RelayCommand OpenSchoolCommand { get; internal set; }

        private void OpenSchool (object param)
        {
            CloseWindowFlag = true;
        }
        #endregion

        #region Ignore command
        public RelayCommand IgnoreActionCommand { get; internal set; }

        private void IgnoreAction(object param)
        {
            SelectedSchool = null;
            CloseWindowFlag = false;
        }
    

        #endregion
    }
}
