using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GridDrawingNS
{
    public static class DGridShare
    {
        #region DContext to GridContainder
        /// <summary>
        /// GridContextProperty
        /// </summary>
        public static readonly DependencyProperty GridContextProperty =
        DependencyProperty.RegisterAttached(
        "GridContext",
        typeof(DContext),
        typeof(DGridShare),
        new PropertyMetadata(GridContextChanged));

        /// <summary>
        /// SubjectObjectChanged
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void GridContextChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var uc = d as GridContainer;
         
            if (uc != null)
            {
                uc.GridContext = e.NewValue as DContext;
            }
        }

        /// <summary>
        /// SetSubjectObject
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetGridContext(UserControl target, DContext value)
        {
            target.SetValue(GridContextProperty, value);
        }
        #endregion

    }
}
