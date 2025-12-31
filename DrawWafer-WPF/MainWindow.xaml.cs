using System.Data;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Configuration in micrometers (um) ---
        float WAFER_DIAMETER_UM = 300000.0f;
        float EDGE_EXCLUSION_UM = 1500.0f;                      // Margin from the edge
        float DIE_SIZE_X_UM = 5096.0f;
        float DIE_SIZE_Y_UM = 4018.0f;
        float SCRIBE_WIDTH_UM = 10.0f;                         // Space between dies
        WaferControl currentWafer;
        int currentLeft = 0;
        int currentTop = 0;
        float currentMapSize = 0;

        public MainWindow()
        {
            InitializeComponent();
            ZoomScale.SelectionChanged += ZoomScale_SelectionChanged;
        }

        private void ZoomScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            float zoomScale = Convert.ToSingle(ZoomScale.Text);
            if (currentWafer != null) currentWafer.DrawWaferMap(zoomScale);
        }

        private DataTable CreateDieDataTable()
        {
            DataTable dieTable = new DataTable();
            dieTable.Columns.Add("DieID", typeof(int));
            dieTable.Columns.Add("X_Pos", typeof(float));
            dieTable.Columns.Add("Y_Pos", typeof(float));
            dieTable.Columns.Add("ITEM_VALUE", typeof(float));
            dieTable.Columns.Add("Status", typeof(string)); // e.g., "Good", "Bad", "Not Placed"
            dieTable.Columns.Add("PT1_X", typeof(float));
            dieTable.Columns.Add("PT1_Y", typeof(float));
            dieTable.Columns.Add("PT2_X", typeof(float));
            dieTable.Columns.Add("PT2_Y", typeof(float));


            int dixLen = (int)((WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) / (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM));
            float dixDum = (WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) % (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM);
            int diyLen = (int)((WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) / (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM));
            float diyDum = (WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) % (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM);

            float waferRadiusUm = WAFER_DIAMETER_UM / 2.0f;
            float validRadiusUm = waferRadiusUm - EDGE_EXCLUSION_UM;

            int dieID = 0;
            for (int diX = 0; diX < dixLen; diX++)
            {
                for (int diY = 0; diY < diyLen; diY++)
                {

                    float xPos = -validRadiusUm + dixDum / 2.0f + diX * (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM);
                    float yPos = -validRadiusUm + diyDum / 2.0f + diY * (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM);

                    bool valid = false;

                    if (xPos < 0.0f && yPos < 0.0f)
                        valid = Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2)) <= validRadiusUm;

                    if (xPos < 0.0f && yPos >= 0.0f)
                        valid = Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow((yPos + DIE_SIZE_Y_UM), 2)) <= validRadiusUm;

                    if (xPos >= 0.0f && yPos >= 0.0f)
                        valid = Math.Sqrt(Math.Pow((xPos + DIE_SIZE_X_UM), 2) + Math.Pow((yPos + DIE_SIZE_Y_UM), 2)) <= validRadiusUm;

                    if (xPos >= 0.0f && yPos < 0.0f)
                        valid = Math.Sqrt(Math.Pow((xPos + DIE_SIZE_X_UM), 2) + Math.Pow(yPos, 2)) <= validRadiusUm;

                    // Randomly assign ITEM_VALUE and Status for demonstration
                    float itemValue = new Random().Next(60, 100);
                    string status = (itemValue > 70) ? "G" : "B";
                    if (valid) dieTable.Rows.Add(dieID, xPos, yPos, itemValue, status);

                    dieID++;
                }
            }

            return dieTable;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            currentWafer = null;
            ZoomScale.SelectionChanged -= ZoomScale_SelectionChanged;
            ZoomScale.Text = "1";
            ZoomScale.SelectionChanged += ZoomScale_SelectionChanged;

            WAFER_DIAMETER_UM = (float)Convert.ToDouble(WaferSize.Text);
            EDGE_EXCLUSION_UM = (float)Convert.ToDouble(WaferEdge.Text);
            DIE_SIZE_X_UM = (float)Convert.ToDouble(DieSizeX.Text);
            DIE_SIZE_Y_UM = (float)Convert.ToDouble(DieSizeY.Text);
            SCRIBE_WIDTH_UM = (float)Convert.ToDouble(ScribeWidth.Text);

            MapViewer.Visibility = Visibility.Hidden;
            GalleryView.Children.Clear();
            SingleViewer.Children.Clear();
            GalleryView.Height = MapViewer.Height;
            MapViewer.ScrollToTop();
            MapViewer.ScrollToHome();

            int mapSize = (int)((MapViewer.ActualWidth - 60) / Convert.ToDouble(ColumnCount.Text));
            int plusWidth = mapSize + 2;
            int plusHeight = mapSize + 52;
            int columnCount = Convert.ToInt32(ColumnCount.Text);
            for (int irow = 0; irow < Convert.ToInt32(MapCount.Text); irow++)
            {
                int top = (irow / columnCount) * (plusHeight + 1);
                int left = (irow % columnCount) * (plusWidth + 1) + 3;
                DataTable waferDT = CreateDieDataTable();
                WaferControl waferControl = new WaferControl(waferDT, mapSize, WAFER_DIAMETER_UM, DIE_SIZE_X_UM, DIE_SIZE_Y_UM, EDGE_EXCLUSION_UM, SCRIBE_WIDTH_UM);
                waferControl.DrawWaferMap();
                Canvas.SetLeft(waferControl, left);
                Canvas.SetTop(waferControl, top);
                GalleryView.Children.Add(waferControl);
                waferControl.MouseDoubleClick += WaferControl_MouseDoubleClick;
                waferControl.ChipInfoEvent += WaferControl_ChipInfoEvent;
            }
            GalleryView.Height = ((Convert.ToInt32(MapCount.Text) - 1) / columnCount + 1) * (plusHeight + 1);
            MapViewer.Visibility = Visibility.Visible;

            this.Cursor = Cursors.Arrow; // 또는 원래 상태로

        }

        private void WaferControl_ChipInfoEvent(object sender, MapInfoEventArgs e)
        {
            MapInfo.Content = e.Message;
        }

        private void WaferControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentWafer != sender)
            {
                MainToolbar.Visibility = Visibility.Hidden;
                SingleToolbar.Visibility = Visibility.Visible;
                currentWafer = (WaferControl)sender;
                currentLeft = (int)Canvas.GetLeft(currentWafer);
                currentTop = (int)Canvas.GetTop(currentWafer);
                currentMapSize = (float)currentWafer.MapSize;
                GalleryView.Children.Remove(currentWafer);
                MapViewer.Visibility = Visibility.Hidden;
                SingleViewer.Visibility = Visibility.Visible;
                currentWafer.MapSize = (int)(SingleViewer.ActualHeight - 52);
                currentWafer.DrawWaferMap();
                SingleViewer.Children.Add(currentWafer);
            }
            else
            {
                MainToolbar.Visibility = Visibility.Visible;
                SingleToolbar.Visibility = Visibility.Hidden;
                SingleViewer.Children.Remove(currentWafer);
                SingleViewer.Children.Clear();
                SingleViewer.Visibility = Visibility.Hidden;
                currentWafer.MapSize = (int)currentMapSize;
                currentWafer.DrawWaferMap();
                MapViewer.Visibility = Visibility.Visible;
                Canvas.SetLeft(currentWafer, currentLeft);
                Canvas.SetTop(currentWafer, currentTop);
                GalleryView.Children.Add(currentWafer);
                currentWafer = null;
            }
            e.Handled = true;
        }
    }
}