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
using GridDrawingNS;
using GridDrawingNS.Data;

namespace KaraEducationManagermentSystem.ViewModel
{
    class ViewModelSchoolTabItem:ViewModelBase, IManageSchoolBase
    {
        ViewModelMainWindow m_Parent = null;
        public ViewModelMainWindow Parent
        {
            get
            {
                return m_Parent;
            }
            internal set
            {
                if (m_Parent != value)
                {
                    m_Parent = value;
                    if (m_Parent.EduModel != null)
                    {
                        //

                    }
                }
            }
        }
        public ViewModelSchoolTabItem()
        {

            // Initialize Create new school Command
            CreateNewSchoolCommand = new RelayCommand(CreateNewSchool);

            // Initalize Open exited school
            OpenSchoolCommand = new RelayCommand(OpenSchool);

            // Initizlize TimeTable Context
            InitalizeTimeTableContext();

        }

        /// <summary>
        /// InitalizeTimeTableContext
        /// </summary>
        private void InitalizeTimeTableContext()
        {
            TimeTableContext = new DContext();

            // Create List Columns
            TimeTableContext.Columns = new ObservableCollection<DColumn>
            {
              

            };

            // Add Label Column
            DColumn labelColum = new DColumn { Width = 20 };
            TimeTableContext.Columns.Add(labelColum);

            // Add 7x12 column for content
            for(var i = 0;i<84;i++)
            {
                var contentColumn = new DColumn() { Width = 30};
                TimeTableContext.Columns.Add(contentColumn);
            }

            TimeTableContext.Rows = new ObservableCollection<DRow>()
            {
            };
            // Add row for Day
            var dayRow = new DRow() { Height = 20 };
            TimeTableContext.Rows.Add(dayRow);
            // Add row for index
            var indexRow = new DRow() { Height = 15 };
            TimeTableContext.Rows.Add(indexRow);

            // Add 50 content Row
            for (var i = 0; i < 50; i++)
            {
                var contentRow = new DRow() { Height = 30 };
                TimeTableContext.Rows.Add(contentRow);
            }

            // Add Monday
            var mondayCell = new DCell(0, 1, 1, 12);
            mondayCell.BackgroundContent = "Monday";

            TimeTableContext.AddCell(mondayCell);
            AddLessonIndex(1, 12);

            // Add Tuesday
            var tuesdayCell = new DCell(0, 13, 1, 12);
            tuesdayCell.BackgroundContent = "Tuesday";
            TimeTableContext.AddCell(tuesdayCell);
            AddLessonIndex(13, 12);
            // Add Wednesday
            var wednesDayCell = new DCell(0, 25, 1, 12);
            wednesDayCell.BackgroundContent = "Wesnesday";
            TimeTableContext.AddCell(wednesDayCell);
            AddLessonIndex(25,12);


            // Add Thursday
            var thursdayCell = new DCell(0, 37, 1, 12);
            thursdayCell.BackgroundContent = "Thursday";
            TimeTableContext.AddCell(thursdayCell);
            AddLessonIndex(37, 12);

            // Add Friday
            var fridayCell = new DCell(0, 49, 1, 12);
            fridayCell.BackgroundContent = "Friday";
            TimeTableContext.AddCell(fridayCell);
            AddLessonIndex(49, 12);

            // Add Saturday
            var saturdayCell = new DCell(0, 61, 1, 12);
            saturdayCell.BackgroundContent = "Saturday";
            TimeTableContext.AddCell(saturdayCell);
            AddLessonIndex(61, 12);

            // Add Sunday
            var sundayCell = new DCell(0, 73, 1, 12);
            sundayCell.BackgroundContent = "Sunday";
            TimeTableContext.AddCell(sundayCell);
            AddLessonIndex(73, 12);

            //var dumyCell = new DCell(1, 1, 1, 1);

            //TimeTableContext.AddCell(dumyCell);
            // InsertBackgroudForAllTimeItems
            InsertBackgroudForAllTimeItems();
        }

        /// <summary>
        /// InsertBackgroudForAllTimeItems
        /// </summary>
        private void InsertBackgroudForAllTimeItems()
        {
            // row form 2 to end
            for(var i = 2;i<TimeTableContext.Rows.Count;i++)
            {
                // column from 1 to end
                for(var j= 1;j<TimeTableContext.Columns.Count;j++)
                {
                    var contentCell = new DCell(i, j, 1, 1);
                    contentCell.BackgroundContent = "";
                    TimeTableContext.AddCell(contentCell);
                }
            }
        }
        private void AddLessonIndex(int startColumn, int numberofCell)
        {
            for(var i= 0;i<numberofCell;i++ )
            {
                var columnIndex = startColumn + i;
                var lessonHeader = new DCell(1, columnIndex, 1, 1);
                lessonHeader.BackgroundContent = (i+1).ToString();

                TimeTableContext.AddCell(lessonHeader);
            }
        }

        #region Initalize Display Area

        #endregion
        #region Create new school

        SchoolCreateNewViewModel CreateNewSchoolViewModel;
        private DContext m_TimeTableContext;




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
                return Parent.EduModel;
            }
            set
            {
                if (Parent.EduModel != value)
                {
                    Parent.EduModel = value;
                    if (Parent.EduModel != null)
                    {
                        

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
                    SchoolObject = CreateNewSchoolViewModel.SchoolObject;
                }
            }
            // Release object
            CreateNewSchoolViewModel = null;
        }

        #endregion

        #region OpenSchool Command
        /// <summary>
        /// OpenSchoolCommand
        /// </summary>
        public RelayCommand OpenSchoolCommand { get; internal set; }
        public School SchoolObject
        {
            get {
                return Parent?.SchoolObject;
            }
            set
            {
                if(Parent.SchoolObject != value)
                {
                    Parent.SchoolObject = value;
                    RaisePropertyChanged("SchoolObject");

                }
            }
           
        
        }
      
        public DContext TimeTableContext {
            get {
                return m_TimeTableContext;
            } set {
                if(m_TimeTableContext != value)
                {
                    m_TimeTableContext = value;
                    RaisePropertyChanged("TimeTableContext");
                }
            }
        }

        /// <summary>
        /// Open School
        /// </summary>
        /// <param name="param"></param>
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
                    if(dgViewModel.SchoolObject != null)
                    {
                        SchoolObject = dgViewModel.SchoolObject;
                    }
                }
            }
        }
        #endregion

        #region OverView area
        public string SchoolName
        {
            get
            {
                return SchoolObject?.Name;
            }
        }
        #endregion
    }
}
