using GridDrawingNS.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GridDrawingNS
{
    public class DContext
    {
        private ObservableCollection<DRow> rows;
        private ObservableCollection<DColumn> columns;
        private DCell[,] cells = new DCell[1000,1000];
        private Grid m_GUI;

        public ObservableCollection<DRow> Rows
        {
            get
            {
                return rows;
            }
            set
            {
                if (rows != value)
                {
                    rows = value;
                }
            }
        }

        public ObservableCollection<DColumn> Columns
        {
            get
            {
                return columns;
            }
            set
            {
                if (columns != value)
                {
                    columns = value;
                }
            }
        }

        public DCell[,] Cells { get
            {
                return cells;
            }
        }
        /// <summary>
        /// ListCells
        /// </summary>
        public ObservableCollection<DCell> ListCells { get; set; } = new ObservableCollection<DCell>();

        public Grid GUI
        {
            get
            {

                return m_GUI;
            }
            internal set
            {

                if (m_GUI != value)
                {
                    m_GUI = value;
                    if (m_GUI != null)
                    {
                        foreach (var cell in ListCells)
                        {
                            m_GUI.Children.Add(cell.Background);

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Total width
        /// </summary>
        public double Width
        {
            get
            {
                double result = 0;
                foreach (var item in Columns)
                {
                    result += item.Width;
                }
                return result;
            }
        }

        /// <summary>
        /// Total Height
        /// </summary>
        public double Height
        {
            get
            {
                double result = 0;
                foreach (var item in Rows)
                {
                    result += item.Height;
                }
                return result;
            }
        }

        public void AddCell(DCell cell)
        {
            ListCells.Add(cell);

            Cells[cell.Row, cell.Column] = cell;

        }
    }
}
