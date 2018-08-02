using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonNS.Helpers;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;
using System.Collections.ObjectModel;
using CommonNS.ViewModel;

namespace KaraEducationManagermentSystem.ViewModel
{
    class ViewModelSchoolTabItem:ViewModelBase, IManageSchoolBase
    {
        public ViewModelSchoolTabItem()
        {



            // Initialize Create new school Command
            CreateNewSchoolCommand = new RelayCommand(CreateNewSchool);

            // Initalize Open exited school
            OpenSchoolCommand = new RelayCommand(OpenSchool);

          

        }

        #region Initalize Display Area
      public ObservableCollection<School> ListSchool { get
            {
                return m_ListSchool;
            }
            set
            {
                if(m_ListSchool != value)
                {
                    m_ListSchool = value;
                    RaisePropertyChanged("ListSchool");
                }
            }
        }
        #endregion
        #region Create new school

       SchoolCreateNewViewModel CreateNewSchoolViewModel;
        private ObservableCollection<School> m_ListSchool;
        private KaraMongodbModel m_Model;
        private School m_SchoolObject;

        /// <summary>
        /// Command to Create new school
        /// </summary>
        public RelayCommand CreateNewSchoolCommand
        {
            get; private set;
        }

        /// <summary>
        /// Model
        /// </summary>
        public KaraMongodbModel EduModel
        {
            get
            {
                return m_Model;
                ;
            }
            set
            {
                if (m_Model != value)
                {
                    m_Model = value;
                    if (m_Model != null)
                    {
                        ListSchool = m_Model.SchoolCollection;

                    }
                }
            }
        }

    

        /// <summary>
        /// Create new school command execution 
        /// </summary>
        /// <param name="param"></param>
        private async void CreateNewSchool(object param)
        {

            // Initialize dialog
            CreateNewSchoolDialog frmDialog = new CreateNewSchoolDialog();

            // Get Datacontext
            CreateNewSchoolViewModel = frmDialog.DataContext as SchoolCreateNewViewModel;

            // Set new School Object
           

            if (CreateNewSchoolViewModel== null)
            {
                return;
            }
       

            

            // Show dialog
            frmDialog.ShowDialog();
            if (CreateNewSchoolViewModel.CloseWindowFlag == true)
            {
                if (CreateNewSchoolViewModel.SchoolObject != null)
                {
                    //await EduModel.AsyncInsertOne(NewSchoolObject);

                    await EduModel.AsyncInsertOne(CreateNewSchoolViewModel.SchoolObject);
                    ListSchool = EduModel.SchoolCollection;
                }
            }
            // Release object
            CreateNewSchoolViewModel = null;
        }

        #endregion

        #region OpenSchool Command
        public RelayCommand OpenSchoolCommand { get; internal set; }
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
      

        private void OpenSchool(object param)
        {
            OpenExistedDialog dialog = new OpenExistedDialog();

            var dgViewModel = dialog.DataContext as OpenExistedDialogViewModel;
            if (dgViewModel != null)
            {
                dgViewModel.EduModel = EduModel;

                dialog.ShowDialog();

                if (dgViewModel.CloseWindowFlag== true)
                {
                    // Add code here
                }
            }
        }
        #endregion
    }
}
