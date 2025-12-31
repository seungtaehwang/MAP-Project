namespace DrawWafer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainToolStrip = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            waferSizeTextBox = new ToolStripTextBox();
            toolStripLabel2 = new ToolStripLabel();
            WaferEdgeTextBox = new ToolStripTextBox();
            toolStripLabel3 = new ToolStripLabel();
            dieSizeXTextBox = new ToolStripTextBox();
            toolStripLabel4 = new ToolStripLabel();
            dieSizeYTextBox = new ToolStripTextBox();
            toolStripLabel5 = new ToolStripLabel();
            scrbeWidthTextBox = new ToolStripTextBox();
            toolStripLabel6 = new ToolStripLabel();
            columnsCount = new ToolStripComboBox();
            toolStripLabel7 = new ToolStripLabel();
            mapCount = new ToolStripComboBox();
            drawButton = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            viewPanel = new Panel();
            singleToolStrip = new ToolStrip();
            toolStripLabel9 = new ToolStripLabel();
            zoomScaleComboBox = new ToolStripComboBox();
            mapInfoLabel = new Label();
            WpfCheckBox = new CheckBox();
            mainToolStrip.SuspendLayout();
            singleToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainToolStrip
            // 
            mainToolStrip.BackColor = SystemColors.Control;
            mainToolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, waferSizeTextBox, toolStripLabel2, WaferEdgeTextBox, toolStripLabel3, dieSizeXTextBox, toolStripLabel4, dieSizeYTextBox, toolStripLabel5, scrbeWidthTextBox, toolStripLabel6, columnsCount, toolStripLabel7, mapCount, drawButton, toolStripButton1 });
            mainToolStrip.Location = new Point(0, 0);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Size = new Size(1420, 25);
            mainToolStrip.TabIndex = 0;
            mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(102, 22);
            toolStripLabel1.Text = "Wafer Size (um):";
            // 
            // waferSizeTextBox
            // 
            waferSizeTextBox.BorderStyle = BorderStyle.FixedSingle;
            waferSizeTextBox.Name = "waferSizeTextBox";
            waferSizeTextBox.Size = new Size(60, 25);
            waferSizeTextBox.Text = "300000";
            waferSizeTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(108, 22);
            toolStripLabel2.Text = "Wafer Edge (um):";
            // 
            // WaferEdgeTextBox
            // 
            WaferEdgeTextBox.BorderStyle = BorderStyle.FixedSingle;
            WaferEdgeTextBox.Name = "WaferEdgeTextBox";
            WaferEdgeTextBox.Size = new Size(60, 25);
            WaferEdgeTextBox.Text = "1000";
            WaferEdgeTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(98, 22);
            toolStripLabel3.Text = "Die Size X (um):";
            // 
            // dieSizeXTextBox
            // 
            dieSizeXTextBox.BorderStyle = BorderStyle.FixedSingle;
            dieSizeXTextBox.Name = "dieSizeXTextBox";
            dieSizeXTextBox.Size = new Size(60, 25);
            dieSizeXTextBox.Text = "5096";
            dieSizeXTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(97, 22);
            toolStripLabel4.Text = "Die Size Y (um):";
            // 
            // dieSizeYTextBox
            // 
            dieSizeYTextBox.BorderStyle = BorderStyle.FixedSingle;
            dieSizeYTextBox.Name = "dieSizeYTextBox";
            dieSizeYTextBox.Size = new Size(60, 25);
            dieSizeYTextBox.Text = "4018";
            dieSizeYTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(115, 22);
            toolStripLabel5.Text = "Scribe Width (um):";
            // 
            // scrbeWidthTextBox
            // 
            scrbeWidthTextBox.BorderStyle = BorderStyle.FixedSingle;
            scrbeWidthTextBox.Name = "scrbeWidthTextBox";
            scrbeWidthTextBox.Size = new Size(40, 25);
            scrbeWidthTextBox.Text = "100";
            scrbeWidthTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(95, 22);
            toolStripLabel6.Text = "Column Count :";
            // 
            // columnsCount
            // 
            columnsCount.AutoSize = false;
            columnsCount.DropDownWidth = 75;
            columnsCount.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            columnsCount.Name = "columnsCount";
            columnsCount.Size = new Size(40, 23);
            columnsCount.Text = "3";
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(79, 22);
            toolStripLabel7.Text = "Map Count :";
            // 
            // mapCount
            // 
            mapCount.AutoSize = false;
            mapCount.DropDownWidth = 75;
            mapCount.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" });
            mapCount.Name = "mapCount";
            mapCount.Size = new Size(40, 23);
            mapCount.Text = "10";
            // 
            // drawButton
            // 
            drawButton.BackColor = SystemColors.GradientInactiveCaption;
            drawButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            drawButton.Image = (Image)resources.GetObject("drawButton.Image");
            drawButton.ImageTransparentColor = Color.Magenta;
            drawButton.Name = "drawButton";
            drawButton.Size = new Size(67, 22);
            drawButton.Text = "Draw Map";
            drawButton.Click += drawButton_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.BackColor = Color.Violet;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(82, 22);
            toolStripButton1.Text = "Color Setting";
            toolStripButton1.TextImageRelation = TextImageRelation.TextAboveImage;
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // viewPanel
            // 
            viewPanel.AutoScroll = true;
            viewPanel.Dock = DockStyle.Fill;
            viewPanel.Location = new Point(0, 25);
            viewPanel.Name = "viewPanel";
            viewPanel.Size = new Size(1420, 610);
            viewPanel.TabIndex = 2;
            viewPanel.Click += drawButton_Click;
            // 
            // singleToolStrip
            // 
            singleToolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel9, zoomScaleComboBox });
            singleToolStrip.Location = new Point(0, 25);
            singleToolStrip.Name = "singleToolStrip";
            singleToolStrip.Size = new Size(1420, 25);
            singleToolStrip.TabIndex = 3;
            singleToolStrip.Text = "toolStrip1";
            singleToolStrip.Visible = false;
            // 
            // toolStripLabel9
            // 
            toolStripLabel9.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            toolStripLabel9.Name = "toolStripLabel9";
            toolStripLabel9.Size = new Size(80, 22);
            toolStripLabel9.Text = "Zoom Scale :";
            // 
            // zoomScaleComboBox
            // 
            zoomScaleComboBox.AutoSize = false;
            zoomScaleComboBox.DropDownWidth = 75;
            zoomScaleComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75" });
            zoomScaleComboBox.Name = "zoomScaleComboBox";
            zoomScaleComboBox.Size = new Size(40, 23);
            zoomScaleComboBox.Text = "1";
            zoomScaleComboBox.TextChanged += zoomScaleComboBox_TextChanged;
            // 
            // mapInfoLabel
            // 
            mapInfoLabel.Dock = DockStyle.Bottom;
            mapInfoLabel.Location = new Point(0, 635);
            mapInfoLabel.Name = "mapInfoLabel";
            mapInfoLabel.Size = new Size(1420, 23);
            mapInfoLabel.TabIndex = 4;
            mapInfoLabel.Text = "Map Info";
            mapInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WpfCheckBox
            // 
            WpfCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            WpfCheckBox.AutoSize = true;
            WpfCheckBox.Location = new Point(1304, 639);
            WpfCheckBox.Name = "WpfCheckBox";
            WpfCheckBox.Size = new Size(113, 19);
            WpfCheckBox.TabIndex = 0;
            WpfCheckBox.Text = "WPF Wafer Map";
            WpfCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1420, 658);
            Controls.Add(WpfCheckBox);
            Controls.Add(viewPanel);
            Controls.Add(mapInfoLabel);
            Controls.Add(singleToolStrip);
            Controls.Add(mainToolStrip);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Draw Wafer Map (Gallery)";
            WindowState = FormWindowState.Maximized;
            mainToolStrip.ResumeLayout(false);
            mainToolStrip.PerformLayout();
            singleToolStrip.ResumeLayout(false);
            singleToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip mainToolStrip;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox waferSizeTextBox;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox WaferEdgeTextBox;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox dieSizeXTextBox;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox dieSizeYTextBox;
        private ToolStripLabel toolStripLabel5;
        private ToolStripTextBox scrbeWidthTextBox;
        private Panel viewPanel;
        private ToolStripLabel toolStripLabel6;
        private ToolStripComboBox columnsCount;
        private ToolStripButton drawButton;
        private ToolStripLabel toolStripLabel7;
        private ToolStripComboBox mapCount;
        private ToolStripButton toolStripButton1;
        private ToolStrip singleToolStrip;
        private ToolStripLabel toolStripLabel9;
        private ToolStripComboBox zoomScaleComboBox;
        private Label mapInfoLabel;
        private CheckBox WpfCheckBox;
    }
}
