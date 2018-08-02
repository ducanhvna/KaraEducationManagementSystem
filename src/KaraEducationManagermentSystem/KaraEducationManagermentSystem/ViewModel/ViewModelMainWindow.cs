using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNS.ViewModel;
using KaraMongoModelNS;

namespace KaraEducationManagermentSystem.ViewModel
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    class ViewModelMainWindow : ViewModelBase, IManageSchoolBase
    {
        /// <summary>
        /// model
        /// </summary>
        private KaraMongodbModel m_Model = null;

 
        /// <summary>
        /// view model of School tab
        /// </summary>
        private ViewModelSchoolTabItem m_SchoolViewModel;
        private School m_SchoolObject = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelMainWindow()
        {
            EduModel = new KaraMongodbModel("", "");

           
            // Initialize School View model
            //SchoolViewModel = new ViewModelSchoolTabItem();

            // Assign model
            //SchoolViewModel.Model = m_Model;
        }

        /// <summary>
        /// View Model for school Tab
        /// </summary>
        public ViewModelSchoolTabItem SchoolViewModel
        {
            get
            {
                return m_SchoolViewModel;
            }
            set
            {
                if(m_SchoolViewModel != value)
                {
                    m_SchoolViewModel = value;
                    if (m_SchoolViewModel != null)
                    {
                        m_SchoolViewModel.EduModel = m_Model;
                    }
                    RaisePropertyChanged("SchoolViewModel");
                }
            }
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
    }
}
