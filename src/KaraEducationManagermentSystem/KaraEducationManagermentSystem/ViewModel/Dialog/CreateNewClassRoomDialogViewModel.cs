using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreateNewClassRoomDialogViewModel: ViewModelBase
    {
        public EduClassRoom NewClassRoom { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateNewClassRoomDialogViewModel()
        {
            // Initialize new class room
            NewClassRoom = new EduClassRoom();

            // Initialize Ok button command
            CreateNewCommand = new RelayCommand(CreateNew);

            // Initialize Cancel button command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);

            // Initialize ChangeColorPictureCommand
            ChangeColorPictureCommand = new RelayCommand(ChangeColorPicture);
        }
        #region CloseWithoutSaveCommand
        /// <summary>
        /// CloseWithoutSaveCommand
        /// </summary>
        public RelayCommand CloseWithoutSaveCommand { get; internal set; }

        /// <summary>
        /// CloseWithoutSave
        /// </summary>
        /// <param name="param"></param>
        private void CloseWithoutSave(object param)
        {
            NewClassRoom = null;
            CloseWindowFlag = false;
        }
        #endregion

        #region CreateNewCommand
        public RelayCommand CreateNewCommand { get; internal set; }

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
