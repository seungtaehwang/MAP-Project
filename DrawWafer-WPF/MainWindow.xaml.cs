using SciChart.Charting.ChartModifiers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using System.Data;
using System.Text;
using System.Threading.Tasks.Sources;
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
        WaferControl? currentWafer;
        int currentLeft = 0;
        int currentTop = 0;
        float currentMapSize = 0;

        public MainWindow()
        {
            InitializeComponent();
            SciChartSurface.SetRuntimeLicenseKey("QEAwbWfc41hDsWzpdhG35RIr//hXNDXvQnlXXqi/ZIQMxopIxfH99ff8GsfFXSMEX2ky1o3wrVzapDG6nMVCgaVMqWAf/nOWGQiMEtr0qEQgfl15Tt6e1qmyFYIiVtiFveaeSKxyFILrjZr30lPfmK2SWl2gnRctyJaZ3NzayhMBebpay7J/RmRaG3z1tXA3jmaj9YPVpljvA3n/z+J0zqRiUG4+6xl3yUokhNeNOa4UGmxfs1hkzDAsbzvQ/BI91o8K+oip5uk8VZS2fE8V0jV3cHGjXnTDM8zlbdzgAayjReT4yrx97ujJxub5NiShWGysCnLKG5XKHpa2OKVIUDxtDYNt8T/DW6h9nNppwTgOBjvVvqaS4D8JdLdxVYd2yiJYJDEXir8c4tXSXU+srOSq208q2A0T2NsuKQ63pUyfk3LFHqOme0h35HQjuUk05xalXPA+PJw1IMK+UiIw7VxyMS4Gim/v9cE1WKFnRQ7bhaDf/GpoF4Neu5Ui0ppnqautEIe/AumaKdYOXV4KA27/x1MLsbOSQDpoLhd9JCEcn0bYv9G5rPjvqSpbhQhcaXI=");
            this.Width = 1920;
            this.Height = 1080;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ZoomScale.SelectionChanged += ZoomScale_SelectionChanged;
        }

        private void ZoomScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            float zoomScale = Convert.ToSingle(ZoomScale.Text);
            if (currentWafer != null)
            {
                currentWafer.DrawWaferMap(zoomScale);
            }
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

        private void DrawChartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;


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

                var scichartSurface = new SciChartSurface();
                scichartSurface.Padding = new Thickness(10, 10, 10, 10);
                scichartSurface.ChartTitle = $"Wafer Chart {irow + 1}";
                scichartSurface.Width = plusWidth;
                scichartSurface.Height = plusHeight;
                var xAxis = new NumericAxis { AxisTitle = "X Value" };
                xAxis.Margin = new Thickness(10, 10, 10, 10);
                var yAxis = new NumericAxis { AxisTitle = "Y Value" };
                yAxis.Margin = new Thickness(10, 10, 10, 10);
                scichartSurface.XAxis = xAxis;
                scichartSurface.YAxis = yAxis;

                // 3. Create a DataSeries (e.g., XyDataSeries for a line chart)
                var dataSeries = new XyDataSeries<double, double>() { SeriesName = "Sin Curve" };
                for (int i = 0; i < 100; i++)
                {
                    dataSeries.Append(i, Math.Sin(i * 0.1));
                }

                // 4. Create a RenderableSeries and link it to the DataSeries
                var pointSeries = new XyScatterRenderableSeries
                {
                    DataSeries = dataSeries,
                    PointMarker = new SquarePointMarker  //new EllipsePointMarker // Use a built-in marker type
                    {
                        Width = 8,
                        Height = 8,
                        Fill = Colors.Blue,
                        Stroke = Colors.DeepSkyBlue,
                        StrokeThickness = 1
                    }
                };                

                // 5. Add the RenderableSeries to the SciChartSurface
                scichartSurface.RenderableSeries.Add(pointSeries);
                dataSeries = new XyDataSeries<double, double>() { SeriesName = "Cos Curve" };
                for (int i = 0; i < 100; i++)
                {
                    dataSeries.Append(i, Math.Cos(i * 0.1));
                }

                // 4. Create a RenderableSeries and link it to the DataSeries
                pointSeries = new XyScatterRenderableSeries
                {
                    DataSeries = dataSeries,
                    PointMarker = new EllipsePointMarker // Use a built-in marker type
                    {
                        Width = 8,
                        Height = 8,
                        Fill = Colors.Red,
                        Stroke = Colors.DeepSkyBlue,
                        StrokeThickness = 1
                    }
                };

                // 5. Add the RenderableSeries to the SciChartSurface
                scichartSurface.RenderableSeries.Add(pointSeries);

                scichartSurface.ChartModifier = new LegendModifier()
                {
                    // Optional: Customize the legend's appearance and behavior
                    Background = Brushes.White,
                    Foreground = Brushes.Black,
                    ShowVisibilityCheckboxes = false, // Allows users to show/hide series
                    Orientation = Orientation.Vertical,
                    LegendPlacement = LegendPlacement.Right 
                };

                // 6. Optional: Add interactivity (zoom, pan, etc.)
                //scichartSurface.ChartModifier = new ModifierGroup(
                //    new RubberBandXyZoomModifier(),
                //    new ZoomExtentsModifier()
                //);

                // Add the chart to your UI
                Canvas.SetLeft(scichartSurface, left);
                Canvas.SetTop(scichartSurface, top);
                GalleryView.Children.Add(scichartSurface);
            }
            GalleryView.Height = ((Convert.ToInt32(MapCount.Text) - 1) / columnCount + 1) * (plusHeight + 1);
            MapViewer.Visibility = Visibility.Visible;

            this.Cursor = Cursors.Arrow; // 또는 원래 상태로            var scichartSurface = new SciChartSurface();
        }
    }
}