using GridDrawingNS.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private DContext gridContext;

        public ObservableCollection<DRow> Rows
        {
            get
            {
                return GridContext.Rows;
            }
           
        }

        private void SeparateRow()
        {
            mainGrid.RowDefinitions.Clear();
            foreach (var row in Rows)
            {
                var rowDefinition = new RowDefinition();
                rowDefinition.Height =new GridLength(row.Height);
                mainGrid.RowDefinitions.Add(rowDefinition);
            }

        }

        public GridContainer()
        {
            InitializeComponent();

        }

        public ObservableCollection<DColumn> Columns
        {
            get
            {
                return GridContext.Columns;
            }
           
        }

        public DContext GridContext { get => gridContext; set { gridContext = value;

                SeparateColumn();

                SeparateRow();
                

                this.Width = gridContext.Width;

                this.Height = gridContext.Height;

                gridContext.GUI = this.mainGrid;

                

               
            }
        }

        private void SeparateColumn()
        {
            mainGrid.ColumnDefinitions.Clear();
            foreach (var column in Columns)
            {
                var columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(column.Width);
                mainGrid.ColumnDefinitions.Add(columnDefinition);
            }
        }

       
    }
}
