using CommonNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KaraEducationManagermentSystem.View
{
    /// <summary>
    /// Interaction logic for SchoolTabItemContent.xaml
    /// </summary>
    public partial class SchoolTabItemContent : UserControl
    {
        public SchoolTabItemContent()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Set Language for this coponent
        /// </summary>
        internal void SetLanguageForComponent()
        {
            Global.SetLanguageForComponent(this);
        }
    }
}
