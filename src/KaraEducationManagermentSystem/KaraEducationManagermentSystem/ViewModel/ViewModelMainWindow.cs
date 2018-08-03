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
        //private ViewModelSchoolTabItem m_SchoolViewModel;
        //private ViewModelClassesTabItem m_ClassViewModel;
        private School m_SchoolObject;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelMainWindow()
        {
            EduModel = new KaraMongodbModel("", "");
        }


        /// <summary>
        /// SchoolObject
        /// </summary>
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

        /// <summary>
        /// EduModel
        /// </summary>
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
