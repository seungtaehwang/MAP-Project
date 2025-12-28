using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawWafer
{
    public partial class WaferControl : UserControl
    {
        //Configuration in micrometers (um) ---
        float WAFER_DIAMETER_UM = 300000.0f;
        float EDGE_EXCLUSION_UM = 1500.0f;                      // Margin from the edge
        float DIE_SIZE_X_UM = 5096.0f;
        float DIE_SIZE_Y_UM = 4018.0f;
        float STREET_WIDTH_UM = 10.0f;                         // Space between dies

        // --- Scaling Factor ---
        float ZOOM_SCALE = 1.0f;
        float SCALE_FACTOR = 0.0f;
        float WAFER_DIAMETER_PX = 0.0f;
        float DIE_SIZE_X_PX = 0.0f;
        float DIE_SIZE_Y_PX = 0.0f;
        float STREET_WIDTH_PX = 0.0f;
        //float EDGE_EXCLUSION_PX = 0.0f;
        //float TOP_LABLE_SPACE_PX = 30.0f;

        // Calculate total step size for grid placement
        float STEP_X_PX = 0.0f;
        float STEP_Y_PX = 0.0f;
        float WAFER_RADIUS_PX = 0.0f;

        DataTable waferMapTable = new DataTable();

        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        public WaferControl(DataTable dt, int mapSize, float waferSize, float dieSizeX, float dieSizeY, float waferEdge, float dieSpace)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            waferMapTable = dt;
            
            // Wafer Control Size
            this.Width = mapSize + 2;
            this.Height = mapSize + 30 + 2;

            // Configuration
            WAFER_DIAMETER_UM = waferSize;
            EDGE_EXCLUSION_UM = waferEdge;
            DIE_SIZE_X_UM = dieSizeX;
            DIE_SIZE_Y_UM = dieSizeY;
            STREET_WIDTH_UM = dieSpace;

            // Initialize Canvas
            canvasBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            mapBox.Image = canvasBitmap;

            // 폼의 중앙 좌표 계산 (원점 설정)
            int centerX = this.mapBox.Width / 2;
            int centerY = this.mapBox.Height / 2;

            // 좌표계 변환:
            // 1. 원점을 폼 중앙으로 이동
            canvasGraphics.TranslateTransform(centerX, centerY);
            // 2. Y축을 상하 반전시켜 수학적 좌표계와 일치시킴 (Y값이 위로 갈수록 증가)
            canvasGraphics.ScaleTransform(1, -1);

            // mapBox(WaferMap) Event Mapping
            mapBox.MouseDown += MapBox_MouseDown;
        }

        private void MapBox_MouseDown(object? sender, MouseEventArgs e)
        {
            float xPos = (float)e.X - WAFER_RADIUS_PX;
            float yPos = (float)-e.Y + WAFER_RADIUS_PX;

            foreach (DataRow row in waferMapTable.Rows) 
            {
                float xPos1 = Convert.ToSingle(row["PT1_X"]);
                float yPos1 = Convert.ToSingle(row["PT1_Y"]);
                float xPos2 = Convert.ToSingle(row["PT2_X"]);
                float yPos2 = Convert.ToSingle(row["PT2_Y"]);
                if (xPos1 <= xPos && xPos <= xPos2 && yPos1 <= yPos && yPos <= yPos2)
                {
                    MessageBox.Show($"PT1=({xPos1}, {yPos1}), PT1=({xPos2}, {yPos2}), findPosX={xPos}, findPosY={xPos}"); 
                    break;
                }
            }
        }

        private Color _borderColor = Color.LightGray; // Default border color
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate(); // Redraw the control when the color changes
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the border manually
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (Pen pen = new Pen(BorderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        public void DrawWaferMap()
        {
            DrawWaferMap(1.0f);
        }

        public void DrawWaferMap(float zoomScale = 1.0f)
        {
            ZOOM_SCALE = zoomScale;

            // Zoom Scale에 따른 Cnavas 설정한다.
            mapBox.Width = (mapPanel.Width - 2) * (int)ZOOM_SCALE;
            mapBox.Height = (mapPanel.Width - 2) * (int)ZOOM_SCALE;

            // um -> Pixel로 환산한 변수값 설정한다.
            SCALE_FACTOR = WAFER_DIAMETER_UM / (float)mapBox.Width;
            WAFER_DIAMETER_PX = WAFER_DIAMETER_UM / SCALE_FACTOR;
            WAFER_RADIUS_PX = WAFER_DIAMETER_PX / 2;
            //EDGE_EXCLUSION_PX = EDGE_EXCLUSION_UM / SCALE_FACTOR;

            DIE_SIZE_X_PX = DIE_SIZE_X_UM / SCALE_FACTOR;
            DIE_SIZE_Y_PX = DIE_SIZE_Y_UM / SCALE_FACTOR;
            STREET_WIDTH_PX = STREET_WIDTH_UM / SCALE_FACTOR;
            STEP_X_PX = DIE_SIZE_X_PX + STREET_WIDTH_PX;
            STEP_Y_PX = DIE_SIZE_Y_PX + STREET_WIDTH_PX;

            topLabel.Text = $"Wafer Map (Diameter: {WAFER_DIAMETER_UM / 1000:.0f} mm)";
            bottomLabel.Text = $"Die size: {DIE_SIZE_X_UM}x{DIE_SIZE_Y_UM} um (Scale: 1px = {SCALE_FACTOR}um)";

            // Draw Wafer 테두리
            Pen pen = new Pen(Color.LightGray, 1);
            canvasGraphics.DrawEllipse(pen, -WAFER_RADIUS_PX, -WAFER_RADIUS_PX, WAFER_DIAMETER_PX, WAFER_DIAMETER_PX);

            // Draw Chip
            foreach (DataRow row in waferMapTable.Rows)
            {
                float xPosUm = Convert.ToSingle(row["X_POS"]);
                float yPosUm = Convert.ToSingle(row["Y_POS"]);
                float itemValue = Convert.ToSingle(row["ITEM_VALUE"]);
                string status = row["Status"].ToString();
                float xPosPx = xPosUm / SCALE_FACTOR;
                float yPosPx = yPosUm / SCALE_FACTOR;
                Color dieColor = Color.LightGray;
                if (status == "G")
                    dieColor = Color.Green;
                else if (status == "B")
                    dieColor = Color.Red;
                Brush dieBrush = new SolidBrush(dieColor);
                // Draw Die Rectangle
                canvasGraphics.FillRectangle(dieBrush, xPosPx, yPosPx, DIE_SIZE_X_PX, DIE_SIZE_Y_PX);
                canvasGraphics.DrawRectangle(pen, xPosPx, yPosPx, DIE_SIZE_X_PX, DIE_SIZE_Y_PX);

                // Chip의 현재 Pixel Position 저장
                row["PT1_X"] = xPosPx;
                row["PT1_Y"] =  yPosPx;
                row["PT2_X"] = xPosPx + DIE_SIZE_X_PX;
                row["PT2_Y"] = yPosPx + DIE_SIZE_Y_PX;
            }

            mapBox.Invalidate();
            this.Invalidate(); 
        }
    }
}
