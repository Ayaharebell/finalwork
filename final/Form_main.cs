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

        const int width = 36;
        int player = 0;
        /*表示玩家
         * 0 none
         * 1 red
         * 2 blue
         * 3 yellow
         * 4 green
         */
        Point[] points = {
            new Point((int)(6 * width), (int)(0.5 * width)),
            new Point((int)(7 * width), (int)(0.5 * width)),
            new Point((int)(8 * width), (int)(0.5 * width)),//红家门口
            new Point((int)(9 * width), (int)(0.5 * width)),
            new Point((int)(10 * width), (int)(0.5 * width)),
            new Point((int)(11 * width), (int)(1 * width)),
            new Point((int)(11.5 * width), (int)(2 * width)),
            new Point((int)(11.5 * width), (int)(3 * width)),
            new Point((int)(11 * width), (int)(4 * width)),
            new Point((int)(12 * width), (int)(5 * width)),//绿起飞
            new Point((int)(13 * width), (int)(4.5 * width)),
            new Point((int)(14 * width), (int)(4.5 * width)),
            new Point((int)(15 * width), (int)(5 * width)),
            new Point((int)(15.5 * width), (int)(6 * width)),
            new Point((int)(15.5 * width), (int)(7 * width)),
            new Point((int)(15.5 * width), (int)(8 * width)),//蓝家门口
            new Point((int)(15.5 * width), (int)(9 * width)),
            new Point((int)(15.5 * width), (int)(10 * width)),
            new Point((int)(15 * width), (int)(11 * width)),
            new Point((int)(14 * width), (int)(11.5 * width)),
            new Point((int)(13 * width), (int)(11.5 * width)),
            new Point((int)(12 * width), (int)(11 * width)),
            new Point((int)(11 * width), (int)(12 * width)),//红起飞
            new Point((int)(11.5 * width), (int)(13 * width)),
            new Point((int)(11.5 * width), (int)(14 * width)),
            new Point((int)(11 * width), (int)(15 * width)),
            new Point((int)(10 * width), (int)(15.5 * width)),
            new Point((int)(9 * width), (int)(15.5 * width)),
            new Point((int)(8 * width), (int)(15.5 * width)),//黄家门口
            new Point((int)(7 * width), (int)(15.5 * width)),
            new Point((int)(6 * width), (int)(15.5 * width)),
            new Point((int)(5 * width), (int)(15 * width)),
            new Point((int)(4.5 * width), (int)(14 * width)),
            new Point((int)(4.5 * width), (int)(13 * width)),
            new Point((int)(5 * width), (int)(12 * width)),
            new Point((int)(4 * width), (int)(11 * width)),//蓝起飞
            new Point((int)(3 * width), (int)(11.5 * width)),
            new Point((int)(2 * width), (int)(11.5 * width)),
            new Point((int)(1 * width), (int)(11 * width)),
            new Point((int)(0.5 * width), (int)(10 * width)),
            new Point((int)(0.5 * width), (int)(9 * width)),
            new Point((int)(0.5 * width), (int)(8 * width)),//绿家门口
            new Point((int)(0.5 * width), (int)(7 * width)),
            new Point((int)(0.5 * width), (int)(6 * width)),
            new Point((int)(1 * width), (int)(5 * width)),
            new Point((int)(2 * width), (int)(4.5 * width)),
            new Point((int)(3 * width), (int)(4.5 * width)),
            new Point((int)(4 * width), (int)(5 * width)),
            new Point((int)(5 * width), (int)(4 * width)),//黄起飞
            new Point((int)(4.5 * width), (int)(3 * width)),
            new Point((int)(4.5 * width), (int)(2 * width)),
            new Point((int)(5 * width), (int)(1 * width))
        };
        Point[] pointsRedHome = {
            new Point((int)(13.5*width),(int)(0.5*width)),
            new Point((int)(13.5*width),(int)(2.5*width)),
            new Point((int)(15.5*width),(int)(0.5*width)),
            new Point((int)(15.5*width),(int)(2.5*width))
        };
        Point[] pointsBlueHome = {
            new Point((int)(13.5*width),(int)(13.5*width)),
            new Point((int)(13.5*width),(int)(15.5*width)),
            new Point((int)(15.5*width),(int)(13.5*width)),
            new Point((int)(15.5*width),(int)(15.5*width))
        };
        Point[] pointsYellowHome = {
            new Point((int)(0.5*width),(int)(13.5*width)),
            new Point((int)(2.5*width),(int)(13.5*width)),
            new Point((int)(0.5*width),(int)(15.5*width)),
            new Point((int)(2.5*width),(int)(15.5*width))
        };
        Point[] pointsGreenHome = {
            new Point((int)(0.5*width),(int)(0.5*width)),
            new Point((int)(2.5*width),(int)(0.5*width)),
            new Point((int)(0.5*width),(int)(2.5*width)),
            new Point((int)(2.5*width),(int)(2.5*width))
        };
        Point[] pointsRedFinish = {
            new Point((int)(8 * width), (int)(0.5 * width)),
            new Point(8*width,2*width),
            new Point(8*width,3*width),
            new Point(8*width,4*width),
            new Point(8*width,5*width),
            new Point(8*width,6*width),
            new Point(8*width,7*width)
        };
        Point[] pointsBlueFinish =
        {
            new Point((int)(15.5 * width), (int)(8 * width)),
            new Point((int)(14 * width), (int)(8 * width)),
            new Point((int)(13 * width), (int)(8 * width)),
            new Point((int)(12 * width), (int)(8 * width)),
            new Point((int)(11 * width), (int)(8 * width)),
            new Point((int)(10 * width), (int)(8 * width)),
            new Point((int)(9 * width), (int)(8 * width))
        };
        Point[] pointsYellowFinish = {
            new Point((int)(8 * width), (int)(15.5 * width)),
            new Point(8*width,14*width),
            new Point(8*width,13*width),
            new Point(8*width,12*width),
            new Point(8*width,11*width),
            new Point(8*width,10*width),
            new Point(8*width,9*width)
        };
        Point[] pointsGreenFinish =
        {
            new Point((int)(0.5 * width), (int)(8 * width)),
            new Point((int)(2 * width), (int)(8 * width)),
            new Point((int)(3 * width), (int)(8 * width)),
            new Point((int)(4 * width), (int)(8 * width)),
            new Point((int)(5 * width), (int)(8 * width)),
            new Point((int)(6 * width), (int)(8 * width)),
            new Point((int)(7 * width), (int)(8 * width))
        };

        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            CreateMap();
            CreatePlane();
            dice.Location = new Point(18 * width, 16 * width);
            dice.Height = width;
            dice.Width = 2 * width;
        }
        public void CreatePlane()
        {
            red0.Image = Image.FromFile("red.png");
            red0.Size = new Size(24, 24);
            red0.Location = new Point((int)(pointsRedHome[0].X + width / 2 - 12), (int)(pointsRedHome[0].Y + width / 2) - 12);
            red1.Image = Image.FromFile("red.png");
            red1.Size = new Size(24, 24);
            red1.Location = new Point((int)(pointsRedHome[1].X + width / 2 - 12), (int)(pointsRedHome[1].Y + width / 2) - 12);
            red2.Image = Image.FromFile("red.png");
            red2.Size = new Size(24, 24);
            red2.Location = new Point((int)(pointsRedHome[2].X + width / 2 - 12), (int)(pointsRedHome[2].Y + width / 2) - 12);
            red3.Image = Image.FromFile("red.png");
            red3.Size = new Size(24, 24);
            red3.Location = new Point((int)(pointsRedHome[3].X + width / 2 - 12), (int)(pointsRedHome[3].Y + width / 2) - 12);
            blue0.Image = Image.FromFile("blue.png");
            blue0.Size = new Size(24, 24);
            blue0.Location = new Point((int)(pointsBlueHome[0].X + width / 2 - 12), (int)(pointsBlueHome[0].Y + width / 2) - 12);
            blue1.Image = Image.FromFile("blue.png");
            blue1.Size = new Size(24, 24);
            blue1.Location = new Point((int)(pointsBlueHome[1].X + width / 2 - 12), (int)(pointsBlueHome[1].Y + width / 2) - 12);
            blue2.Image = Image.FromFile("blue.png");
            blue2.Size = new Size(24, 24);
            blue2.Location = new Point((int)(pointsBlueHome[2].X + width / 2 - 12), (int)(pointsBlueHome[2].Y + width / 2) - 12);
            blue3.Image = Image.FromFile("blue.png");
            blue3.Size = new Size(24, 24);
            blue3.Location = new Point((int)(pointsBlueHome[3].X + width / 2 - 12), (int)(pointsBlueHome[3].Y + width / 2) - 12);
            yellow0.Image = Image.FromFile("orange.png");
            yellow0.Size = new Size(24, 24);
            yellow0.Location = new Point((int)(pointsYellowHome[0].X + width / 2 - 12), (int)(pointsYellowHome[0].Y + width / 2) - 12);
            yellow1.Image = Image.FromFile("orange.png");
            yellow1.Size = new Size(24, 24);
            yellow1.Location = new Point((int)(pointsYellowHome[1].X + width / 2 - 12), (int)(pointsYellowHome[1].Y + width / 2) - 12);
            yellow2.Image = Image.FromFile("orange.png");
            yellow2.Size = new Size(24, 24);
            yellow2.Location = new Point((int)(pointsYellowHome[2].X + width / 2 - 12), (int)(pointsYellowHome[2].Y + width / 2) - 12);
            yellow3.Image = Image.FromFile("orange.png");
            yellow3.Size = new Size(24, 24);
            yellow3.Location = new Point((int)(pointsYellowHome[3].X + width / 2 - 12), (int)(pointsYellowHome[3].Y + width / 2) - 12);
            green0.Image = Image.FromFile("green.png");
            green0.Size = new Size(24, 24);
            green0.Location = new Point((int)(pointsGreenHome[0].X + width / 2 - 12), (int)(pointsGreenHome[0].Y + width / 2) - 12);
            green1.Image = Image.FromFile("green.png");
            green1.Size = new Size(24, 24);
            green1.Location = new Point((int)(pointsGreenHome[1].X + width / 2 - 12), (int)(pointsGreenHome[1].Y + width / 2) - 12);
            green2.Image = Image.FromFile("green.png");
            green2.Size = new Size(24, 24);
            green2.Location = new Point((int)(pointsGreenHome[2].X + width / 2 - 12), (int)(pointsGreenHome[2].Y + width / 2) - 12);
            green3.Image = Image.FromFile("green.png");
            green3.Size = new Size(24, 24);
            green3.Location = new Point((int)(pointsGreenHome[3].X + width / 2 - 12), (int)(pointsGreenHome[3].Y + width / 2) - 12);
        }
        public void CreateMap()
        {
            Bitmap bitmap = new Bitmap(17 * width, 17 * width);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black, 2);
            Brush brushRed = new SolidBrush(Color.Red);
            Brush brushBlue = new SolidBrush(Color.Blue);
            Brush brushOrange = new SolidBrush(Color.Orange);
            Brush brushGreen = new SolidBrush(Color.LightGreen);
            Brush brushGray = new SolidBrush(Color.FromArgb(235, 235, 235));
            g.FillRectangle(brushOrange, new Rectangle(6 * width, 0, width, 2 * width));
            g.FillRectangle(brushGreen, new Rectangle(7 * width, 0, width, 2 * width));
            g.FillRectangle(brushRed, new Rectangle(8 * width, 0, width, 2 * width));
            g.FillRectangle(brushBlue, new Rectangle(9 * width, 0, width, 2 * width));
            g.FillRectangle(brushOrange, new Rectangle(10 * width, 0, width, 2 * width));
            Point point1 = new Point(6 * width, 0);
            Point point2 = new Point(6 * width, 2 * width);
            Point point3 = new Point(4 * width, 2 * width);
            Point[] pntArr = { point1, point2, point3 };
            g.FillPolygon(brushBlue, pntArr);
            Point point4 = new Point(11 * width, 0);
            Point point5 = new Point(11 * width, 2 * width);
            Point point6 = new Point(13 * width, 2 * width);
            Point[] pntArr2 = { point4, point5, point6 };
            g.FillPolygon(brushGreen, pntArr2);
            g.FillRectangle(brushRed, new Rectangle(4 * width, 2 * width, 2 * width, width));
            g.FillRectangle(brushGreen, new Rectangle(4 * width, 3 * width, 2 * width, width));
            g.FillRectangle(brushRed, new Rectangle(11 * width, 2 * width, 2 * width, width));
            g.FillRectangle(brushBlue, new Rectangle(11 * width, 3 * width, 2 * width, width));
            Point point7 = new Point(11 * width, 4 * width);
            Point point8 = new Point(11 * width, 6 * width);
            Point point9 = new Point(13 * width, 4 * width);
            Point[] pntArr3 = { point7, point8, point9 };
            g.FillPolygon(brushOrange, pntArr3);
            Point point10 = new Point(13 * width, 6 * width);
            Point point11 = new Point(11 * width, 6 * width);
            Point point12 = new Point(13 * width, 4 * width);
            Point[] pntArr4 = { point10, point11, point12 };
            g.FillPolygon(brushGreen, pntArr4);
            Point point13 = new Point(4 * width, 4 * width);
            Point point14 = new Point(6 * width, 6 * width);
            Point point15 = new Point(6 * width, 4 * width);
            Point[] pntArr5 = { point13, point14, point15 };
            g.FillPolygon(brushOrange, pntArr5);
            Point point16 = new Point(4 * width, 4 * width);
            Point point17 = new Point(4 * width, 6 * width);
            Point point18 = new Point(6 * width, 6 * width);
            Point[] pntArr6 = { point16, point17, point18 };
            g.FillPolygon(brushBlue, pntArr6);
            g.FillRectangle(brushGreen, new Rectangle(2 * width, 4 * width, width, 2 * width));
            g.FillRectangle(brushRed, new Rectangle(3 * width, 4 * width, width, 2 * width));
            g.FillRectangle(brushRed, new Rectangle(13 * width, 4 * width, width, 2 * width));
            g.FillRectangle(brushBlue, new Rectangle(14 * width, 4 * width, width, 2 * width));
            Point point19 = new Point(0 * width, 6 * width);
            Point point20 = new Point(2 * width, 4 * width);
            Point point21 = new Point(2 * width, 6 * width);
            Point[] pntArr7 = { point19, point20, point21 };
            g.FillPolygon(brushOrange, pntArr7);
            Point point22 = new Point(15 * width, 4 * width);
            Point point23 = new Point(15 * width, 6 * width);
            Point point24 = new Point(17 * width, 6 * width);
            Point[] pntArr8 = { point22, point23, point24 };
            g.FillPolygon(brushOrange, pntArr8);
            g.FillRectangle(brushBlue, new Rectangle(0 * width, 6 * width, 2 * width, width));
            g.FillRectangle(brushRed, new Rectangle(0 * width, 7 * width, 2 * width, width));
            g.FillRectangle(brushGreen, new Rectangle(15 * width, 6 * width, 2 * width, width));
            g.FillRectangle(brushRed, new Rectangle(15 * width, 7 * width, 2 * width, width));
            g.FillRectangle(brushRed, new Rectangle(8 * width, 2 * width, 1 * width, 5 * width));
            Point point25 = new Point(7 * width, 7 * width);
            Point point26 = new Point(10 * width, 7 * width);
            Point point27 = new Point(306, 306);
            Point[] pntArr9 = { point25, point26, point27 };
            g.FillPolygon(brushRed, pntArr9);
            g.FillRectangle(brushGreen, new Rectangle(0 * width, 8 * width, 7 * width, 1 * width));
            Point point28 = new Point(7 * width, 7 * width);
            Point point29 = new Point(7 * width, 10 * width);
            Point point30 = new Point(306, 306);
            Point[] pntArr10 = { point28, point29, point30 };
            g.FillPolygon(brushGreen, pntArr10);
            g.FillRectangle(brushGreen, new Rectangle(0 * width, 0 * width, 4 * width, 4 * width));
            g.FillRectangle(brushRed, new Rectangle(13 * width, 0 * width, 4 * width, 4 * width));
            g.FillRectangle(brushOrange, new Rectangle(0 * width, 13 * width, 4 * width, 4 * width));
            g.FillRectangle(brushBlue, new Rectangle(13 * width, 13 * width, 4 * width, 4 * width));
            g.FillRectangle(brushOrange, new Rectangle(8 * width, 10 * width, 1 * width, 7 * width));
            Point point31 = new Point(7 * width, 10 * width);
            Point point32 = new Point(10 * width, 10 * width);
            Point point33 = new Point(306, 306);
            Point[] pntArr11 = { point31, point32, point33 };
            g.FillPolygon(brushOrange, pntArr11);
            g.FillRectangle(brushBlue, new Rectangle(10 * width, 8 * width, 7 * width, 1 * width));
            Point point34 = new Point(10 * width, 7 * width);
            Point point35 = new Point(10 * width, 10 * width);
            Point point36 = new Point(306, 306);
            Point[] pntArr12 = { point34, point35, point36 };
            g.FillPolygon(brushBlue, pntArr12);
            g.DrawLine(pen, 0, 0, 0, 4 * width);
            g.DrawLine(pen, 0, 0, 4 * width, 0);
            g.DrawLine(pen, 0, 4 * width, 4 * width, 4 * width);
            g.DrawLine(pen, 4 * width, 0, 4 * width, 4 * width);
            g.DrawLine(pen, 13 * width, 0, 17 * width, 0);
            g.DrawLine(pen, 13 * width, 4 * width, 17 * width, 4 * width);
            g.DrawLine(pen, 13 * width, 4 * width, 13 * width, 0);
            g.DrawLine(pen, 17 * width, 0, 17 * width, 4 * width);
            g.DrawLine(pen, 0, 13 * width, 0, 17 * width);
            g.DrawLine(pen, 4 * width, 13 * width, 4 * width, 17 * width);
            g.DrawLine(pen, 0, 13 * width, 4 * width, 13 * width);
            g.DrawLine(pen, 0, 17 * width, 4 * width, 17 * width);
            g.DrawLine(pen, 13 * width, 13 * width, 13 * width, 17 * width);
            g.DrawLine(pen, 13 * width, 17 * width, 17 * width, 17 * width);
            g.DrawLine(pen, 13 * width, 13 * width, 17 * width, 13 * width);
            g.DrawLine(pen, 17 * width, 13 * width, 17 * width, 17 * width);
            g.FillRectangle(brushOrange, new Rectangle(0 * width, 9 * width, 2 * width, 1 * width));
            g.FillRectangle(brushBlue, new Rectangle(0 * width, 10 * width, 2 * width, 1 * width));
            g.FillRectangle(brushOrange, new Rectangle(15 * width, 9 * width, 2 * width, 1 * width));
            g.FillRectangle(brushGreen, new Rectangle(15 * width, 10 * width, 2 * width, 1 * width));
            g.FillRectangle(brushGreen, new Rectangle(2 * width, 11 * width, 1 * width, 2 * width));
            g.FillRectangle(brushBlue, new Rectangle(14 * width, 11 * width, 1 * width, 2 * width));
            g.FillRectangle(brushOrange, new Rectangle(13 * width, 11 * width, 1 * width, 2 * width));
            g.FillRectangle(brushOrange, new Rectangle(3 * width, 11 * width, 1 * width, 2 * width));
            g.FillRectangle(brushGreen, new Rectangle(4 * width, 13 * width, 2 * width, 1 * width));
            g.FillRectangle(brushOrange, new Rectangle(4 * width, 14 * width, 2 * width, 1 * width));
            g.FillRectangle(brushBlue, new Rectangle(11 * width, 13 * width, 2 * width, 1 * width));
            g.FillRectangle(brushOrange, new Rectangle(11 * width, 14 * width, 2 * width, 1 * width));
            g.FillRectangle(brushRed, new Rectangle(6 * width, 15 * width, 1 * width, 2 * width));
            g.FillRectangle(brushGreen, new Rectangle(7 * width, 15 * width, 1 * width, 2 * width));
            g.FillRectangle(brushBlue, new Rectangle(9 * width, 15 * width, 1 * width, 2 * width));
            g.FillRectangle(brushRed, new Rectangle(10 * width, 15 * width, 1 * width, 2 * width));
            Point point37 = new Point(0 * width, 11 * width);
            Point point38 = new Point(2 * width, 11 * width);
            Point point39 = new Point(2 * width, 13 * width);
            Point[] pntArr13 = { point37, point38, point39 };
            g.FillPolygon(brushRed, pntArr13);
            Point point40 = new Point(6 * width, 11 * width);
            Point point41 = new Point(6 * width, 13 * width);
            Point point42 = new Point(4 * width, 13 * width);
            Point[] pntArr14 = { point40, point41, point42 };
            g.FillPolygon(brushRed, pntArr14);
            Point point43 = new Point(11 * width, 11 * width);
            Point point44 = new Point(11 * width, 13 * width);
            Point point45 = new Point(13 * width, 13 * width);
            Point[] pntArr15 = { point43, point44, point45 };
            g.FillPolygon(brushRed, pntArr15);
            Point point46 = new Point(17 * width, 11 * width);
            Point point47 = new Point(15 * width, 11 * width);
            Point point48 = new Point(15 * width, 13 * width);
            Point[] pntArr16 = { point46, point47, point48 };
            g.FillPolygon(brushRed, pntArr16);
            Point point49 = new Point(4 * width, 11 * width);
            Point point50 = new Point(4 * width, 13 * width);
            Point point51 = new Point(6 * width, 11 * width);
            Point[] pntArr17 = { point49, point50, point51 };
            g.FillPolygon(brushBlue, pntArr17);
            Point point52 = new Point(4 * width, 15 * width);
            Point point53 = new Point(6 * width, 15 * width);
            Point point54 = new Point(6 * width, 17 * width);
            Point[] pntArr18 = { point52, point53, point54 };
            g.FillPolygon(brushBlue, pntArr18);
            Point point55 = new Point(11 * width, 15 * width);
            Point point56 = new Point(13 * width, 15 * width);
            Point point57 = new Point(11 * width, 17 * width);
            Point[] pntArr19 = { point55, point56, point57 };
            g.FillPolygon(brushGreen, pntArr19);
            Point point58 = new Point(11 * width, 11 * width);
            Point point59 = new Point(13 * width, 11 * width);
            Point point60 = new Point(13 * width, 13 * width);
            Point[] pntArr20 = { point58, point59, point60 };
            g.FillPolygon(brushGreen, pntArr20);
            for(int i = 0;i < points.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(points[i].X, points[i].Y, width, width));
            }
            for(int i = 0; i < pointsRedHome.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsRedHome[i].X, pointsRedHome[i].Y, width, width));
            }
            for (int i = 0; i < pointsBlueHome.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsBlueHome[i].X, pointsBlueHome[i].Y, width, width));
            }
            for (int i = 0; i < pointsYellowHome.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsYellowHome[i].X, pointsYellowHome[i].Y, width, width));
            }
            for (int i = 0; i < pointsGreenHome.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsGreenHome[i].X, pointsGreenHome[i].Y, width, width));
            }
            for (int i = 1; i < pointsRedFinish.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsRedFinish[i].X, pointsRedFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsBlueFinish.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsBlueFinish[i].X, pointsBlueFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsYellowFinish.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsYellowFinish[i].X, pointsYellowFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsGreenFinish.Length; i++)
            {
                g.FillEllipse(brushGray, new Rectangle(pointsGreenFinish[i].X, pointsGreenFinish[i].Y, width, width));
            }
            pictureBox1.Image = bitmap;
        }

    }
}
