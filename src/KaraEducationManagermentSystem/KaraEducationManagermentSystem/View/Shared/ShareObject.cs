﻿using KaraEducationManagermentSystem.View.Component.subjecttab;
using KaraEducationManagermentSystem.ViewModel;
using KaraEducationManagermentSystem.ViewModel.Component.subjecttab;
using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KaraEducationManagermentSystem.View.Shared
{
    public static class ShareObject
    {
        #region EduSubject to SubjectDetailView
        internal static readonly DependencyProperty SubjectObjectProperty =
        DependencyProperty.RegisterAttached(
        "SubjectObject",
        typeof(EduSubject),
        typeof(ShareObject),
        new PropertyMetadata(SubjectObjectChanged));

        private static void SubjectObjectChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var uc = d as SubjectDetailView;
            var vm = uc.DataContext as SubjectDetailViewModel;
            if (vm != null)
            {
                vm.Model = e.NewValue as EduSubject;
            }
        }

        /// <summary>
        /// SetSubjectObject
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        internal static void SetSubjectObject(SubjectDetailView target, SubjectDetailViewModel value)
        {
            target.SetValue(SubjectObjectProperty, value);
        }
        #endregion

        #region School to User control

        public static readonly DependencyProperty SchoolObjectProperty =
        DependencyProperty.RegisterAttached(
        "SchoolObject",
        typeof(School),
        typeof(ShareObject),
        new PropertyMetadata(SchoolObjectChanged));

        private static void SchoolObjectChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var uc = d as UserControl;
            var vm = uc.DataContext as IManageSchoolBase;
            if (vm != null)
            {
                vm.SchoolObject = e.NewValue as School;
            }
        }
        public static void SetSchoolObject(UserControl target, School value)
        {
            target.SetValue(SchoolObjectProperty, value);
        }

        #endregion

        #region Root to User control

        internal static readonly DependencyProperty RootObjectProperty =
        DependencyProperty.RegisterAttached(
        "RootObject",
        typeof(ViewModelMainWindow),
        typeof(ShareObject),
        new PropertyMetadata(RootObjectChanged));

        internal static void RootObjectChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var uc = d as UserControl;
            var vm = uc.DataContext as ViewModelSchoolTabItem;
            if (vm != null)
            {
                vm.Parent = e.NewValue as ViewModelMainWindow;
            }
        }
        internal static void SetRootObject(UserControl target, ViewModelMainWindow value)
        {
            target.SetValue(RootObjectProperty, value);
        }

        #endregion

        #region Model to UserControl

        public static readonly DependencyProperty ModelObjectProperty =
        DependencyProperty.RegisterAttached(
        "ModelObject",
        typeof(KaraMongodbModel),
        typeof(ShareObject),
        new PropertyMetadata(ModelObjectChanged));

        private static void ModelObjectChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var uc = d as UserControl;
            var vm = uc.DataContext as IManageSchoolBase;
            if (vm != null)
            {
                vm.EduModel = e.NewValue as KaraMongodbModel;
            }
        }
        public static void SetModelObject(UserControl target, KaraMongodbModel value)
        {
            target.SetValue(ModelObjectProperty, value);
        }
        #endregion
    }
}
