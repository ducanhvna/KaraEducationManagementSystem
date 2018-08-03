using CommonNS.Helpers;
using CommonNS.ViewModel;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel.Dialog
{
    class CreatenewLessonDialogViewModel:ViewModelBase
    {
        public EduLesson NewLesson { get; internal set; }
        public CreatenewLessonDialogViewModel()
        {
            NewLesson = new EduLesson();

            // Initialize Cancel button command
            CloseWithoutSaveCommand = new RelayCommand(CloseWithoutSave);

            // Initialize Ok button command
            CreateNewCommand = new RelayCommand(CreateNew);
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
            NewLesson = null;
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
    }
}
