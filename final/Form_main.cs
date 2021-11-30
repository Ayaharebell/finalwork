using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class Form_main : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        const int width = 30;
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(17 * width, 17 * width);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black, 2);
            Brush brushRed = new SolidBrush(Color.Red);
            Brush brushBlue = new SolidBrush(Color.Blue);
            Brush brushOrange = new SolidBrush(Color.Orange);
            Brush brushGreen = new SolidBrush(Color.LightGreen);
            Brush brushWhite = new SolidBrush(Color.White);
            g.FillRectangle(brushOrange, new Rectangle(6 * width, 0, width, 2 * width));
            g.FillRectangle(brushGreen, new Rectangle(7 * width, 0, width, 2 * width));

            pictureBox1.Image = bitmap;
        }
    }
}
