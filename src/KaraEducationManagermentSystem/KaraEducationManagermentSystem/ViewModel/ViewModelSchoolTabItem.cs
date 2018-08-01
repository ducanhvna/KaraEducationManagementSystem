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
    class ViewModelSchoolTabItem:ViewModelBase
    {
        public ViewModelSchoolTabItem()
        {



            // Initialize Create new school Command
            CreateNewSchoolCommand = new RelayCommand(CreateNewSchool);

           
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

        public School NewSchoolObject { get; internal set; }

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
            NewSchoolObject = new School();

            if (CreateNewSchoolViewModel== null)
            {
                return;
            }
            // Assign Model
            CreateNewSchoolViewModel.NewSchoolObject = NewSchoolObject;


            // Show dialog
            frmDialog.ShowDialog();

            if(NewSchoolObject!= null)
            {
                await Model.AsyncInsertOne(NewSchoolObject);

                ListSchool = Model.SchoolCollection;
            }
            // Release object
            CreateNewSchoolViewModel = null;
            NewSchoolObject = null;
        }
        
        #endregion
    }
}
