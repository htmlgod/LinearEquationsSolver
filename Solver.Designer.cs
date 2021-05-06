
namespace LinearEquationsSolver
{
    partial class Solver
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSolve = new System.Windows.Forms.Button();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.buttonEditMatrix = new System.Windows.Forms.Button();
            this.textBoxColumns = new System.Windows.Forms.TextBox();
            this.buttonSetSize = new System.Windows.Forms.Button();
            this.textBoxRows = new System.Windows.Forms.TextBox();
            this.groupBoxFileInput = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.radioButtonInputManual = new System.Windows.Forms.RadioButton();
            this.radioButtonInputFromFile = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrecision = new System.Windows.Forms.TextBox();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxFileInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(124, 333);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(75, 23);
            this.buttonSolve.TabIndex = 3;
            this.buttonSolve.Text = "solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.buttonEditMatrix);
            this.groupBoxManual.Controls.Add(this.textBoxColumns);
            this.groupBoxManual.Controls.Add(this.buttonSetSize);
            this.groupBoxManual.Controls.Add(this.textBoxRows);
            this.groupBoxManual.Location = new System.Drawing.Point(12, 38);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(295, 100);
            this.groupBoxManual.TabIndex = 4;
            this.groupBoxManual.TabStop = false;
            // 
            // buttonEditMatrix
            // 
            this.buttonEditMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditMatrix.Enabled = false;
            this.buttonEditMatrix.Location = new System.Drawing.Point(112, 68);
            this.buttonEditMatrix.Name = "buttonEditMatrix";
            this.buttonEditMatrix.Size = new System.Drawing.Size(75, 23);
            this.buttonEditMatrix.TabIndex = 6;
            this.buttonEditMatrix.Text = "Edit Matrix";
            this.buttonEditMatrix.UseVisualStyleBackColor = true;
            this.buttonEditMatrix.Click += new System.EventHandler(this.ButtonEditMatrix_Click);
            // 
            // textBoxColumns
            // 
            this.textBoxColumns.Location = new System.Drawing.Point(112, 39);
            this.textBoxColumns.Name = "textBoxColumns";
            this.textBoxColumns.PlaceholderText = "columns";
            this.textBoxColumns.Size = new System.Drawing.Size(100, 23);
            this.textBoxColumns.TabIndex = 5;
            this.textBoxColumns.TextChanged += new System.EventHandler(this.TextBoxColumns_TextChanged);
            // 
            // buttonSetSize
            // 
            this.buttonSetSize.Location = new System.Drawing.Point(218, 38);
            this.buttonSetSize.Name = "buttonSetSize";
            this.buttonSetSize.Size = new System.Drawing.Size(75, 24);
            this.buttonSetSize.TabIndex = 4;
            this.buttonSetSize.Text = "Set Size";
            this.buttonSetSize.UseVisualStyleBackColor = true;
            this.buttonSetSize.Click += new System.EventHandler(this.ButtonSetSize_Click);
            // 
            // textBoxRows
            // 
            this.textBoxRows.Location = new System.Drawing.Point(6, 39);
            this.textBoxRows.Name = "textBoxRows";
            this.textBoxRows.PlaceholderText = "rows";
            this.textBoxRows.Size = new System.Drawing.Size(100, 23);
            this.textBoxRows.TabIndex = 3;
            this.textBoxRows.TextChanged += new System.EventHandler(this.TextBoxRows_TextChanged);
            // 
            // groupBoxFileInput
            // 
            this.groupBoxFileInput.Controls.Add(this.label1);
            this.groupBoxFileInput.Controls.Add(this.buttonLoadFile);
            this.groupBoxFileInput.Enabled = false;
            this.groupBoxFileInput.Location = new System.Drawing.Point(12, 170);
            this.groupBoxFileInput.Name = "groupBoxFileInput";
            this.groupBoxFileInput.Size = new System.Drawing.Size(295, 100);
            this.groupBoxFileInput.TabIndex = 5;
            this.groupBoxFileInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "filename";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(7, 42);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Open File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
            // 
            // radioButtonInputManual
            // 
            this.radioButtonInputManual.AutoSize = true;
            this.radioButtonInputManual.Checked = true;
            this.radioButtonInputManual.Location = new System.Drawing.Point(13, 13);
            this.radioButtonInputManual.Name = "radioButtonInputManual";
            this.radioButtonInputManual.Size = new System.Drawing.Size(96, 19);
            this.radioButtonInputManual.TabIndex = 6;
            this.radioButtonInputManual.TabStop = true;
            this.radioButtonInputManual.Text = "Manual Input";
            this.radioButtonInputManual.UseVisualStyleBackColor = true;
            this.radioButtonInputManual.CheckedChanged += new System.EventHandler(this.RadioButtonInputManual_CheckedChanged);
            // 
            // radioButtonInputFromFile
            // 
            this.radioButtonInputFromFile.AutoSize = true;
            this.radioButtonInputFromFile.Location = new System.Drawing.Point(13, 145);
            this.radioButtonInputFromFile.Name = "radioButtonInputFromFile";
            this.radioButtonInputFromFile.Size = new System.Drawing.Size(74, 19);
            this.radioButtonInputFromFile.TabIndex = 7;
            this.radioButtonInputFromFile.Text = "File Input";
            this.radioButtonInputFromFile.UseVisualStyleBackColor = true;
            this.radioButtonInputFromFile.CheckedChanged += new System.EventHandler(this.RadioButtonInputFromFile_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Set precision";
            // 
            // textBoxPrecision
            // 
            this.textBoxPrecision.Location = new System.Drawing.Point(100, 274);
            this.textBoxPrecision.Name = "textBoxPrecision";
            this.textBoxPrecision.Size = new System.Drawing.Size(53, 23);
            this.textBoxPrecision.TabIndex = 9;
            this.textBoxPrecision.Text = "2";
            this.textBoxPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Solver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 368);
            this.Controls.Add(this.textBoxPrecision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonInputFromFile);
            this.Controls.Add(this.radioButtonInputManual);
            this.Controls.Add(this.groupBoxFileInput);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.buttonSolve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Solver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solver";
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.groupBoxFileInput.ResumeLayout(false);
            this.groupBoxFileInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxColumns;
        private System.Windows.Forms.Button buttonSetSize;
        private System.Windows.Forms.TextBox textBoxRows;
        private System.Windows.Forms.GroupBox groupBoxFileInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.RadioButton radioButtonInputManual;
        private System.Windows.Forms.RadioButton radioButtonInputFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrecision;
        private System.Windows.Forms.Button buttonEditMatrix;
    }
}

