namespace DrawWafer
{
    partial class WaferControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            topLabel = new Label();
            bottomLabel = new Label();
            mapBox = new PictureBox();
            mapPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)mapBox).BeginInit();
            mapPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topLabel
            // 
            topLabel.Dock = DockStyle.Top;
            topLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            topLabel.Location = new Point(1, 1);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(298, 15);
            topLabel.TabIndex = 0;
            topLabel.Text = "Wafer (300000 um)";
            topLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottomLabel
            // 
            bottomLabel.Dock = DockStyle.Bottom;
            bottomLabel.Location = new Point(1, 314);
            bottomLabel.Name = "bottomLabel";
            bottomLabel.Size = new Size(298, 15);
            bottomLabel.TabIndex = 1;
            bottomLabel.Text = "label2";
            bottomLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mapBox
            // 
            mapBox.Dock = DockStyle.Fill;
            mapBox.Location = new Point(0, 0);
            mapBox.Name = "mapBox";
            mapBox.Size = new Size(298, 298);
            mapBox.TabIndex = 2;
            mapBox.TabStop = false;
            // 
            // mapPanel
            // 
            mapPanel.Controls.Add(mapBox);
            mapPanel.Dock = DockStyle.Fill;
            mapPanel.Location = new Point(1, 16);
            mapPanel.Name = "mapPanel";
            mapPanel.Size = new Size(298, 298);
            mapPanel.TabIndex = 3;
            // 
            // WaferControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mapPanel);
            Controls.Add(bottomLabel);
            Controls.Add(topLabel);
            Name = "WaferControl";
            Padding = new Padding(1);
            Size = new Size(300, 330);
            ((System.ComponentModel.ISupportInitialize)mapBox).EndInit();
            mapPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label topLabel;
        private Label bottomLabel;
        private PictureBox mapBox;
        private Panel mapPanel;
    }
}
