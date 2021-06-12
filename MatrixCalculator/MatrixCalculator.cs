using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixCalculator
{
    public partial class MatrixCalculator : Form
    {
        Matrix matrix1 = new Matrix();
        Matrix matrix2 = new Matrix();
        Matrix result = new Matrix();
        int maxNumberOfRows = 5;
        int maxNumberOfColumns = 5;

        public MatrixCalculator()
        {
            InitializeComponent();
        }

        private void MatrixCalculator_Load(object sender, EventArgs e)
        {

        }

        private void ClearPanelFromInputs(Panel panel, int rows, int columns, String name, String matrixName)
        {
            for (int i = 0; i < maxNumberOfRows; i++)
            {
                for (int j = 0; j < maxNumberOfColumns; j++)
                {
                    panel.Controls.RemoveByKey(name + i + "/" + j);
                }
            }
            panel.Controls.RemoveByKey(matrixName);
        }

        private void AddInputsToPanel(Panel panel, int rows, int columns, String name, String matrixName)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TextBox temp = new TextBox();
                    temp.Name = name + i + "/" + j;
                    temp.Size = new Size(30, 22);
                    temp.Location = new Point(60 + temp.Size.Width * j + j * 6, 60 + temp.Size.Height * i + i * 6);
                    panel.Controls.Add(temp);
                }
            }
            Label label = new Label();
            label.Name = matrixName;
            label.Size = new Size(40, 180);
            label.Location = new Point(0, panel1.Height / 3);
            label.Text = matrixName;
            label.Font = new Font(label.Font.Name, 11.0F, label.Font.Style, label.Font.Unit);
            panel.Controls.Add(label);
        }

        private void GenerateMatrixButtonOnKeyUp(object sender, EventArgs e, String name)
        {
            var rows = 0;
            var columns = 0;
            var inputRows = name == "matrix1" ? Matrix1InputRows : Matrix2InputRows;
            var inputColumns = name == "matrix1" ? Matrix1InputColumns : Matrix2InputColumns;
            var panel = name == "matrix1" ? panel1 : panel2;
            var matrixName = name == "matrix1" ? "A = " : "B = ";

            if (int.TryParse(inputRows.Text, out rows) && int.TryParse(inputColumns.Text, out columns))
            {
                if (rows > maxNumberOfRows || columns > maxNumberOfColumns)
                {
                    MessageBox.Show("The maximum size of the matrix must be " + maxNumberOfRows + "x" + maxNumberOfColumns);
                }
                else
                {
                    ClearPanelFromInputs(panel, maxNumberOfRows, maxNumberOfRows, name, matrixName);

                    AddInputsToPanel(panel, rows, columns, name, matrixName);
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void ClearPanelFromChecksums(Panel panel, String name)
        {
            for (int i = 0; i < maxNumberOfRows; i++)
            {
                for (int j = 0; j < maxNumberOfColumns; j++)
                {
                    panel.Controls.RemoveByKey(name + "ChecksumHorizontal" + i + "/0");
                }
                panel.Controls.RemoveByKey(name + "ChecksumVertical" + "0/" + i);
            }
        }

        private void SetValuesOfMatrixFromInputs(Matrix matrix, Panel panel, int rows, int columns, String name)
        {
            var value = 0d;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Control[] controls = panel.Controls.Find(name + i + "/" + j, true);
                    if (controls.Length > 0)
                    {
                        if (Double.TryParse(controls[0].Text, out value))
                        {
                            matrix.MatrixTable[i, j] = value;
                        }
                    }
                }
            }
        }

        private void GenerateHorizontalChecksums(Matrix matrix, Panel panel, int rows, int columns, String name)
        {
            for (int i = 0; i < rows; i++)
            {
                var result = 0d;
                var value = 0d;

                for (int j = 0; j < columns; j++)
                {
                    Control[] controls = panel.Controls.Find(name + i + "/" + j, true);
                    if (controls.Length > 0)
                    {
                        if (Double.TryParse(controls[0].Text, out value))
                        {
                            result += value;
                        }
                    }
                }
                Label label = new Label();
                label.Name = name + "ChecksumHorizontal" + i + "/0";
                label.Size = new Size(30, 22);
                label.Location = new Point(60 + label.Size.Width * 5 + 6 * 6, 60 + label.Size.Height * i + i * 6);
                matrix.HorizontalCheckSum[i] = result;
                label.Text = matrix.HorizontalCheckSum[i].ToString();
                label.BorderStyle = BorderStyle.FixedSingle;
                label.BackColor = Color.LightGreen;
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
            }
        }

        private void GenerateVerticalChecksums(Matrix matrix, Panel panel, int rows, int columns, String name)
        {
            for (int i = 0; i < columns; i++)
            {
                double result = 0;
                double value = 0;
                for (int j = 0; j < rows; j++)
                {
                    Control[] controls = panel.Controls.Find(name + j + "/" + i, true);
                    if (controls.Length > 0)
                    {
                        if (Double.TryParse(controls[0].Text, out value))
                        {
                            result += value;
                        }
                    }
                }
                Label label = new Label();
                label.Name = name + "ChecksumVertical" + "0/" + i;
                label.Size = new Size(30, 22);
                label.Location = new Point(60 + label.Size.Width * i + i * 6, 60 + label.Size.Height * 5 + 6 * 6);
                matrix.VerticalCheckSum[i] = result;
                label.Text = matrix.VerticalCheckSum[i].ToString();
                label.BorderStyle = BorderStyle.FixedSingle;
                label.BackColor = Color.LightGreen;
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
            }
        }

        private void GenerateChecksumsForMatrixButtonOnClick(object sender, EventArgs e, String name)
        {
            var rows = 0;
            var columns = 0;
            var inputRows = name == "matrix1" ? Matrix1InputRows : Matrix2InputRows;
            var inputColumns = name == "matrix1" ? Matrix1InputColumns : Matrix2InputColumns;
            var panel = name == "matrix1" ? panel1 : panel2;
            var matrix = name == "matrix1" ? matrix1 : matrix2;

            if (int.TryParse(inputRows.Text, out rows) && int.TryParse(inputColumns.Text, out columns))
            {
                if (rows > maxNumberOfRows || columns > maxNumberOfColumns)
                {
                    MessageBox.Show("The maximum size of the matrix must be 5x5");
                }
                else
                {
                    ClearPanelFromChecksums(panel, name);

                    matrix.resizeMatrix(rows, columns);

                    SetValuesOfMatrixFromInputs(matrix, panel, rows, columns, name);

                    GenerateVerticalChecksums(matrix, panel, rows, columns, name);

                    GenerateHorizontalChecksums(matrix, panel, rows, columns, name);
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void MatrixAdditionOrSubtraction(Matrix matrix1, Matrix matrix2, Matrix result, int rows, int columns, bool operation)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.MatrixTable[i, j] = matrix1.MatrixTable[i, j] + matrix2.MatrixTable[i, j] * (operation ? -1 : 1);
                }
            }
        }

        private bool CheckIfChecksumsAreEqual(Matrix matrix1, Matrix matrix2, Matrix result, Panel panel, String name, bool operation)
        {
            var rows = result.Rows;
            var columns = result.Columns;
            var areEqual = true;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix1.VerticalCheckSum[j] + matrix2.VerticalCheckSum[j] * (operation ? -1 : 1) != result.VerticalCheckSum[j])
                    {
                        Control[] controls = panel.Controls.Find(name + "ChecksumVertical" + "0/" + j, true);
                        if (controls.Length > 0)
                        {
                            controls[0].BackColor = Color.Red;
                        }
                        areEqual = false;
                    }
                }
                if (matrix1.HorizontalCheckSum[i] + matrix2.HorizontalCheckSum[i] * (operation ? -1 : 1) != result.HorizontalCheckSum[i])
                {
                    Control[] controls = panel.Controls.Find(name + "ChecksumHorizontal" + i + "/0", true);
                    if (controls.Length > 0)
                    {
                        controls[0].BackColor = Color.Red;
                    }
                    areEqual = false;
                }
            }

            return areEqual;
        }

        private void AddLabelsToPanel(Matrix matrix, Panel panel, int rows, int columns, String name, String matrixName)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Label temp = new Label();
                    temp.Name = name + i + "/" + j;
                    temp.Size = new Size(30, 22);
                    temp.Location = new Point(60 + temp.Size.Width * j + j * 6, 60 + temp.Size.Height * i + i * 6);
                    temp.Text = matrix.MatrixTable[i, j].ToString();
                    temp.Font = new Font(temp.Font.Name, 11.0F, temp.Font.Style, temp.Font.Unit);
                    temp.BorderStyle = BorderStyle.FixedSingle;
                    temp.TextAlign = ContentAlignment.MiddleCenter;
                    panel.Controls.Add(temp);
                }
            }

            Label label = new Label();
            label.Name = matrixName;
            label.Size = new Size(40, 180);
            label.Location = new Point(0, panel1.Height / 3);
            label.Text = matrixName;
            label.Font = new Font(label.Font.Name, 11.0F, label.Font.Style, label.Font.Unit);
            panel.Controls.Add(label);
        }

        private void ClearPanelAndGenerateNewCheksums(Panel panel, int rows, int columns, String name, String matrixName)
        {
            ClearPanelFromInputs(panel, maxNumberOfRows, maxNumberOfRows, name, matrixName);
            ClearPanelFromChecksums(panel, name);
            AddLabelsToPanel(result, panel, rows, columns, name, matrixName);

            GenerateVerticalChecksums(result, panel, rows, columns, name);
            GenerateHorizontalChecksums(result, panel, rows, columns, name);
        }

        private void AdditionOrSubtractionOnClick(object sender, EventArgs e, bool operation)
        {
            if (matrix1.Columns != matrix2.Columns || matrix1.Rows != matrix2.Rows)
            {
                MessageBox.Show("Matrixes must be the same size");
            }
            else
            {
                var rows = matrix1.Rows;
                var columns = matrix1.Columns;
                var name = "result";
                var matrixName = "C = ";
                var panel = panel4;

                result.resizeMatrix(rows, columns);

                MatrixAdditionOrSubtraction(matrix1, matrix2, result, rows, columns, operation);

                ClearPanelAndGenerateNewCheksums(panel, rows, columns, name, matrixName);

                if (CheckIfChecksumsAreEqual(matrix1, matrix2, result, panel, name, operation))
                    MessageBox.Show("Checksums are equal");
                else
                    MessageBox.Show("Checksums are NOT equal");
            }
        }

        private void MatrixMatrixMultiplication(Matrix matrix1, Matrix matrix2, Matrix result, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var temp = 0d;
                    for (int k = 0; k < matrix2.Rows; k++)
                    {
                        temp += matrix1.MatrixTable[i, k] * matrix2.MatrixTable[k, j];
                    }
                    result.MatrixTable[i, j] = temp;
                }
            }
        }

        private void MatrixScalarMultiplication(Matrix matrix1, Matrix matrix2, Matrix result, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.MatrixTable[i, j] = matrix1.MatrixTable[i, j] * matrix2.MatrixTable[0, 0];
                }
            }
        }

        private void MultiplicationOnClick(object sender, EventArgs e)
        {
            if(matrix1.Columns == matrix2.Rows && matrix1.Rows == matrix2.Columns)
            {
                var rows = matrix1.Rows;
                var columns = matrix2.Columns;
                var name = "result";
                var matrixName = "C = ";
                var panel = panel4;

                result.resizeMatrix(rows, columns);

                MatrixMatrixMultiplication(matrix1, matrix2, result, rows, columns);

                ClearPanelAndGenerateNewCheksums(panel, rows, columns, name, matrixName);
            }
            else if(matrix2.Columns == 1 && matrix2.Rows == 1)
            {
                var rows = matrix1.Rows;
                var columns = matrix1.Columns;
                var name = "result";
                var matrixName = "C = ";
                var panel = panel4;

                result.resizeMatrix(rows, columns);

                MatrixScalarMultiplication(matrix1, matrix2, result, rows, columns);

                ClearPanelAndGenerateNewCheksums(panel, rows, columns, name, matrixName);
            }
            else
            {
                MessageBox.Show("You cannot multiply those matrixes");
            }
        }

        private void ReplacementOnClick(object sender, EventArgs e)
        {

        }
    }
}