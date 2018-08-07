using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreateNewSubjectViewModel : ViewModelBase, IManageSchoolBase
    {
        private School m_SchoolObject;
        KaraMongodbModel m_Model;
        private EduSubject m_NewSubject;

        public CreateNewSubjectViewModel()
        {
            // Create new subject
            NewSubject = new EduSubject();

            // Initialize OK button command
            CreateNewCommand = new RelayCommand(CreateNew);

            // Initialie Cancel button command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);
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

        #region CloseWithoutSaveCommand
        /// <summary>
        /// CloseWithoutSaveCommand
        /// </summary>
        public RelayCommand CloseWithoutSaveCommand { get; internal set; }

        /// <summary>
        /// CloseWithoutSave command execution
        /// </summary>
        /// <param name="param"></param>
        private void CloseWithoutSave(object param)
        {
            NewSubject = null;
            CloseWindowFlag = false;
        }
        #endregion

        #region CreateNewCommand
        /// <summary>
        /// Create new command
        /// </summary>
        public RelayCommand CreateNewCommand { get; internal set; }

        /// <summary>
        /// Create new command execution
        /// </summary>
        /// <param name="param"></param>
        private void CreateNew(object param)
        {
            CloseWindowFlag = true;
        }
        #endregion

        #region Change Color command
        public RelayCommand ChangeColorPictureCommand
        {
            get; internal set;
        }

        public void ChangeColorPicture(object param)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            //MyDialog.Color = textBox1.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            //textBox1.ForeColor = MyDialog.Color;
            {
                Console.WriteLine(MyDialog.Color);
                var abc = MyDialog.Color.ToArgb();
                Console.WriteLine(MyDialog.Color.ToArgb());

                Console.WriteLine(Color.FromArgb(abc));
            }

        }
        #endregion
    }
}
