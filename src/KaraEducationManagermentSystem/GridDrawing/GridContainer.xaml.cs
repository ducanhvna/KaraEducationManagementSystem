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

namespace GridDrawingNS
{
    /// <summary>
    /// Interaction logic for GridContainer.xaml
    /// </summary>
    public partial class GridContainer : UserControl
    {
        private int m_numberOfRow;

        public GridContainer()
        {
            InitializeComponent();

        }

        public int NumberofRow
        {
            get
            {
                return m_numberOfRow;
            }
            set
            {
                if(m_numberOfRow != value)
                { m_numberOfRow = value; }
            }
        }
    }
}
