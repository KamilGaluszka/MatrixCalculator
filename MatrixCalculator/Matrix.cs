using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class Matrix
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double[,] MatrixTable { get; set; }
        public double[] VerticalCheckSum { get; set; }
        public double[] HorizontalCheckSum { get; set; }

        public Matrix()
        {
            Columns = 1;
            Rows = 1;
            MatrixTable = new double[Rows, Columns];
            VerticalCheckSum = new double[Columns];
            HorizontalCheckSum = new double[Rows];
        }

        public void resizeMatrix(int row, int column)
        {
            MatrixTable = new double[row, column];
            VerticalCheckSum = new double[column];
            HorizontalCheckSum = new double[row];
            Rows = row;
            Columns = column;
        }
    }
}
