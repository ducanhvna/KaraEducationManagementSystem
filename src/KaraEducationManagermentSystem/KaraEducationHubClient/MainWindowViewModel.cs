using CommonNS.Helpers;
using CommonNS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KaraEducationHubClient.TeacherClient;
using KaraEducationHubClient.ParentsClient;
using KaraEducationHubClient.PresidentClient;
using KaraEducationHubClient.StudentClient;
using KaraEducationHubClient.ServiceReference1;

namespace KaraEducationHubClient
{
    class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            // Init Login command
            LoginCommand = new RelayCommand(Login);

            // Init Cancel command
            CancelCommand = new RelayCommand(Cancel);

            Service1Client client = new Service1Client();

            var result = client.Register("abc", "bcd");

            var result2 = client.GetDataUsingDataContract(new CompositeType());
        }
        #region User type area
        /// <summary>
        /// type index
        /// </summary>
        private int typeIndex;

        /// <summary>
        /// Type Index
        /// </summary>
        public int TypeIndex
        {
            get
            {
                return typeIndex;
            }
            set
            {
                if(typeIndex != value)
                {
                    typeIndex = value;
                    RaisePropertyChanged("TypeIndex");
                }
            }
        }
        #endregion
        #region Login Area

        /// <summary>
        /// Login command
        /// </summary>
        public RelayCommand LoginCommand { get; internal set; }

        /// <summary>
        /// Login command execution
        /// </summary>
        /// <param name="param"></param>
        private void Login(object param)
        {

            switch (typeIndex)
            {
                case 0:
                    OpenAdminDialog();
                    break;
                case 1:
                    OpenPresidentdialog();
                    break;
                case 2:
                    OpenTeacherDialog();
                    break;
                case 3:
                    OpenStudentDialog();
                    break;
                case 4:
                    OpenParentsDialog();
                    break;
                default:
                    break;

            }
            CloseWindowFlag = false;

        }

        private void OpenParentsDialog()
        {
            ParentClientView frm = new ParentClientView();
            frm.Show();
        }

        private void OpenStudentDialog()
        {
            StudentClientView frm = new StudentClientView();
            frm.Show();
        }

        private void OpenTeacherDialog()
        {
            TeacherClientView frm = new TeacherClientView();
            frm.Show();
        }

        private void OpenPresidentdialog()
        {
            PresidentClientView frm = new PresidentClientView();
        }

        private void OpenAdminDialog()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Cancel button Area
        /// <summary>
        /// Cancel command
        /// </summary>
        public RelayCommand CancelCommand { get; internal set; }

        /// <summary>
        /// Cancel command execution
        /// </summary>
        /// <param name="param"></param>
        private void Cancel(object param)
        {
            CloseWindowFlag = false;
        }
        #endregion

    }
}
