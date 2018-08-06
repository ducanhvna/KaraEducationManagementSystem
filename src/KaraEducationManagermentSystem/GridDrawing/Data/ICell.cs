using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace GridDrawingNS.Data
{
    /// <summary>
    /// FieldEnum
    /// </summary>
    public enum FieldEnum
    {
        Row,
        Column
    }

    /// <summary>
    /// CellChangedEventArgs
    /// </summary>
    public class CellChangedEventArgs : EventArgs
    {
        public int Value { get; set; }
        public FieldEnum Field { get; set; }
    }

    /// <summary>
    /// DCell
    /// </summary>
    public class DCell
    {
        public DCell()
        {
            InitializeBackground();
        }
        public DCell(int row, int column, int rowSpan, int colSpan)
        {
            Row = row;
            Column = column;
            RowSpan = rowSpan;
            ColSpan = colSpan;
            InitializeBackground();
        }

        /// <summary>
        /// Initialize Background
        /// </summary>
        private void InitializeBackground()
        {
            // Create new grid
            mainGrid = new Grid();

            // Set background
            mainGrid.Background = Brushes.LightGray;

            // Create textblock
            backgroundTextBlock = new TextBlock();

            // Set Alignment
            backgroundTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            backgroundTextBlock.VerticalAlignment = VerticalAlignment.Center;


            // Add textblock to grid
            mainGrid.Children.Add(backgroundTextBlock);

            // Set back ground child
            Background.Child = mainGrid;

            // Set border brush
            Background.BorderBrush = Brushes.Gray;

            // Set border thickness
            Background.BorderThickness = new Thickness(1);
        }

        public event EventHandler Changed;

        protected virtual void OnCellChanged(EventArgs e)
        {
            EventHandler handler = Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        public Grid Parent;

        /// <summary>
        /// Background
        /// </summary>
        public Border Background { get => background; set => background = value; }
        public int Row
        {
            get => Grid.GetRow(Background); set
            {
                Grid.SetRow(Background, value);

            }
        }

        /// <summary>
        /// Column
        /// </summary>
        public int Column
        {
            get => Grid.GetColumn(Background); set
            {
                Grid.SetColumn(Background, value);

            }
        }

        /// <summary>
        /// Colspan
        /// </summary>
        public int ColSpan
        {
            get => Grid.GetColumnSpan(Background); set
            {
                Grid.SetColumnSpan(Background, value);
            }
        }

        /// <summary>
        /// Row span
        /// </summary>
        public int RowSpan { get => Grid.GetRowSpan(Background); set
            {
                Grid.SetColumnSpan(Background, value);
            }
        }

        public string BackgroundContent
        {
            get
            {
                return backgroundTextBlock.Text;
            }
            set
            {
                if (backgroundTextBlock.Text != value)
                {
                    backgroundTextBlock.Text = value;
                }
            }
        }

        private Border background = new Border();
        private Grid mainGrid;
        private TextBlock backgroundTextBlock;

    }
}
