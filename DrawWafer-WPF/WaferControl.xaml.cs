using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawWafer_WPF
{
    /// <summary>
    /// WaferControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaferControl : UserControl
    {
        //Configuration in micrometers (um) ---
        float WAFER_DIAMETER_UM = 300000.0f;
        float EDGE_EXCLUSION_UM = 1500.0f;                      // Margin from the edge
        float DIE_SIZE_X_UM = 5096.0f;
        float DIE_SIZE_Y_UM = 4018.0f;
        float SCRIBE_WIDTH_UM = 10.0f;                         // Space between dies

        // --- Scaling Factor ---
        float ZOOM_SCALE = 1.0f;
        float SCALE_FACTOR = 0.0f;
        float WAFER_DIAMETER_PX = 0.0f;
        float DIE_SIZE_X_PX = 0.0f;
        float DIE_SIZE_Y_PX = 0.0f;
        float SCRIBE_WIDTH_PX = 0.0f;

        // Calculate total step size for grid placement
        float WAFER_RADIUS_PX = 0.0f;

        DataTable waferMapTable = new DataTable();

        int realMapSize = 0;
        public int MapSize
        { 
            get { return realMapSize; }  
            set 
            { 
                realMapSize = value;
                // Wafer Control Size
                this.Width = realMapSize + 2;
                this.Height = realMapSize + 50 + 2;
                WaferCanvas.Width = realMapSize;
                WaferCanvas.Height = realMapSize;
            }
        }

        public WaferControl()
        {
            InitializeComponent();
        }

        public WaferControl(DataTable dt, int mapSize, float waferSize, float dieSizeX, float dieSizeY, float waferEdge, float dieSpace)
        {
            InitializeComponent();

            waferMapTable = dt;
            realMapSize = mapSize;
            // Wafer Control Size
            this.Width = realMapSize + 2;
            this.Height = realMapSize + 50 + 2;
            WaferCanvas.Width = realMapSize;
            WaferCanvas.Height = realMapSize;
            // Configuration
            WAFER_DIAMETER_UM = waferSize;
            EDGE_EXCLUSION_UM = waferEdge;
            DIE_SIZE_X_UM = dieSizeX;
            DIE_SIZE_Y_UM = dieSizeY;
            SCRIBE_WIDTH_UM = dieSpace;

            MapViewer.PreviewMouseWheel += MapViewer_PreviewMouseWheel;
            MapViewer.MouseDoubleClick += MapViewer_MouseDoubleClick;
            WaferCanvas.MouseLeftButtonDown += WaferCanvas_MouseDown;
            ZoomCanvas.MouseLeftButtonDown += ZoomCanvas_MouseDown;


        }

        private void MapViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventArgs newEvent = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
            {
                RoutedEvent = UserControl.MouseDoubleClickEvent,
                Source = this
            };

            // 이벤트를 부모 Grid에 발생시킵니다.
            this.RaiseEvent(newEvent);
        }

        private void MapViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void WaferCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Point pt = e.GetPosition(WaferCanvas);

            float xPos = (float)pt.X;
            float yPos = (float)pt.Y;

            foreach (DataRow row in waferMapTable.Rows)
            {
                float xPos1 = Convert.ToSingle(row["PT1_X"]);
                float yPos1 = Convert.ToSingle(row["PT1_Y"]);
                float xPos2 = Convert.ToSingle(row["PT2_X"]);
                float yPos2 = Convert.ToSingle(row["PT2_Y"]);
                if (xPos1 <= xPos && xPos <= xPos2 && yPos1 <= yPos && yPos <= yPos2)
                {
                    //MessageBox.Show($"PT1=({xPos1}, {yPos1}), PT2=({xPos2}, {yPos2}), findPosX={xPos}, findPosY={xPos}");
                    break;
                }
            }
            e.Handled = true;
        }
        private void ZoomCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Point pt = e.GetPosition(ZoomCanvas);

            float xPos = (float)pt.X;
            float yPos = (float)pt.Y;

            foreach (DataRow row in waferMapTable.Rows)
            {
                float xPos1 = Convert.ToSingle(row["PT1_X"]);
                float yPos1 = Convert.ToSingle(row["PT1_Y"]);
                float xPos2 = Convert.ToSingle(row["PT2_X"]);
                float yPos2 = Convert.ToSingle(row["PT2_Y"]);
                if (xPos1 <= xPos && xPos <= xPos2 && yPos1 <= yPos && yPos <= yPos2)
                {
                    MessageBox.Show($"PT1=({xPos1},{yPos1}), PT2=({xPos2},{yPos2}), findPosX={xPos}, findPosY={xPos}");
                    break;
                }
            }
            e.Handled = true;
        }

        public void DrawWaferMap()
        {
            DrawWaferMap(1.0f);
        }

        public void DrawWaferMap(float zoomScale = 1.0f)
        {
            Canvas drawCanvas = null;
            ZOOM_SCALE = zoomScale;

            // Zoom Scale에 따른 Cnavas 설정한다.
            if (ZOOM_SCALE > 1.0f)
            {
                MapViewer.Visibility = Visibility.Visible;
                drawCanvas = ZoomCanvas;
                drawCanvas.Width = (this.Width - 2) * ZOOM_SCALE;
                drawCanvas.Height = (this.Width - 2) * ZOOM_SCALE;
            }
            else
            {
                MapViewer.Visibility = Visibility.Hidden;
                drawCanvas = WaferCanvas;
            }

            // um -> Pixel로 환산한 변수값 설정한다.
            SCALE_FACTOR = WAFER_DIAMETER_UM / (float)drawCanvas.Width;
            WAFER_DIAMETER_PX = WAFER_DIAMETER_UM / SCALE_FACTOR;
            WAFER_RADIUS_PX = WAFER_DIAMETER_PX / 2;
            //EDGE_EXCLUSION_PX = EDGE_EXCLUSION_UM / SCALE_FACTOR;

            DIE_SIZE_X_PX = DIE_SIZE_X_UM / SCALE_FACTOR;
            DIE_SIZE_Y_PX = DIE_SIZE_Y_UM / SCALE_FACTOR;
            SCRIBE_WIDTH_PX = SCRIBE_WIDTH_UM / SCALE_FACTOR;

            // Top, Bottom Info label 설정한다.
            TopInfo.Content = $"Wafer Map (Diameter: {WAFER_DIAMETER_UM / 1000:.0f} mm)";
            bottomInfo.Content = $"Die size: {DIE_SIZE_X_UM}x{DIE_SIZE_Y_UM} um (Scale: 1px = {SCALE_FACTOR}um)";

            // Wafer 테두리 Draw
            Ellipse wafer = new Ellipse
            {
                Width = WAFER_DIAMETER_PX,
                Height = WAFER_DIAMETER_PX,
                Fill = Brushes.White,
                Stroke = Brushes.Gray,
                StrokeThickness = 0.5
            };
            Canvas.SetLeft(wafer, -WAFER_RADIUS_PX);
            Canvas.SetTop(wafer, -WAFER_RADIUS_PX);
            drawCanvas.Children.Add(wafer);

            // Wafer notch or flat zone 표시 -> notch size는 wafer size의 1.5%
            // notch position wafer 테두리 삭제
            float notchSize = (float)(drawCanvas.Width * 0.015);
            Rectangle notch = new Rectangle
            {
                Width = notchSize,
                Height = 5,
                Fill = Brushes.White,
                Stroke = Brushes.White,
                StrokeThickness =1
            };
            Canvas.SetLeft(notch, -(notchSize / 2));
            Canvas.SetTop(notch, -WAFER_RADIUS_PX - 2);
            drawCanvas.Children.Add(notch);

            // Draw notch line 
            Line edgeLine = new Line();
            edgeLine.X1 = (notchSize / 2);
            edgeLine.Y1 = -WAFER_RADIUS_PX;
            edgeLine.X2 = 0;
            edgeLine.Y2 = -WAFER_RADIUS_PX + notchSize;
            edgeLine.Stroke = Brushes.Gray;
            edgeLine.StrokeThickness = 1;
            drawCanvas.Children.Add(edgeLine);

            edgeLine = new Line();
            edgeLine.X1 = -(notchSize / 2);
            edgeLine.Y1 = -WAFER_RADIUS_PX;
            edgeLine.X2 = 0;
            edgeLine.Y2 = -WAFER_RADIUS_PX + notchSize;
            edgeLine.Stroke = Brushes.Gray;
            edgeLine.StrokeThickness = 1;
            drawCanvas.Children.Add(edgeLine);

            // Chip Draw
            foreach (DataRow row in waferMapTable.Rows)
            {
                float xPosUm = Convert.ToSingle(row["X_POS"]);
                float yPosUm = Convert.ToSingle(row["Y_POS"]);
                float itemValue = Convert.ToSingle(row["ITEM_VALUE"]);
                string status = row["Status"].ToString();
                float xPosPx = xPosUm / SCALE_FACTOR;
                float yPosPx = yPosUm / SCALE_FACTOR;
                Rectangle die = new Rectangle
                {
                    Width = DIE_SIZE_X_PX,
                    Height = DIE_SIZE_Y_PX,
                    Fill = (status == "G" ? Brushes.Blue : Brushes.Red),
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                // Draw Die Rectangle
                Canvas.SetLeft(die, xPosPx);
                Canvas.SetTop(die, yPosPx);
                drawCanvas.Children.Add(die);

                // Chip의 현재 Pixel Position 저장
                row["PT1_X"] = xPosPx;
                row["PT1_Y"] = yPosPx;
                row["PT2_X"] = xPosPx + DIE_SIZE_X_PX;
                row["PT2_Y"] = yPosPx + DIE_SIZE_Y_PX;
            }
            drawCanvas.Visibility = Visibility.Visible;

        }

        private void WaferCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (CanvasTranslateTransform != null)
            {
                // 원점을 캔버스의 중앙 하단이 아닌, 중앙으로 설정합니다.
                // TranslateTransform의 X, Y는 변환 전 좌표계에서의 이동량입니다.
                // ScaleTransform이 적용된 상태이므로 Y축 이동은 음수여야 위로 이동합니다.
                CanvasTranslateTransform.X = WaferCanvas.ActualWidth / 2;
                CanvasTranslateTransform.Y = WaferCanvas.ActualHeight / 2;
            }
            if (ZoomTranslateTransform != null)
            {
                // 원점을 캔버스의 중앙 하단이 아닌, 중앙으로 설정합니다.
                // TranslateTransform의 X, Y는 변환 전 좌표계에서의 이동량입니다.
                // ScaleTransform이 적용된 상태이므로 Y축 이동은 음수여야 위로 이동합니다.
                ZoomTranslateTransform.X = ZoomCanvas.ActualWidth / 2;
                ZoomTranslateTransform.Y = ZoomCanvas.ActualHeight / 2;
            }
        }
    }
}
