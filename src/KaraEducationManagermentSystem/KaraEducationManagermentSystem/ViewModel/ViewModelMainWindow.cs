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
    class ViewModelMainWindow : ViewModelBase
    {
        /// <summary>
        /// model
        /// </summary>
        private KaraMongodbModel m_Model = null;

        public static KaraMongodbModel SharedModel = null;
        /// <summary>
        /// view model of School tab
        /// </summary>
        private ViewModelSchoolTabItem m_SchoolViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelMainWindow()
        {
            m_Model = new KaraMongodbModel("", "");

            SharedModel = m_Model;
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
                        m_SchoolViewModel.Model = m_Model;
                    }
                    RaisePropertyChanged("SchoolViewModel");
                }
            }
        }
    }
}
