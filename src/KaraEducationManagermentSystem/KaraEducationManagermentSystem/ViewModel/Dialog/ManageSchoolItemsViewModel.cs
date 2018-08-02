﻿using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class ManageSchoolItemsViewModel:ViewModelBase
    {
        /// <summary>
        /// Current selected items
        /// </summary>
        private int m_currentItemIndex;
        public School FocusSchoolObject { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ManageSchoolItemsViewModel()
        {
            // Initialize Subject select command 
            SubjectSelectCommand = new RelayCommand(SubjectSelect);

            // Initialize Class Select command
            ClassSelectCommand = new RelayCommand(ClassSelect);

            // Initialize Class room selected command
            ClassRoomSelectCommand = new RelayCommand(ClassRoomSelect);

            // Initialize Teacher select command
            TeacherSelectCommand = new RelayCommand(TeacherSelect);
        }


        #region Display Area
        /// <summary>
        /// Current Item Index Properties
        /// </summary>
        public int CurrentItemIndex
        {
            get
            {
                return m_currentItemIndex;
            }
            set
            {
                if (m_currentItemIndex != value)
                {
                    m_currentItemIndex = value;
                    RaisePropertyChanged("CurrentItemIndex");
                }
            }
        }
        #endregion

        #region Subject Area

        /// <summary>
        /// Subject Selected Command
        /// </summary>
        public RelayCommand SubjectSelectCommand { get; internal set; }

        /// <summary>
        /// Sublected Select Command execution
        /// </summary>
        /// <param name="param"></param>
        private void SubjectSelect(object param)
        {
            CurrentItemIndex = 0;
        }
        #endregion

        #region Class Area
        /// <summary>
        /// Class Select Command
        /// </summary>
        public RelayCommand ClassSelectCommand { get; internal set; }

        /// <summary>
        /// Click button Class Command execution
        /// </summary>
        /// <param name="param"></param>
        private void ClassSelect(object param)
        {
            CurrentItemIndex = 1;
        }
        #endregion

        #region Class Room Area
        public RelayCommand ClassRoomSelectCommand { get; internal set; }
        private void ClassRoomSelect(object param)
        {
            CurrentItemIndex = 2;
        }
        #endregion


        #region Teacher Area
        public RelayCommand TeacherSelectCommand { get; internal set; }
        private void TeacherSelect(object param)
        {
            CurrentItemIndex = 3;
        }
        #endregion

        #region CloseDialogCommand
        /// <summary>
        /// CloseDialogCommand
        /// </summary>
        public RelayCommand CloseDialogCommand { get; internal set; }

        /// <summary>
        /// CloseDialog
        /// </summary>
        /// <param name="param"></param>
        private void CloseDialog(object param)
        {
            CloseWindowFlag = false;
        }



        #endregion
    }
}