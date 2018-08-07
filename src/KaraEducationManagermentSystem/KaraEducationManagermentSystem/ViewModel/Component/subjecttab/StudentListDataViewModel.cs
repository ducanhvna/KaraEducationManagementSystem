using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraEducationManagermentSystem.View.Dialog;
using KaraEducationManagermentSystem.ViewModel.Dialog;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaraEducationManagermentSystem.ViewModel.Component.subjecttab
{
    class StudentListDataViewModel : ViewModelBase, IManageSchoolBase
    {
        /// <summary>
        /// School Object
        /// </summary>
        private School m_SchoolObject;

        /// <summary>
        /// Model
        /// </summary>
        KaraMongodbModel m_Model;

        /// <summary>
        /// Constructor
        /// </summary>
        public StudentListDataViewModel()
        {
            // Initialize Add new Student command
            AddNewStudentCommand = new RelayCommand(AddNewStudent);
        }
        #region Conditions

        /// <summary>
        /// List Student
        /// </summary>
        public ObservableCollection<EduStudent> ListStudent
        {
            get
            {
                ObservableCollection<EduStudent> result = new ObservableCollection<EduStudent>();
                if (SchoolObject != null)
                {
                    switch (ConditionIndex)
                    {
                        // All
                        case 0:
                            if (SchoolObject!=null&& SchoolObject.UnassignStudent != null)
                            {
                                foreach (var item in SchoolObject.UnassignStudent)
                                {
                                    result.Add(item);
                                }
                            }
                            foreach (var item in SchoolObject.ListClass)
                            {
                                if (item.Students != null)
                                {
                                    foreach (var student in item.Students)
                                    {
                                        result.Add(student);
                                    }
                                }
                            }
                            break;
                        case 1:
                            foreach (var item in SchoolObject.UnassignStudent)
                            {
                                result.Add(item);
                            }
                            break;

                        default:
                            break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// ConditionIndex
        /// </summary>
        private int m_CondtionIndex;

        /// <summary>
        /// Condition Index
        /// </summary>
        public int ConditionIndex
        {
            get
            {
                return m_CondtionIndex;
            }
            set
            {
                if(m_CondtionIndex != value)
                {
                    m_CondtionIndex = value;
                    RaisePropertyChanged("ConditionIndex");
                }
            }
        }


        /// <summary>
        /// List Condition
        /// </summary>
        public ObservableCollection<string> ListCondition
        {
            get
            {
                ObservableCollection<string> result = new ObservableCollection<string>()
                {
                    "All",
                    "Unassign",
                };
                if (SchoolObject != null)
                {
                    if (SchoolObject.ListClass != null)
                    {
                        foreach (var item in SchoolObject.ListClass)
                        {
                            result.Add(item.Name);
                        }
                    } 
                }

                return result;
               
            }
        }
        #endregion
        #region ListStudent display Data
        #endregion

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
                    RaisePropertyChanged("ListCondition");
                    RaisePropertyChanged("ListStudent");
                }
            }
        }

        /// <summary>
        /// subject data
        /// </summary>
        private EduSubject m_SubjectData;

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
                if (m_SubjectData != value)
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


        #region AddNewTeacherCommand


        public RelayCommand AddNewStudentCommand { get; internal set; }

        /// <summary>
        /// AddNewTeacher
        /// </summary>
        /// <param name="param"></param>
        public void AddNewStudent(object param)
        {
            // Initialize dialog
            CreateNewStudentDialog dialog = new CreateNewStudentDialog();

            // Get data context
            var vm = dialog.DataContext as CreateNewStudentViewModel;
            if (vm != null)
            {

                // Show dialog
                dialog.ShowDialog();
                var dgResult = vm.CloseWindowFlag;
                if (dgResult == true)
                {
                    if (vm.NewStudent != null)
                    {
                        if (SchoolObject != null)
                        // Add teacher to school Object
                        {
                            if(SchoolObject.UnassignStudent == null)
                            {
                                SchoolObject.UnassignStudent = new ObservableCollection<EduStudent>();
                            }
                            SchoolObject.UnassignStudent.Add(vm.NewStudent);
                            RaisePropertyChanged("ListStudent");

                        }
                    }
                }
            }
        }

        #endregion
    }
}
