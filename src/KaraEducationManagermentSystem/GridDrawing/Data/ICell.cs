using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GridDrawingNS.Data
{
    public enum FieldEnum
    {
        Row,
        Column
    }

    public class CellChangedEventArgs : EventArgs
    {
        public int Value { get; set; }
        public FieldEnum Field { get; set; }
    }
    public class DCell
    {
        public event EventHandler Changed;

        protected virtual void OnCellChanged(EventArgs e)
        {
            EventHandler handler = Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private int row;

        private int column;
        public Border BackGround { get => backGroud; set => backGroud = value; }
        public int Row { get => row; set {
                row = value;
                OnCellChanged(new CellChangedEventArgs()
                {
                    Value = row,
                    Field = FieldEnum.Row
                });
            } }
        public int Column { get => column; set => column = value; }

        private Border backGroud;
    }
}
