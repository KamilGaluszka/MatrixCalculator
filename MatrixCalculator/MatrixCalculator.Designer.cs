﻿
namespace MatrixCalculator
{
    partial class MatrixCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateMatrix1Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Matrix1InputColumns = new System.Windows.Forms.TextBox();
            this.Matrix1InputRows = new System.Windows.Forms.TextBox();
            this.Matrix1Columns = new System.Windows.Forms.Label();
            this.Matrix1Rows = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Replacement = new System.Windows.Forms.Button();
            this.Multiplication = new System.Windows.Forms.Button();
            this.Subtraction = new System.Windows.Forms.Button();
            this.Addition = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Matrix2Rows = new System.Windows.Forms.Label();
            this.GenerateMatrix2Button = new System.Windows.Forms.Button();
            this.Matrix2Columns = new System.Windows.Forms.Label();
            this.Matrix2InputRows = new System.Windows.Forms.TextBox();
            this.Matrix2InputColumns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.GenerateMatrix1Button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Matrix1InputColumns);
            this.panel1.Controls.Add(this.Matrix1InputRows);
            this.panel1.Controls.Add(this.Matrix1Columns);
            this.panel1.Controls.Add(this.Matrix1Rows);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 350);
            this.panel1.TabIndex = 0;
            // 
            // GenerateMatrix1Button
            // 
            this.GenerateMatrix1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GenerateMatrix1Button.Location = new System.Drawing.Point(240, 3);
            this.GenerateMatrix1Button.Name = "GenerateMatrix1Button";
            this.GenerateMatrix1Button.Size = new System.Drawing.Size(105, 54);
            this.GenerateMatrix1Button.TabIndex = 5;
            this.GenerateMatrix1Button.Text = "Generate checksums";
            this.GenerateMatrix1Button.UseVisualStyleBackColor = true;
            this.GenerateMatrix1Button.Click += new System.EventHandler((sender, e) => this.GenerateChecksumsButtonOnClick(sender, e, "matrix1"));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(102, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = ",";
            // 
            // Matrix1InputColumns
            // 
            this.Matrix1InputColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix1InputColumns.Location = new System.Drawing.Point(121, 13);
            this.Matrix1InputColumns.Name = "Matrix1InputColumns";
            this.Matrix1InputColumns.Size = new System.Drawing.Size(30, 22);
            this.Matrix1InputColumns.TabIndex = 3;
            this.Matrix1InputColumns.Text = "1";
            this.Matrix1InputColumns.KeyUp += new System.Windows.Forms.KeyEventHandler((sender, e) => this.GenerateMatrixButtonOnKeyUp(sender, e, "matrix1"));
            // 
            // Matrix1InputRows
            // 
            this.Matrix1InputRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix1InputRows.Location = new System.Drawing.Point(66, 13);
            this.Matrix1InputRows.Name = "Matrix1InputRows";
            this.Matrix1InputRows.Size = new System.Drawing.Size(30, 22);
            this.Matrix1InputRows.TabIndex = 2;
            this.Matrix1InputRows.Text = "1";
            this.Matrix1InputRows.KeyUp += new System.Windows.Forms.KeyEventHandler((sender, e) => this.GenerateMatrixButtonOnKeyUp(sender, e, "matrix1"));
            // 
            // Matrix1Columns
            // 
            this.Matrix1Columns.AutoSize = true;
            this.Matrix1Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix1Columns.Location = new System.Drawing.Point(157, 13);
            this.Matrix1Columns.Name = "Matrix1Columns";
            this.Matrix1Columns.Size = new System.Drawing.Size(79, 20);
            this.Matrix1Columns.TabIndex = 1;
            this.Matrix1Columns.Text = "] Columns";
            // 
            // Matrix1Rows
            // 
            this.Matrix1Rows.AutoSize = true;
            this.Matrix1Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix1Rows.Location = new System.Drawing.Point(3, 13);
            this.Matrix1Rows.Name = "Matrix1Rows";
            this.Matrix1Rows.Size = new System.Drawing.Size(57, 20);
            this.Matrix1Rows.TabIndex = 0;
            this.Matrix1Rows.Text = "Rows [";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Matrix2InputColumns);
            this.panel2.Controls.Add(this.Matrix2InputRows);
            this.panel2.Controls.Add(this.Matrix2Columns);
            this.panel2.Controls.Add(this.GenerateMatrix2Button);
            this.panel2.Controls.Add(this.Matrix2Rows);
            this.panel2.Location = new System.Drawing.Point(438, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 350);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Replacement);
            this.panel3.Controls.Add(this.Multiplication);
            this.panel3.Controls.Add(this.Subtraction);
            this.panel3.Controls.Add(this.Addition);
            this.panel3.Location = new System.Drawing.Point(368, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 350);
            this.panel3.TabIndex = 1;
            // 
            // Replacement
            // 
            this.Replacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Replacement.Location = new System.Drawing.Point(6, 220);
            this.Replacement.Name = "Replacement";
            this.Replacement.Size = new System.Drawing.Size(50, 36);
            this.Replacement.TabIndex = 6;
            this.Replacement.Text = "<- ->";
            this.Replacement.UseVisualStyleBackColor = true;
            this.Replacement.Click += new System.EventHandler(this.ReplacementOnClick);
            // 
            // Multiplication
            // 
            this.Multiplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Multiplication.Location = new System.Drawing.Point(6, 178);
            this.Multiplication.Name = "Multiplication";
            this.Multiplication.Size = new System.Drawing.Size(50, 36);
            this.Multiplication.TabIndex = 5;
            this.Multiplication.Text = "*";
            this.Multiplication.UseVisualStyleBackColor = true;
            this.Multiplication.Click += new System.EventHandler(this.MultiplicationOnClick);
            // 
            // Subtraction
            // 
            this.Subtraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Subtraction.Location = new System.Drawing.Point(6, 136);
            this.Subtraction.Name = "Subtraction";
            this.Subtraction.Size = new System.Drawing.Size(50, 36);
            this.Subtraction.TabIndex = 4;
            this.Subtraction.Text = "-";
            this.Subtraction.UseVisualStyleBackColor = true;
            this.Subtraction.Click += new System.EventHandler(this.SubtractionOnClick);
            // 
            // Addition
            // 
            this.Addition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Addition.Location = new System.Drawing.Point(6, 94);
            this.Addition.Name = "Addition";
            this.Addition.Size = new System.Drawing.Size(50, 36);
            this.Addition.TabIndex = 3;
            this.Addition.Text = "+";
            this.Addition.UseVisualStyleBackColor = true;
            this.Addition.Click += new System.EventHandler(this.AdditionOnClick);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(12, 368);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 248);
            this.panel4.TabIndex = 2;
            // 
            // Matrix2Rows
            // 
            this.Matrix2Rows.AutoSize = true;
            this.Matrix2Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix2Rows.Location = new System.Drawing.Point(3, 13);
            this.Matrix2Rows.Name = "Matrix2Rows";
            this.Matrix2Rows.Size = new System.Drawing.Size(57, 20);
            this.Matrix2Rows.TabIndex = 6;
            this.Matrix2Rows.Text = "Rows [";
            // 
            // GenerateMatrix2Button
            // 
            this.GenerateMatrix2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GenerateMatrix2Button.Location = new System.Drawing.Point(240, 3);
            this.GenerateMatrix2Button.Name = "GenerateMatrix2Button";
            this.GenerateMatrix2Button.Size = new System.Drawing.Size(105, 54);
            this.GenerateMatrix2Button.TabIndex = 6;
            this.GenerateMatrix2Button.Text = "Generate checksums";
            this.GenerateMatrix2Button.UseVisualStyleBackColor = true;
            this.GenerateMatrix2Button.Click += new System.EventHandler((sender, e) => this.GenerateChecksumsButtonOnClick(sender, e, "matrix2"));
            // 
            // Matrix2Columns
            // 
            this.Matrix2Columns.AutoSize = true;
            this.Matrix2Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix2Columns.Location = new System.Drawing.Point(157, 13);
            this.Matrix2Columns.Name = "Matrix2Columns";
            this.Matrix2Columns.Size = new System.Drawing.Size(79, 20);
            this.Matrix2Columns.TabIndex = 6;
            this.Matrix2Columns.Text = "] Columns";
            // 
            // Matrix2InputRows
            // 
            this.Matrix2InputRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix2InputRows.Location = new System.Drawing.Point(66, 13);
            this.Matrix2InputRows.Name = "Matrix2InputRows";
            this.Matrix2InputRows.Size = new System.Drawing.Size(30, 22);
            this.Matrix2InputRows.TabIndex = 6;
            this.Matrix2InputRows.Text = "1";
            this.Matrix2InputRows.KeyUp += new System.Windows.Forms.KeyEventHandler((sender, e) => this.GenerateMatrixButtonOnKeyUp(sender, e, "matrix2"));
            // 
            // Matrix2InputColumns
            // 
            this.Matrix2InputColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Matrix2InputColumns.Location = new System.Drawing.Point(121, 13);
            this.Matrix2InputColumns.Name = "Matrix2InputColumns";
            this.Matrix2InputColumns.Size = new System.Drawing.Size(30, 22);
            this.Matrix2InputColumns.TabIndex = 6;
            this.Matrix2InputColumns.Text = "1";
            this.Matrix2InputColumns.KeyUp += new System.Windows.Forms.KeyEventHandler((sender, e) => this.GenerateMatrixButtonOnKeyUp(sender, e, "matrix2"));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(102, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = ",";
            // 
            // MatrixCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 628);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MatrixCalculator";
            this.Text = "MatrixCalculator";
            this.Load += new System.EventHandler(this.MatrixCalculator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Subtraction;
        private System.Windows.Forms.Button Addition;
        private System.Windows.Forms.Button Replacement;
        private System.Windows.Forms.Button Multiplication;
        private System.Windows.Forms.Button GenerateMatrix1Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Matrix1InputColumns;
        private System.Windows.Forms.TextBox Matrix1InputRows;
        private System.Windows.Forms.Label Matrix1Columns;
        private System.Windows.Forms.Label Matrix1Rows;
        private System.Windows.Forms.Button GenerateMatrix2Button;
        private System.Windows.Forms.Label Matrix2Rows;
        private System.Windows.Forms.TextBox Matrix2InputColumns;
        private System.Windows.Forms.TextBox Matrix2InputRows;
        private System.Windows.Forms.Label Matrix2Columns;
        private System.Windows.Forms.Label label2;
    }
}