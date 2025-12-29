namespace DrawWafer
{
    partial class ColorCode
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
            typeGroupBox = new GroupBox();
            stepComboBox = new ComboBox();
            label1 = new Label();
            jetRadioButton = new RadioButton();
            turboRadioButton = new RadioButton();
            ParulaRadioButton = new RadioButton();
            threeRadioButton = new RadioButton();
            twoRadioButton = new RadioButton();
            oneRadioButton = new RadioButton();
            rangeGroupBox = new GroupBox();
            endBox = new PictureBox();
            midBox = new PictureBox();
            startBox = new PictureBox();
            gradientPictureBox = new PictureBox();
            groupBox1 = new GroupBox();
            colorPanel = new Panel();
            buttonPanel = new Panel();
            cancelButton = new Button();
            okButton = new Button();
            typeGroupBox.SuspendLayout();
            rangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)midBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gradientPictureBox).BeginInit();
            groupBox1.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // typeGroupBox
            // 
            typeGroupBox.Controls.Add(stepComboBox);
            typeGroupBox.Controls.Add(label1);
            typeGroupBox.Controls.Add(jetRadioButton);
            typeGroupBox.Controls.Add(turboRadioButton);
            typeGroupBox.Controls.Add(ParulaRadioButton);
            typeGroupBox.Controls.Add(threeRadioButton);
            typeGroupBox.Controls.Add(twoRadioButton);
            typeGroupBox.Controls.Add(oneRadioButton);
            typeGroupBox.Dock = DockStyle.Top;
            typeGroupBox.Location = new Point(0, 0);
            typeGroupBox.Name = "typeGroupBox";
            typeGroupBox.Size = new Size(642, 47);
            typeGroupBox.TabIndex = 0;
            typeGroupBox.TabStop = false;
            typeGroupBox.Text = "Color Type";
            // 
            // stepComboBox
            // 
            stepComboBox.FormattingEnabled = true;
            stepComboBox.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "150", "200" });
            stepComboBox.Location = new Point(571, 15);
            stepComboBox.Name = "stepComboBox";
            stepComboBox.Size = new Size(50, 23);
            stepComboBox.TabIndex = 7;
            stepComboBox.Text = "20";
            stepComboBox.SelectedIndexChanged += stepComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(527, 18);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "Step :";
            // 
            // jetRadioButton
            // 
            jetRadioButton.AutoSize = true;
            jetRadioButton.Location = new Point(348, 19);
            jetRadioButton.Name = "jetRadioButton";
            jetRadioButton.Size = new Size(39, 19);
            jetRadioButton.TabIndex = 5;
            jetRadioButton.Text = "Jet";
            jetRadioButton.UseVisualStyleBackColor = true;
            jetRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // turboRadioButton
            // 
            turboRadioButton.AutoSize = true;
            turboRadioButton.Location = new Point(279, 19);
            turboRadioButton.Name = "turboRadioButton";
            turboRadioButton.Size = new Size(56, 19);
            turboRadioButton.TabIndex = 4;
            turboRadioButton.Text = "Turbo";
            turboRadioButton.UseVisualStyleBackColor = true;
            turboRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // ParulaRadioButton
            // 
            ParulaRadioButton.AutoSize = true;
            ParulaRadioButton.Location = new Point(208, 19);
            ParulaRadioButton.Name = "ParulaRadioButton";
            ParulaRadioButton.Size = new Size(58, 19);
            ParulaRadioButton.TabIndex = 3;
            ParulaRadioButton.Text = "Parula";
            ParulaRadioButton.UseVisualStyleBackColor = true;
            ParulaRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // threeRadioButton
            // 
            threeRadioButton.AutoSize = true;
            threeRadioButton.Location = new Point(141, 19);
            threeRadioButton.Name = "threeRadioButton";
            threeRadioButton.Size = new Size(54, 19);
            threeRadioButton.TabIndex = 2;
            threeRadioButton.Text = "Three";
            threeRadioButton.UseVisualStyleBackColor = true;
            threeRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // twoRadioButton
            // 
            twoRadioButton.AutoSize = true;
            twoRadioButton.Location = new Point(81, 19);
            twoRadioButton.Name = "twoRadioButton";
            twoRadioButton.Size = new Size(47, 19);
            twoRadioButton.TabIndex = 1;
            twoRadioButton.Text = "Two";
            twoRadioButton.UseVisualStyleBackColor = true;
            twoRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // oneRadioButton
            // 
            oneRadioButton.AutoSize = true;
            oneRadioButton.Checked = true;
            oneRadioButton.Location = new Point(21, 19);
            oneRadioButton.Name = "oneRadioButton";
            oneRadioButton.Size = new Size(47, 19);
            oneRadioButton.TabIndex = 0;
            oneRadioButton.TabStop = true;
            oneRadioButton.Text = "One";
            oneRadioButton.UseVisualStyleBackColor = true;
            oneRadioButton.CheckedChanged += Type_CheckedChanged;
            // 
            // rangeGroupBox
            // 
            rangeGroupBox.Controls.Add(endBox);
            rangeGroupBox.Controls.Add(midBox);
            rangeGroupBox.Controls.Add(startBox);
            rangeGroupBox.Controls.Add(gradientPictureBox);
            rangeGroupBox.Dock = DockStyle.Top;
            rangeGroupBox.Location = new Point(0, 47);
            rangeGroupBox.Name = "rangeGroupBox";
            rangeGroupBox.Size = new Size(642, 109);
            rangeGroupBox.TabIndex = 1;
            rangeGroupBox.TabStop = false;
            rangeGroupBox.Text = "One Color";
            // 
            // endBox
            // 
            endBox.BackColor = Color.Blue;
            endBox.BorderStyle = BorderStyle.FixedSingle;
            endBox.Location = new Point(581, 22);
            endBox.Name = "endBox";
            endBox.Size = new Size(39, 31);
            endBox.TabIndex = 4;
            endBox.TabStop = false;
            endBox.Click += ColorBox_Click;
            // 
            // midBox
            // 
            midBox.BackColor = Color.Yellow;
            midBox.BorderStyle = BorderStyle.FixedSingle;
            midBox.Location = new Point(301, 23);
            midBox.Name = "midBox";
            midBox.Size = new Size(39, 31);
            midBox.TabIndex = 3;
            midBox.TabStop = false;
            midBox.Visible = false;
            midBox.Click += ColorBox_Click;
            // 
            // startBox
            // 
            startBox.BackColor = Color.White;
            startBox.BorderStyle = BorderStyle.FixedSingle;
            startBox.Location = new Point(21, 23);
            startBox.Name = "startBox";
            startBox.Size = new Size(39, 31);
            startBox.TabIndex = 2;
            startBox.TabStop = false;
            startBox.Visible = false;
            startBox.Click += ColorBox_Click;
            // 
            // gradientPictureBox
            // 
            gradientPictureBox.BorderStyle = BorderStyle.FixedSingle;
            gradientPictureBox.Location = new Point(21, 60);
            gradientPictureBox.Name = "gradientPictureBox";
            gradientPictureBox.Size = new Size(600, 38);
            gradientPictureBox.TabIndex = 0;
            gradientPictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(colorPanel);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(642, 404);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Color List";
            // 
            // colorPanel
            // 
            colorPanel.AutoScroll = true;
            colorPanel.BorderStyle = BorderStyle.FixedSingle;
            colorPanel.Location = new Point(21, 22);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(600, 375);
            colorPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 560);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(642, 64);
            buttonPanel.TabIndex = 3;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(545, 11);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 28);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            okButton.Location = new Point(450, 11);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 28);
            okButton.TabIndex = 0;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            // 
            // ColorCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 624);
            Controls.Add(groupBox1);
            Controls.Add(buttonPanel);
            Controls.Add(rangeGroupBox);
            Controls.Add(typeGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ColorCode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ColorCode";
            typeGroupBox.ResumeLayout(false);
            typeGroupBox.PerformLayout();
            rangeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)endBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)midBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)startBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)gradientPictureBox).EndInit();
            groupBox1.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox typeGroupBox;
        private RadioButton jetRadioButton;
        private RadioButton turboRadioButton;
        private RadioButton ParulaRadioButton;
        private RadioButton threeRadioButton;
        private RadioButton twoRadioButton;
        private RadioButton oneRadioButton;
        private GroupBox rangeGroupBox;
        private PictureBox endBox;
        private PictureBox midBox;
        private PictureBox startBox;
        private PictureBox gradientPictureBox;
        private GroupBox groupBox1;
        private Panel buttonPanel;
        private Button cancelButton;
        private Button okButton;
        private Panel colorPanel;
        private Label label1;
        private ComboBox stepComboBox;
    }
}