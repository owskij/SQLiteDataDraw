namespace PicturePlotDB
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTo = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.drawBtn = new System.Windows.Forms.Button();
            this.sensorsListCB = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.TempCB = new System.Windows.Forms.CheckBox();
            this.LaCur4CB = new System.Windows.Forms.CheckBox();
            this.LaCur3CB = new System.Windows.Forms.CheckBox();
            this.LaCur2CB = new System.Windows.Forms.CheckBox();
            this.LaShiftCB = new System.Windows.Forms.CheckBox();
            this.LaCur1CB = new System.Windows.Forms.CheckBox();
            this.LaCur0CB = new System.Windows.Forms.CheckBox();
            this.LaCurCB = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.drawBtn);
            this.splitContainer1.Panel2.Controls.Add(this.sensorsListCB);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1134, 741);
            this.splitContainer1.SplitterDistance = 939;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 672);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(933, 672);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.logBox);
            this.panel1.Location = new System.Drawing.Point(3, 681);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 57);
            this.panel1.TabIndex = 2;
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(933, 57);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 716);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "АвтоОбновление";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelTo);
            this.groupBox1.Controls.Add(this.datePickerFrom);
            this.groupBox1.Controls.Add(this.labelFrom);
            this.groupBox1.Controls.Add(this.datePickerTo);
            this.groupBox1.Location = new System.Drawing.Point(2, 628);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите временной диапазон";
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(6, 53);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(22, 13);
            this.labelTo.TabIndex = 7;
            this.labelTo.Text = "До";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerFrom.CustomFormat = "dd.MM.yyyy H:mm:ss";
            this.datePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFrom.Location = new System.Drawing.Point(32, 21);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(148, 20);
            this.datePickerFrom.TabIndex = 2;
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(6, 27);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(20, 13);
            this.labelFrom.TabIndex = 4;
            this.labelFrom.Text = "От";
            // 
            // datePickerTo
            // 
            this.datePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerTo.CustomFormat = "dd.MM.yyyy H:mm:ss";
            this.datePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTo.Location = new System.Drawing.Point(34, 47);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(146, 20);
            this.datePickerTo.TabIndex = 5;
            // 
            // drawBtn
            // 
            this.drawBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.drawBtn.Location = new System.Drawing.Point(113, 712);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(75, 23);
            this.drawBtn.TabIndex = 0;
            this.drawBtn.Text = "Рисовать";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.drawBtn_Click);
            // 
            // sensorsListCB
            // 
            this.sensorsListCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorsListCB.CheckOnClick = true;
            this.sensorsListCB.Location = new System.Drawing.Point(2, 3);
            this.sensorsListCB.MultiColumn = true;
            this.sensorsListCB.Name = "sensorsListCB";
            this.sensorsListCB.Size = new System.Drawing.Size(186, 484);
            this.sensorsListCB.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.TempCB);
            this.groupBox.Controls.Add(this.LaCur4CB);
            this.groupBox.Controls.Add(this.LaCur3CB);
            this.groupBox.Controls.Add(this.LaCur2CB);
            this.groupBox.Controls.Add(this.LaShiftCB);
            this.groupBox.Controls.Add(this.LaCur1CB);
            this.groupBox.Controls.Add(this.LaCur0CB);
            this.groupBox.Controls.Add(this.LaCurCB);
            this.groupBox.Location = new System.Drawing.Point(2, 493);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(186, 129);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Выберите тип данных для построения";
            // 
            // TempCB
            // 
            this.TempCB.AutoSize = true;
            this.TempCB.Location = new System.Drawing.Point(86, 99);
            this.TempCB.Name = "TempCB";
            this.TempCB.Size = new System.Drawing.Size(86, 17);
            this.TempCB.TabIndex = 14;
            this.TempCB.Text = "Temperature";
            this.TempCB.UseVisualStyleBackColor = true;
            // 
            // LaCur4CB
            // 
            this.LaCur4CB.AutoSize = true;
            this.LaCur4CB.Location = new System.Drawing.Point(86, 76);
            this.LaCur4CB.Name = "LaCur4CB";
            this.LaCur4CB.Size = new System.Drawing.Size(60, 17);
            this.LaCur4CB.TabIndex = 13;
            this.LaCur4CB.Text = "LaCur4";
            this.LaCur4CB.UseVisualStyleBackColor = true;
            // 
            // LaCur3CB
            // 
            this.LaCur3CB.AutoSize = true;
            this.LaCur3CB.Location = new System.Drawing.Point(86, 53);
            this.LaCur3CB.Name = "LaCur3CB";
            this.LaCur3CB.Size = new System.Drawing.Size(60, 17);
            this.LaCur3CB.TabIndex = 12;
            this.LaCur3CB.Text = "LaCur3";
            this.LaCur3CB.UseVisualStyleBackColor = true;
            // 
            // LaCur2CB
            // 
            this.LaCur2CB.AutoSize = true;
            this.LaCur2CB.Location = new System.Drawing.Point(86, 31);
            this.LaCur2CB.Name = "LaCur2CB";
            this.LaCur2CB.Size = new System.Drawing.Size(60, 17);
            this.LaCur2CB.TabIndex = 11;
            this.LaCur2CB.Text = "LaCur2";
            this.LaCur2CB.UseVisualStyleBackColor = true;
            // 
            // LaShiftCB
            // 
            this.LaShiftCB.AutoSize = true;
            this.LaShiftCB.Location = new System.Drawing.Point(14, 100);
            this.LaShiftCB.Name = "LaShiftCB";
            this.LaShiftCB.Size = new System.Drawing.Size(59, 17);
            this.LaShiftCB.TabIndex = 10;
            this.LaShiftCB.Text = "LaShift";
            this.LaShiftCB.UseVisualStyleBackColor = true;
            // 
            // LaCur1CB
            // 
            this.LaCur1CB.AutoSize = true;
            this.LaCur1CB.Location = new System.Drawing.Point(14, 77);
            this.LaCur1CB.Name = "LaCur1CB";
            this.LaCur1CB.Size = new System.Drawing.Size(60, 17);
            this.LaCur1CB.TabIndex = 9;
            this.LaCur1CB.Text = "LaCur1";
            this.LaCur1CB.UseVisualStyleBackColor = true;
            // 
            // LaCur0CB
            // 
            this.LaCur0CB.AutoSize = true;
            this.LaCur0CB.Location = new System.Drawing.Point(14, 54);
            this.LaCur0CB.Name = "LaCur0CB";
            this.LaCur0CB.Size = new System.Drawing.Size(60, 17);
            this.LaCur0CB.TabIndex = 8;
            this.LaCur0CB.Text = "LaCur0";
            this.LaCur0CB.UseVisualStyleBackColor = true;
            // 
            // LaCurCB
            // 
            this.LaCurCB.AutoSize = true;
            this.LaCurCB.Checked = true;
            this.LaCurCB.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.LaCurCB.Location = new System.Drawing.Point(14, 31);
            this.LaCurCB.Name = "LaCurCB";
            this.LaCurCB.Size = new System.Drawing.Size(54, 17);
            this.LaCurCB.TabIndex = 7;
            this.LaCurCB.Text = "LaCur";
            this.LaCurCB.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 741);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.CheckedListBox sensorsListCB;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox TempCB;
        private System.Windows.Forms.CheckBox LaCur4CB;
        private System.Windows.Forms.CheckBox LaCur3CB;
        private System.Windows.Forms.CheckBox LaCur2CB;
        private System.Windows.Forms.CheckBox LaShiftCB;
        private System.Windows.Forms.CheckBox LaCur1CB;
        private System.Windows.Forms.CheckBox LaCur0CB;
        private System.Windows.Forms.CheckBox LaCurCB;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox logBox;

    }
}

