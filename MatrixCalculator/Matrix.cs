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
            double[,] tempMatrixTable = MatrixTable;
            double[] tempVerticalCheckSum = VerticalCheckSum;
            double[] tempHorizontalCheckSum = HorizontalCheckSum;
            MatrixTable = new double[row, column];
            VerticalCheckSum = new double[column];
            HorizontalCheckSum = new double[row];
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    MatrixTable[i, j] = tempMatrixTable[i, j];
                    VerticalCheckSum[j] = tempVerticalCheckSum[j];
                }
                HorizontalCheckSum[i] = tempHorizontalCheckSum[i];
            }
            Rows = row;
            Columns = column;
        }
    }
}
