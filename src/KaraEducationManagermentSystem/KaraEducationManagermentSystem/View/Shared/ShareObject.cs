using KaraEducationManagermentSystem.ViewModel;
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
