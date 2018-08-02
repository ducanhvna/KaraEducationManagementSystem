using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreateNewSubjectViewModel : ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;
        private EduSubject m_NewSubject;

        public CreateNewSubjectViewModel()
        {
            NewSubject = new EduSubject();
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

        public EduSubject NewSubject
        {
            get
            {

                return m_NewSubject;
            }
            private set
            {
                if (m_NewSubject != value)
                {
                    m_NewSubject = value;

                    RaisePropertyChanged("NewSubject");
                }
            }
        }
    }
}
