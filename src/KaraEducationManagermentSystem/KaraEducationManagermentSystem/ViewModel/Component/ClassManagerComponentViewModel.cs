using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Component
{
    class ClassManagerComponentViewModel : ViewModelBase, IManageSchoolBase
    {
        /// <summary>
        /// school object
        /// </summary>
        private School m_SchoolObject;
        KaraMongodbModel m_Model;

        /// <summary>
        /// ClassManagerComponentViewModel
        /// </summary>
        public ClassManagerComponentViewModel()
        {
            NewClassCommand = new RelayCommand(NewClass);

            // Init new class command

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

        #region New Class

        /// <summary>
        /// New class command
        /// </summary>
        public RelayCommand NewClassCommand { get; internal set; }

        /// <summary>
        /// NewClass
        /// </summary>
        /// <param name="param"></param>
        private void NewClass(object param)
        {
            CreateNewClassDialog view = new CreateNewClassDialog();

            var dgViewModel = view.DataContext as CreateNewClassDialogViewModel;

            if(dgViewModel != null)
            {
                 view.ShowDialog();
                var dgResult = dgViewModel.CloseWindowFlag;
                if (dgResult == true)
                {
                    if (dgViewModel.NewClass != null)
                    {
                        SchoolObject.ListClass.Add(dgViewModel.NewClass);
                    }

                }
            }
        }
        #endregion 
    }
}
