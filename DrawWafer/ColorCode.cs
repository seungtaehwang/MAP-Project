using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawWafer
{
    public partial class ColorCode : Form
    {
        List<Color> colorList = new List<Color>();
        string type = "One";
        Color startc;
        Color midc;
        Color endc;

        public ColorCode()
        {
            InitializeComponent();
        }

        private List<Color> GetGradientColor()
        {
            startc = startBox.BackColor;
            midc = midBox.BackColor;
            endc = endBox.BackColor;
            int step = Convert.ToInt32(stepComboBox.Text);

            switch (type)
            {
                case "One":
                    startc = Color.White;
                    colorList = GetGradientColor(Color.White, endc, step);
                    break;
                case "Two":
                    colorList = GetGradientColor(startc, endc, step);
                    break;
                case "Three":
                    colorList = GetGradientColor(startc, midc, endc, step);
                    break;
                case "Parula":
                    break;
                case "Turbo":
                    break;
                case "Jet":
                    break;
            }

            return colorList;
        }
        private List<Color> GetGradientColor(Color start, Color end, int step)
        {
            colorList = new List<Color>();

            var aStep = (end.A - start.A) / step;
            var rStep = (end.R - start.R) / step;
            var gStep = (end.G - start.G) / step;
            var bStep = (end.B - start.B) / step;

            for (int i = 0; i < step; i++)
            {
                var a = start.A + i * aStep;
                var r = start.R + i * rStep;
                var g = start.G + i * gStep;
                var b = start.B + i * bStep;
                colorList.Add(Color.FromArgb(a, r, g, b));
            }

            return colorList;
        }
        private List<Color> GetGradientColor(Color start, Color mid, Color end, int step)
        {
            colorList = new List<Color>();

            int count = step / 2;

            var aStep = (mid.A - start.A) / count;
            var rStep = (mid.R - start.R) / count;
            var gStep = (mid.G - start.G) / count;
            var bStep = (mid.B - start.B) / count;

            for (int i = 0; i < count; i++)
            {
                var a = start.A + i * aStep;
                var r = start.R + i * rStep;
                var g = start.G + i * gStep;
                var b = start.B + i * bStep;
                colorList.Add(Color.FromArgb(a, r, g, b));
            }

            aStep = (end.A - mid.A) / count;
            rStep = (end.R - mid.R) / count;
            gStep = (end.G - mid.G) / count;
            bStep = (end.B - mid.B) / count;

            for (int i = 1; i < count; i++)
            {
                var a = mid.A + i * aStep;
                var r = mid.R + i * rStep;
                var g = mid.G + i * gStep;
                var b = mid.B + i * bStep;
                colorList.Add(Color.FromArgb(a, r, g, b));
            }
            return colorList;
        }
        private void DrawGradient()
        {
            Bitmap bmp = new Bitmap(gradientPictureBox.Width, gradientPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            gradientPictureBox.Image = bmp;
            Rectangle rec;
            LinearGradientBrush lgb;

            switch (type)
            {
                case "One":
                case "Two":
                    rec = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    lgb = new LinearGradientBrush(rec, startc, endc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    break;
                case "Three":
                    rec = new Rectangle(0, 0, bmp.Width/2, bmp.Height);
                    lgb = new LinearGradientBrush(rec, startc, midc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    rec = new Rectangle((int)(bmp.Width / 2), 0, bmp.Width / 2, bmp.Height);
                    lgb = new LinearGradientBrush(rec, midc, endc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    break;
                case "Parula":
                case "Turbo":
                case "Jet":
                    break;
            }
        }
        private void SetSelectColor()
        {
            colorPanel.Controls.Clear();

            for (int i = 0; i < colorList.Count; i++)
            {
                Label setColor = new Label();
                setColor.Text = i.ToString();
                setColor.AutoSize = false;
                setColor.BackColor = colorList[i];
                setColor.TextAlign = ContentAlignment.MiddleLeft;
                setColor.Height = 25;
                setColor.Width = colorPanel.Width - 25;
                setColor.Left = 0;
                setColor.Top = i * setColor.Height;
                colorPanel.Controls.Add(setColor);
            }

        }

        private void Type_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rType = (RadioButton)sender;
            if (rType.Checked) type = rType.Text;

            switch (type)
            {
                case "One":
                    startBox.Visible = false;
                    midBox.Visible = false;
                    endBox.Visible = true;
                    break;
                case "Two":
                    startBox.Visible = true;
                    midBox.Visible = false;
                    endBox.Visible = true;
                    break;
                case "Three":
                    startBox.Visible = true;
                    midBox.Visible = true;
                    endBox.Visible = true;
                    break;
                case "Parula":
                case "Turbo":
                case "Jet":
                    startBox.Visible = false;
                    midBox.Visible = false;
                    endBox.Visible = false;
                    break;
            }
            GetGradientColor();
            DrawGradient();
            SetSelectColor();

        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                PictureBox colorbox = (PictureBox)sender;
                colorbox.BackColor = cd.Color;
                GetGradientColor();
                DrawGradient();
                SetSelectColor();
            }
        }

        private void stepComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGradientColor();
            DrawGradient();
            SetSelectColor();
        }
    }
}
