using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MatrixCalculator
{
    public partial class MatrixCalculator : Form
    {
        private readonly Matrix _matrix1 = new Matrix();
        private readonly Matrix _matrix2 = new Matrix();
        private readonly Matrix _result = new Matrix();
        private readonly int _maxNumberOfRows = 5;
        private readonly int _maxNumberOfColumns = 5;

        public MatrixCalculator()
        {
            InitializeComponent();
        }

        private void MatrixCalculator_Load(object sender, EventArgs e)
        {

        }

        private void ClearPanelFromInputs(Panel panel, MatrixType name, string matrixName)
        {
            for (int i = 0; i < _maxNumberOfRows; i++)
            {
                for (int j = 0; j < _maxNumberOfColumns; j++)
                {
                    panel.Controls.RemoveByKey(name + i + "/" + j);
                }
            }
            panel.Controls.RemoveByKey(matrixName);
        }

        private void AddInputsToPanel(Panel panel, int rows, int columns, MatrixType name, string matrixName)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var temp = new TextBox
                    {
                        Name = name + i + "/" + j,
                        Size = new Size(30, 22)
                    };
                    temp.Location = new Point(60 + temp.Size.Width * j + j * 6, 60 + temp.Size.Height * i + i * 6);
                    panel.Controls.Add(temp);
                }
            }
            var label = new Label
            {
                Name = matrixName,
                Size = new Size(40, 180),
                Location = new Point(0, panel1.Height / 3),
                Text = matrixName
            };
            panel.Controls.Add(label);
        }

        private void GenerateMatrixButtonOnKeyUp(object sender, EventArgs e, MatrixType name)
        {
            var inputRows = name == MatrixType.Matrix1 ? Matrix1InputRows : Matrix2InputRows;
            var inputColumns = name == MatrixType.Matrix1 ? Matrix1InputColumns : Matrix2InputColumns;
            var panel = name == MatrixType.Matrix1 ? panel1 : panel2;
            var matrixName = name == MatrixType.Matrix1 ? "A = " : "B = ";

            if (int.TryParse(inputRows.Text, out var rows) && int.TryParse(inputColumns.Text, out var columns))
            {
                if (rows > _maxNumberOfRows || columns > _maxNumberOfColumns)
                {
                    MessageBox.Show("The maximum size of the matrix must be " + _maxNumberOfRows + "x" + _maxNumberOfColumns);
                }
                else if (rows < 1 || columns < 1)
                {
                    MessageBox.Show("Matrix must not be less than 1x1");
                }
                else
                {
                    ClearPanelFromInputs(panel, name, matrixName);

                    AddInputsToPanel(panel, rows, columns, name, matrixName);
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void ClearPanelFromChecksums(Panel panel, MatrixType name)
        {
            for (int i = 0; i < _maxNumberOfRows; i++)
            {
                for (int j = 0; j < _maxNumberOfColumns; j++)
                {
                    panel.Controls.RemoveByKey(name + "ChecksumHorizontal" + i + "/0");
                }
                panel.Controls.RemoveByKey(name + "ChecksumVertical" + "0/" + i);
            }
        }

        private bool SetValuesOfMatrixFromInputs(Matrix matrix, Panel panel, int rows, int columns, MatrixType name)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Control[] controls = panel.Controls.Find(name + i + "/" + j, true);
                    if (controls.Length > 0)
                    {
                        if (Double.TryParse(controls[0].Text, out double value))
                        {
                            matrix.MatrixTable[i, j] = value;
                        }
                        else
                        {
                            MessageBox.Show("Value is not a number");
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void GenerateHorizontalChecksums(Matrix matrix, Panel panel, int rows, int columns, MatrixType name)
        {
            for (int i = 0; i < rows; i++)
            {
                var result = 0d;
                for (int j = 0; j < columns; j++)
                {
                    result += matrix.MatrixTable[i, j];
                }
                Label label = new Label
                {
                    Name = name + "ChecksumHorizontal" + i + "/0",
                    Size = new Size(30, 22)
                };
                label.Location = new Point(60 + label.Size.Width * 5 + 6 * 6, 60 + label.Size.Height * i + i * 6);
                matrix.HorizontalCheckSum[i] = result;
                label.Text = matrix.HorizontalCheckSum[i].ToString();
                label.BorderStyle = BorderStyle.FixedSingle;
                label.BackColor = Color.LightGreen;
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
            }
        }

        private void GenerateVerticalChecksums(Matrix matrix, Panel panel, int rows, int columns, MatrixType name)
        {
            for (int i = 0; i < columns; i++)
            {
                double result = 0;
                for (int j = 0; j < rows; j++)
                {
                    result += matrix.MatrixTable[j, i];
                }
                var label = new Label
                {
                    Name = name + "ChecksumVertical" + "0/" + i,
                    Size = new Size(30, 22)
                };
                label.Location = new Point(60 + label.Size.Width * i + i * 6, 60 + label.Size.Height * 5 + 6 * 6);
                matrix.VerticalCheckSum[i] = result;
                label.Text = matrix.VerticalCheckSum[i].ToString();
                label.BorderStyle = BorderStyle.FixedSingle;
                label.BackColor = Color.LightGreen;
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
            }
        }

        private void GenerateChecksumsForMatrixButtonOnClick(object sender, EventArgs e, MatrixType name)
        {
            var inputRows = name == MatrixType.Matrix1 ? Matrix1InputRows : Matrix2InputRows;
            var inputColumns = name == MatrixType.Matrix1 ? Matrix1InputColumns : Matrix2InputColumns;
            var panel = name == MatrixType.Matrix1 ? panel1 : panel2;
            var matrix = name == MatrixType.Matrix1 ? _matrix1 : _matrix2;

            if (int.TryParse(inputRows.Text, out int rows) && int.TryParse(inputColumns.Text, out int columns))
            {
                if (rows > _maxNumberOfRows || columns > _maxNumberOfColumns)
                {
                    MessageBox.Show("The maximum size of the matrix must be 5x5");
                }
                else if (rows < 1 || columns < 1)
                {
                    MessageBox.Show("Matrix must not be less than 1x1");
                }
                else
                {
                    ClearPanelFromChecksums(panel, name);

                    matrix.resizeMatrix(rows, columns);

                    if(SetValuesOfMatrixFromInputs(matrix, panel, rows, columns, name))
                    {
                        GenerateVerticalChecksums(matrix, panel, rows, columns, name);

                        GenerateHorizontalChecksums(matrix, panel, rows, columns, name);
                    }                    
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

        private bool CheckIfChecksumsAreEqual(Matrix matrix1, Matrix matrix2, Matrix result, Panel panel, MatrixType name, bool operation)
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
                            controls[0].Text = result.VerticalCheckSum[j].ToString();
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
                        controls[0].Text = result.HorizontalCheckSum[i].ToString();
                    }
                    areEqual = false;
                }
            }

            return areEqual;
        }

        private void AddLabelsToPanel(Matrix matrix, Panel panel, int rows, int columns, MatrixType name, string matrixName)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Label temp = new Label
                    {
                        Name = name + i + "/" + j,
                        Size = new Size(30, 22)
                    };
                    temp.Location = new Point(60 + temp.Size.Width * j + j * 6, 60 + temp.Size.Height * i + i * 6);
                    temp.Text = matrix.MatrixTable[i, j].ToString();
                    temp.BorderStyle = BorderStyle.FixedSingle;
                    temp.TextAlign = ContentAlignment.MiddleCenter;
                    panel.Controls.Add(temp);
                }
            }

            Label label = new Label
            {
                Name = matrixName,
                Size = new Size(40, 180),
                Location = new Point(0, panel1.Height / 3),
                Text = matrixName
            };
            panel.Controls.Add(label);
        }

        private void ClearPanelAndGenerateNewCheksums(Matrix matrix, Panel panel, int rows, int columns, MatrixType name, string matrixName)
        {
            ClearPanelFromInputs(panel, name, matrixName);
            ClearPanelFromChecksums(panel, name);
            AddLabelsToPanel(matrix, panel, rows, columns, name, matrixName);

            GenerateVerticalChecksums(matrix, panel, rows, columns, name);
            GenerateHorizontalChecksums(matrix, panel, rows, columns, name);
        }

        private void AdditionOrSubtractionOnClick(object sender, EventArgs e, bool operation)
        {
            if (_matrix1.Columns != _matrix2.Columns || _matrix1.Rows != _matrix2.Rows)
            {
                MessageBox.Show("Matrixes must be the same size");
            }
            else
            {
                var rows = _matrix1.Rows;
                var columns = _matrix1.Columns;
                var name = MatrixType.Result;
                var matrixName = "C = ";
                var panel = panel4;

                _result.resizeMatrix(rows, columns);

                MatrixAdditionOrSubtraction(_matrix1, _matrix2, _result, rows, columns, operation);

                ClearPanelAndGenerateNewCheksums(_result, panel, rows, columns, name, matrixName);

                if (CheckIfChecksumsAreEqual(_matrix1, _matrix2, _result, panel, name, operation))
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
            if (_matrix1.Columns == _matrix2.Rows && _matrix1.Rows == _matrix2.Columns)
            {
                var rows = _matrix1.Rows;
                var columns = _matrix2.Columns;
                var name = MatrixType.Result;
                var matrixName = "C = ";
                var panel = panel4;

                _result.resizeMatrix(rows, columns);

                MatrixMatrixMultiplication(_matrix1, _matrix2, _result, rows, columns);

                ClearPanelAndGenerateNewCheksums(_result, panel, rows, columns, name, matrixName);
            }
            else if (_matrix2.Columns == 1 && _matrix2.Rows == 1)
            {
                var rows = _matrix1.Rows;
                var columns = _matrix1.Columns;
                var name = MatrixType.Result;
                var matrixName = "C = ";
                var panel = panel4;

                _result.resizeMatrix(rows, columns);

                MatrixScalarMultiplication(_matrix1, _matrix2, _result, rows, columns);

                ClearPanelAndGenerateNewCheksums(_result, panel, rows, columns, name, matrixName);
            }
            else
            {
                MessageBox.Show("You cannot multiply those matrixes");
            }
        }

        private bool LoadDataToMatrix(Matrix matrix, int rows, int columns, string[] data)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(int.TryParse(data[i * columns + j + 2], out int value))
                    {
                        matrix.MatrixTable[i, j] = value;
                    }
                    else
                    {
                        MessageBox.Show("Value is not a number");
                        return false;
                    }
                }
            }
            return true;
        }

        private void LoadMatrixOnClick(object sender, EventArgs e, MatrixType name)
        {
            fileMatrix.ShowDialog();

            var fileName = fileMatrix.FileName;
            string[] fileContent;

            try
            {
                fileContent = File.ReadAllLines(fileName);
            }
            catch
            {
                return;
            }

            if (int.TryParse(fileContent[0], out var rows) && int.TryParse(fileContent[1], out var columns))
            {
                if (rows > _maxNumberOfRows || columns > _maxNumberOfColumns)
                {
                    MessageBox.Show("The maximum size of the matrix must be 5x5");
                }
                else if (rows < 1 || columns < 1)
                {
                    MessageBox.Show("Matrix must not be less than 1x1");
                }
                else
                {
                    var inputRows = name == MatrixType.Matrix1 ? Matrix1InputRows : Matrix2InputRows;
                    var inputColumns = name == MatrixType.Matrix1 ? Matrix1InputColumns : Matrix2InputColumns;
                    var panel = name == MatrixType.Matrix1 ? panel1 : panel2;
                    var matrix = name == MatrixType.Matrix1 ? _matrix1 : _matrix2;
                    var matrixName = name == MatrixType.Matrix1 ? "A = " : "B = ";

                    matrix.resizeMatrix(rows, columns);

                    if (LoadDataToMatrix(matrix, rows, columns, fileContent))
                    {
                        ClearPanelAndGenerateNewCheksums(matrix, panel, rows, columns, name, matrixName);

                        inputRows.Text = rows.ToString();
                        inputColumns.Text = columns.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void IncorrectVerticalChecksumOnClick(object sender, EventArgs e)
        {
            ClearPanelAndGenerateNewCheksums(_result, panel4, _result.Rows, _result.Columns, MatrixType.Result, "C =");

            for(int i = 0; i < _result.Columns; i++)
            {
                _result.VerticalCheckSum[i]++;
            }

            if (CheckIfChecksumsAreEqual(_matrix1, _matrix2, _result, panel4, MatrixType.Result, false))
                MessageBox.Show("Checksums are equal");
            else
                MessageBox.Show("Checksums are NOT equal");
        }

        private void IncorrectHorizontalChecksumOnClick(object sender, EventArgs e)
        {
            ClearPanelAndGenerateNewCheksums(_result, panel4, _result.Rows, _result.Columns, MatrixType.Result, "C =");

            for (int i = 0; i < _result.Rows; i++)
            {
                _result.HorizontalCheckSum[i]++;
            }

            if (CheckIfChecksumsAreEqual(_matrix1, _matrix2, _result, panel4, MatrixType.Result, false))
                MessageBox.Show("Checksums are equal");
            else
                MessageBox.Show("Checksums are NOT equal");
        }

        private void IncorrectRandomChecksumOnClick(object sender, EventArgs e)
        {
            ClearPanelAndGenerateNewCheksums(_result, panel4, _result.Rows, _result.Columns, MatrixType.Result, "C =");

            var random = new Random();
            _result.VerticalCheckSum[random.Next(0, _result.Columns)]++;
            _result.HorizontalCheckSum[random.Next(0, _result.Rows)]++;

            if (CheckIfChecksumsAreEqual(_matrix1, _matrix2, _result, panel4, MatrixType.Result, false))
                MessageBox.Show("Checksums are equal");
            else
                MessageBox.Show("Checksums are NOT equal");
        }

        private void SaveResultOnClick(object sender, EventArgs e)
        {
            SaveFileDialog saveResult = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                FileName = "result.txt",
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt"
            };

            if (saveResult.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = saveResult.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.WriteLine(_result.Rows);
                sw.WriteLine(_result.Columns);

                for (int i = 0; i < _result.Rows; i++)
                {
                    for (int j = 0; j < _result.Columns; j++)
                    {
                        sw.WriteLine(_result.MatrixTable[i, j]);
                    }
                }

                sw.Close();
                fileStream.Close();
            }
        }
    }
}