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

        public MatrixCalculator()
        {
            InitializeComponent();
        }

        private void MatrixCalculator_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateMatrixButtonOnClick(object sender, EventArgs e, String name)
        {
            int rows = 0, columns = 0;
            if(int.TryParse(Matrix1InputRows.Text, out rows) && int.TryParse(Matrix1InputColumns.Text, out columns))
            {
                if(rows > 5 || columns > 5)
                {
                    MessageBox.Show("The maximum size of the matrix must be 5x5");
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if(name == "matrix1")
                            {
                                panel1.Controls.RemoveByKey(name + i + "/" + j);
                            }
                            else
                            {
                                panel2.Controls.RemoveByKey(name + i + "/" + j);
                            }
                        }
                    }
                    if(name == "matrix1")
                    {
                        panel1.Controls.RemoveByKey("A = ");
                    }
                    else
                    {
                        panel2.Controls.RemoveByKey("B = ");
                    }
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            TextBox temp = new TextBox();
                            temp.Name = name + i + "/" + j;
                            temp.Size = new Size(30, 22);
                            temp.Location = new Point(60 + temp.Size.Width * j + j * 6, 60 + temp.Size.Height * i + i * 6);
                            panel1.Controls.Add(temp);
                        }
                        Label label = new Label();
                        if(name == "matrix1")
                        {
                            label.Name = "A = ";
                            label.Size = new Size(40, 180);
                            label.Location = new Point(0, panel1.Height / 3);
                            label.Text = "A = [";
                            label.Font = new Font(label.Font.Name, 11.0F, label.Font.Style, label.Font.Unit);
                            panel1.Controls.Add(label);
                        }
                        else
                        {
                            label.Name = "B = ";
                            label.Size = new Size(40, 180);
                            label.Location = new Point(0, panel2.Height / 3);
                            label.Text = "B = [";
                            label.Font = new Font(label.Font.Name, 11.0F, label.Font.Style, label.Font.Unit);
                            panel2.Controls.Add(label);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void GenerateChecksumsMatrix1ButtonOnClick(object sender, EventArgs e)
        {
            int rows = 0, columns = 0;
            if (int.TryParse(Matrix1InputRows.Text, out rows) && int.TryParse(Matrix1InputColumns.Text, out columns))
            {
                if (rows > 5 || columns > 5)
                {
                    MessageBox.Show("The maximum size of the matrix must be 5x5");
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            panel1.Controls.RemoveByKey("Matrix1ChecksumVertical" + i + "/0");
                        }
                        panel1.Controls.RemoveByKey("Matrix1ChecksumHorizontal" + "0/" + i);
                    }
                    matrix1.resizeMatrix(rows, columns);
                    for (int i = 0; i < rows; i++)
                    {
                        double result = 0;
                        double value = 0;
                        for (int j = 0; j < columns; j++)
                        {
                            Control[] controls = panel1.Controls.Find("Matrix1" + i + "/" + j, true);
                            if(controls.Length > 0)
                            {
                                if (Double.TryParse(controls[0].Text, out value))
                                {
                                    matrix1.MatrixTable[i, j] = value;
                                    result += value;
                                }
                            }
                        }
                        Label label = new Label();
                        label.Name = "Matrix1ChecksumVertical" + i + "/0";
                        label.Size = new Size(30, 22);
                        label.Location = new Point(60 + label.Size.Width * 5 + 6 * 6, 60 + label.Size.Height * i + i * 6);
                        matrix1.HorizontalCheckSum[i] = result;
                        label.Text = matrix1.HorizontalCheckSum[i].ToString();
                        panel1.Controls.Add(label);
                    }
                    for(int i = 0; i < columns; i++)
                    {
                        double result = 0;
                        double value = 0;
                        for (int j = 0; j < rows; j++)
                        {
                            Control[] controls = panel1.Controls.Find("Matrix1" + j + "/" + i, true);
                            if (controls.Length > 0)
                            {
                                if (Double.TryParse(controls[0].Text, out value))
                                {
                                    result += value;
                                }
                            }
                        }
                        Label label = new Label();
                        label.Name = "Matrix1ChecksumHorizontal" + "0/" + i;
                        label.Size = new Size(30, 22);
                        label.Location = new Point(60 + label.Size.Width * i + i * 6, 60 + label.Size.Height * 5 + 6 * 6);
                        matrix1.VerticalCheckSum[i] = result;
                        label.Text = matrix1.VerticalCheckSum[i].ToString();
                        panel1.Controls.Add(label);
                    }
                }
            }
            else
            {
                MessageBox.Show("Rows or columns are not a number");
            }
        }

        private void AdditionOnClick(object sender, EventArgs e)
        {
            if(matrix1.Columns != matrix2.Columns || matrix1.Rows != matrix2.Rows)
            {
                MessageBox.Show("Matrixes must be the same size");
            }
            else
            {

            }
        }

        private void SubtractionOnClick(object sender, EventArgs e)
        {

        }

        private void MultiplicationOnClick(object sender, EventArgs e)
        {

        }

        private void ReplacementOnClick(object sender, EventArgs e)
        {

        }
    }
}
