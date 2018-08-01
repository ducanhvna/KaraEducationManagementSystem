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

            // Initialize School View model
            SchoolViewModel = new ViewModelSchoolTabItem(m_Model);
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
                    RaisePropertyChanged("SchoolViewModel");
                }
            }
        }
    }
}
