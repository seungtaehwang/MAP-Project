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
            Color scolor;
            Color ecolor;
            List<Color> cList;
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
                    colorList = new List<Color>();

                    scolor = Color.FromArgb(62, 39, 169);
                    ecolor = Color.FromArgb(53, 121, 254);

                    cList = GetGradientColor(scolor, ecolor, 26);
                    for (int i = 0; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(53, 121, 254);
                    ecolor = Color.FromArgb(16, 191, 187);
                    cList = GetGradientColor(scolor, ecolor, 26);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(16, 191, 187);
                    ecolor = Color.FromArgb(200, 194, 41);
                    cList = GetGradientColor(scolor, ecolor, 26);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(200, 194, 41);
                    ecolor = Color.FromArgb(250, 252, 21);
                    cList = GetGradientColor(scolor, ecolor, 26);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    break;
                case "Turbo":
                    break;
                case "Jet":
                    colorList = new List<Color>();

                    scolor = Color.FromArgb(0, 0, 127);
                    ecolor = Color.FromArgb(0, 0, 255);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 0; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(0, 0, 255);
                    ecolor = Color.FromArgb(0, 127, 255);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(0, 127, 255);
                    ecolor = Color.FromArgb(0, 255, 255);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(0, 255, 255);
                    ecolor = Color.FromArgb(127, 255, 127);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(127, 255, 127);
                    ecolor = Color.FromArgb(255, 255, 0);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(255, 255, 0);
                    ecolor = Color.FromArgb(255, 127, 0);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(255, 127, 0);
                    ecolor = Color.FromArgb(255, 0, 0);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    scolor = Color.FromArgb(255, 0, 0);
                    ecolor = Color.FromArgb(127, 0, 0);
                    cList = GetGradientColor(scolor, ecolor, 14);
                    for (int i = 1; i < cList.Count; i++)
                    {
                        colorList.Add(cList[i]);
                    }
                    break;

            }

            return colorList;
        }
        private List<Color> GetGradientColor(Color start, Color end, int step)
        {
            List<Color> cList = new List<Color>();

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
                cList.Add(Color.FromArgb(a, r, g, b));
            }

            return cList;
        }
        private List<Color> GetGradientColor(Color start, Color mid, Color end, int step)
        {
            List<Color> cList = new List<Color>();

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
                cList.Add(Color.FromArgb(a, r, g, b));
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
                cList.Add(Color.FromArgb(a, r, g, b));
            }
            return cList;
        }
        private void DrawGradient()
        {
            Bitmap bmp = new Bitmap(gradientPictureBox.Width, gradientPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            gradientPictureBox.Image = bmp;
            Rectangle rec;
            LinearGradientBrush lgb;
            Color scolor;
            Color ecolor;
            int width = 0;
            switch (type)
            {
                case "One":
                case "Two":
                    rec = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    lgb = new LinearGradientBrush(rec, startc, endc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    break;
                case "Three":
                    rec = new Rectangle((int)(bmp.Width / 2), 0, bmp.Width / 2, bmp.Height);
                    lgb = new LinearGradientBrush(rec, midc, endc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    rec = new Rectangle(0, 0, (int)(bmp.Width/2)+1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, startc, midc, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    break;
                case "Parula":
                    scolor = Color.FromArgb(200,194,41);
                    ecolor = Color.FromArgb(250, 252, 21);
                    width = bmp.Width / 4;
                    rec = new Rectangle((int)(width * 3), 0, width, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(16, 191, 187);
                    ecolor = Color.FromArgb(200, 194, 41);
                    rec = new Rectangle((int)(width * 2), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(53, 121, 254);
                    ecolor = Color.FromArgb(16, 191, 187);
                    rec = new Rectangle((int)(width * 1), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(62, 39, 169);
                    ecolor = Color.FromArgb(53, 121, 254);
                    rec = new Rectangle((int)(width * 0), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    break;
                case "Turbo":
                    break;
                case "Jet":
                    scolor = Color.FromArgb(255, 0, 0);
                    ecolor = Color.FromArgb(127, 0, 0);
                    width = bmp.Width / 8;
                    rec = new Rectangle((int)(width * 7), 0, width, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(255, 127, 0);
                    ecolor = Color.FromArgb(255, 0, 0);
                    rec = new Rectangle((int)(width * 6), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(255, 255, 0);
                    ecolor = Color.FromArgb(255, 127, 0);
                    rec = new Rectangle((int)(width * 5), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(127, 255, 127);
                    ecolor = Color.FromArgb(255, 255, 0);
                    rec = new Rectangle((int)(width * 4), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(0, 255, 255);
                    ecolor = Color.FromArgb(127, 255, 127);
                    rec = new Rectangle((int)(width * 3), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(0, 127, 255);
                    ecolor = Color.FromArgb(0, 255, 255);
                    rec = new Rectangle((int)(width * 2), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(0, 0, 255);
                    ecolor = Color.FromArgb(0, 127, 255);
                    rec = new Rectangle((int)(width * 1), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
                    scolor = Color.FromArgb(0, 0, 127);
                    ecolor = Color.FromArgb(0, 0, 255);
                    rec = new Rectangle((int)(width * 0), 0, width + 1, bmp.Height);
                    lgb = new LinearGradientBrush(rec, scolor, ecolor, LinearGradientMode.Horizontal);
                    g.FillRectangle(lgb, rec);
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
            else return;

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
