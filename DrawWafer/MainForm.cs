using System;
using System.Data;

namespace DrawWafer
{
    public partial class MainForm : Form
    {

        //Configuration in micrometers (um) ---
        float WAFER_DIAMETER_UM = 300000.0f;
        float EDGE_EXCLUSION_UM = 1500.0f;                      // Margin from the edge
        float DIE_SIZE_X_UM = 5096.0f;
        float DIE_SIZE_Y_UM = 4018.0f;
        float SCRIBE_WIDTH_UM = 10.0f;                         // Space between dies

        WaferControl currentMap;

        public MainForm()
        {
            InitializeComponent();
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


            int diexLen = (int)((WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) / (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM));
            float diexDum = (WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) % (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM);
            int dieyLen = (int)((WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) / (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM));
            float dieyDum = (WAFER_DIAMETER_UM - 2 * EDGE_EXCLUSION_UM) % (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM);

            float waferRadiusUm = WAFER_DIAMETER_UM / 2.0f;
            float validRadiusUm = waferRadiusUm - EDGE_EXCLUSION_UM;

            int dieID = 0;
            for (int diX = 0; diX < diexLen; diX++)
            {
                for (int diY = 0; diY < dieyLen; diY++)
                {

                    float xPos = -validRadiusUm + diexDum / 2.0f + diX * (DIE_SIZE_X_UM + SCRIBE_WIDTH_UM);
                    float yPos = -validRadiusUm + dieyDum / 2.0f + diY * (DIE_SIZE_Y_UM + SCRIBE_WIDTH_UM);

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

        private void drawButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            WAFER_DIAMETER_UM = (float)Convert.ToDouble(waferSizeTextBox.Text);
            EDGE_EXCLUSION_UM = (float)Convert.ToDouble(WaferEdgeTextBox.Text);
            DIE_SIZE_X_UM = (float)Convert.ToDouble(dieSizeXTextBox.Text);
            DIE_SIZE_Y_UM = (float)Convert.ToDouble(dieSizeYTextBox.Text);
            SCRIBE_WIDTH_UM = (float)Convert.ToDouble(scrbeWidthTextBox.Text);

            viewPanel.Controls.Clear();

            int mapSize = (int)((viewPanel.Width - 60) / Convert.ToDouble(columnsCount.Text));
            int plusWidth = mapSize + 2;
            int plusHeight = mapSize + 32;
            int columnCount = Convert.ToInt32(columnsCount.Text);
            int zoomScale = Convert.ToInt32(zoomScaleComboBox.Text);

            for (int irow = 0; irow < Convert.ToInt32(mapCount.Text); irow++)
            {
                int top = (irow / columnCount) * (plusHeight + 1);
                int left = (irow % columnCount) * (plusWidth + 1) + 3;
                DataTable waferDT = CreateDieDataTable();
                WaferControl waferControl = new WaferControl(waferDT, mapSize, WAFER_DIAMETER_UM, DIE_SIZE_X_UM, DIE_SIZE_Y_UM, EDGE_EXCLUSION_UM, SCRIBE_WIDTH_UM);
                viewPanel.Controls.Add(waferControl);
                waferControl.Left = left;
                waferControl.Top = top;
                waferControl.Visible = false;
                waferControl.DrawWaferMap(zoomScale);
                waferControl.Visible = true;
            }
            this.Cursor = Cursors.Arrow;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorCode colorCode = new ColorCode();
            colorCode.ShowDialog();
        }

    }
}
