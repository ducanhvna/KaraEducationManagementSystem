using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Component.subjecttab
{
    class SubjectDetailViewModel: ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

        /// <summary>
        /// Constructor
        /// </summary>
        public SubjectDetailViewModel()
        {
            
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
        /// Subject Data
        /// </summary>
        private  EduSubject m_SubjectData;

        /// <summary>
        /// Model
        /// </summary>
        public EduSubject Model
        {
            get
            {
                return m_SubjectData;
            }
            set
            {
                if(m_SubjectData != value)
                {
                    m_SubjectData = value;
                    RaisePropertyChanged("Model");
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
