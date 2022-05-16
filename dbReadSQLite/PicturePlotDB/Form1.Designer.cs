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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.firstOpenDB_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTo = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.drawBtn = new System.Windows.Forms.Button();
            this.sensorsListCB = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.LaCurShiftRB = new System.Windows.Forms.RadioButton();
            this.LaCur4RB = new System.Windows.Forms.RadioButton();
            this.LaCur3RB = new System.Windows.Forms.RadioButton();
            this.LaCur2RB = new System.Windows.Forms.RadioButton();
            this.LaCur1RB = new System.Windows.Forms.RadioButton();
            this.LaCur0RB = new System.Windows.Forms.RadioButton();
            this.LaCurRB = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.firstOpenDB_button);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.drawBtn);
            this.splitContainer1.Panel2.Controls.Add(this.sensorsListCB);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1134, 741);
            this.splitContainer1.SplitterDistance = 890;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.statusLabel);
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Size = new System.Drawing.Size(890, 741);
            this.splitContainer2.SplitterDistance = 636;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(890, 636);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Status:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(881, 73);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // firstOpenDB_button
            // 
            this.firstOpenDB_button.Location = new System.Drawing.Point(6, 448);
            this.firstOpenDB_button.Name = "firstOpenDB_button";
            this.firstOpenDB_button.Size = new System.Drawing.Size(231, 23);
            this.firstOpenDB_button.TabIndex = 6;
            this.firstOpenDB_button.Text = "Открыть базу для чтения";
            this.firstOpenDB_button.UseVisualStyleBackColor = true;
            this.firstOpenDB_button.Click += new System.EventHandler(this.firstOpenDB_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(124, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Чтение из файла";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 712);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 628);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите временной диапазон";
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(3, 53);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(22, 13);
            this.labelTo.TabIndex = 7;
            this.labelTo.Text = "До";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerFrom.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.datePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFrom.Location = new System.Drawing.Point(85, 21);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(140, 20);
            this.datePickerFrom.TabIndex = 2;
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(3, 27);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(20, 13);
            this.labelFrom.TabIndex = 4;
            this.labelFrom.Text = "От";
            // 
            // datePickerTo
            // 
            this.datePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerTo.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.datePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTo.Location = new System.Drawing.Point(85, 47);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(140, 20);
            this.datePickerTo.TabIndex = 5;
            // 
            // drawBtn
            // 
            this.drawBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.drawBtn.Location = new System.Drawing.Point(156, 708);
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
            this.sensorsListCB.Location = new System.Drawing.Point(6, 3);
            this.sensorsListCB.MultiColumn = true;
            this.sensorsListCB.Name = "sensorsListCB";
            this.sensorsListCB.Size = new System.Drawing.Size(231, 439);
            this.sensorsListCB.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.LaCurShiftRB);
            this.groupBox.Controls.Add(this.LaCur4RB);
            this.groupBox.Controls.Add(this.LaCur3RB);
            this.groupBox.Controls.Add(this.LaCur2RB);
            this.groupBox.Controls.Add(this.LaCur1RB);
            this.groupBox.Controls.Add(this.LaCur0RB);
            this.groupBox.Controls.Add(this.LaCurRB);
            this.groupBox.Location = new System.Drawing.Point(6, 505);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(231, 117);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Выберите тип данных для построения";
            // 
            // LaCurShiftRB
            // 
            this.LaCurShiftRB.AutoSize = true;
            this.LaCurShiftRB.Location = new System.Drawing.Point(38, 89);
            this.LaCurShiftRB.Name = "LaCurShiftRB";
            this.LaCurShiftRB.Size = new System.Drawing.Size(58, 17);
            this.LaCurShiftRB.TabIndex = 6;
            this.LaCurShiftRB.Text = "LaShift";
            this.LaCurShiftRB.UseVisualStyleBackColor = true;
            this.LaCurShiftRB.CheckedChanged += new System.EventHandler(this.LaCurShiftRB_CheckedChanged);
            // 
            // LaCur4RB
            // 
            this.LaCur4RB.AutoSize = true;
            this.LaCur4RB.Location = new System.Drawing.Point(123, 67);
            this.LaCur4RB.Name = "LaCur4RB";
            this.LaCur4RB.Size = new System.Drawing.Size(59, 17);
            this.LaCur4RB.TabIndex = 5;
            this.LaCur4RB.Text = "LaCur4";
            this.LaCur4RB.UseVisualStyleBackColor = true;
            this.LaCur4RB.CheckedChanged += new System.EventHandler(this.LaCur4RB_CheckedChanged);
            // 
            // LaCur3RB
            // 
            this.LaCur3RB.AutoSize = true;
            this.LaCur3RB.Location = new System.Drawing.Point(123, 43);
            this.LaCur3RB.Name = "LaCur3RB";
            this.LaCur3RB.Size = new System.Drawing.Size(59, 17);
            this.LaCur3RB.TabIndex = 4;
            this.LaCur3RB.Text = "LaCur3";
            this.LaCur3RB.UseVisualStyleBackColor = true;
            this.LaCur3RB.CheckedChanged += new System.EventHandler(this.LaCur3RB_CheckedChanged);
            // 
            // LaCur2RB
            // 
            this.LaCur2RB.AutoSize = true;
            this.LaCur2RB.Location = new System.Drawing.Point(123, 19);
            this.LaCur2RB.Name = "LaCur2RB";
            this.LaCur2RB.Size = new System.Drawing.Size(59, 17);
            this.LaCur2RB.TabIndex = 3;
            this.LaCur2RB.Text = "LaCur2";
            this.LaCur2RB.UseVisualStyleBackColor = true;
            this.LaCur2RB.CheckedChanged += new System.EventHandler(this.LaCur2RB_CheckedChanged);
            // 
            // LaCur1RB
            // 
            this.LaCur1RB.AutoSize = true;
            this.LaCur1RB.Location = new System.Drawing.Point(38, 66);
            this.LaCur1RB.Name = "LaCur1RB";
            this.LaCur1RB.Size = new System.Drawing.Size(59, 17);
            this.LaCur1RB.TabIndex = 2;
            this.LaCur1RB.Text = "LaCur1";
            this.LaCur1RB.UseVisualStyleBackColor = true;
            this.LaCur1RB.CheckedChanged += new System.EventHandler(this.LaCur1RB_CheckedChanged);
            // 
            // LaCur0RB
            // 
            this.LaCur0RB.AutoSize = true;
            this.LaCur0RB.Location = new System.Drawing.Point(38, 43);
            this.LaCur0RB.Name = "LaCur0RB";
            this.LaCur0RB.Size = new System.Drawing.Size(59, 17);
            this.LaCur0RB.TabIndex = 1;
            this.LaCur0RB.Text = "LaCur0";
            this.LaCur0RB.UseVisualStyleBackColor = true;
            this.LaCur0RB.CheckedChanged += new System.EventHandler(this.LaCur0RB_CheckedChanged);
            // 
            // LaCurRB
            // 
            this.LaCurRB.AutoSize = true;
            this.LaCurRB.Checked = true;
            this.LaCurRB.Location = new System.Drawing.Point(38, 19);
            this.LaCurRB.Name = "LaCurRB";
            this.LaCurRB.Size = new System.Drawing.Size(53, 17);
            this.LaCurRB.TabIndex = 0;
            this.LaCurRB.TabStop = true;
            this.LaCurRB.Text = "LaCur";
            this.LaCurRB.UseVisualStyleBackColor = true;
            this.LaCurRB.CheckedChanged += new System.EventHandler(this.LaCurRB_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton LaCur4RB;
        private System.Windows.Forms.RadioButton LaCur3RB;
        private System.Windows.Forms.RadioButton LaCur2RB;
        private System.Windows.Forms.RadioButton LaCur1RB;
        private System.Windows.Forms.RadioButton LaCur0RB;
        private System.Windows.Forms.RadioButton LaCurRB;
        private System.Windows.Forms.CheckedListBox sensorsListCB;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.RadioButton LaCurShiftRB;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button firstOpenDB_button;
        private System.Windows.Forms.Button button1;

    }
}

