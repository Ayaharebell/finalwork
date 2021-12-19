using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace final
{
    public partial class Form_main : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        Cell[] cells = {
            new Cell(new Point((int)(6 * width), (int)(0 * width)),1,3),
            new Cell(new Point((int)(7 * width), (int)(0 * width)),1,4),
            new Cell(new Point((int)(8 * width), (int)(0 * width)),1,1),//redFinish
            new Cell(new Point((int)(9 * width), (int)(0 * width)),1,2),
            new Cell(new Point((int)(10 * width), (int)(0 * width)),1,3),
            new Cell(new Point((int)(11 * width), (int)(0 * width)),3,4),
            new Cell(new Point((int)(11 * width), (int)(2 * width)),2,1),
            new Cell(new Point((int)(11 * width), (int)(3 * width)),2,2),
            new Cell(new Point((int)(11 * width), (int)(4 * width)),5,3),
            new Cell(new Point((int)(11 * width), (int)(4 * width)),4,4),
            new Cell(new Point((int)(13 * width), (int)(4 * width)),1,1),
            new Cell(new Point((int)(14 * width), (int)(4 * width)),1,2),
            new Cell(new Point((int)(15 * width), (int)(4 * width)),3,3),
            new Cell(new Point((int)(15 * width), (int)(6 * width)),2,4),
            new Cell(new Point((int)(15 * width), (int)(7 * width)),2,1),
            new Cell(new Point((int)(15 * width), (int)(8 * width)),2,2),//蓝
            new Cell(new Point((int)(15 * width), (int)(9 * width)),2,3),
            new Cell(new Point((int)(15 * width), (int)(10 * width)),2,4),
            new Cell(new Point((int)(15 * width), (int)(11 * width)),5,1),
            new Cell(new Point((int)(14 * width), (int)(11 * width)),1,2),
            new Cell(new Point((int)(13 * width), (int)(11 * width)),1,3),
            new Cell(new Point((int)(11 * width), (int)(11 * width)),6,4),
            new Cell(new Point((int)(11 * width), (int)(11 * width)),3,1),
            new Cell(new Point((int)(11 * width), (int)(13 * width)),2,2),
            new Cell(new Point((int)(11 * width), (int)(14 * width)),2,3),
            new Cell(new Point((int)(11 * width), (int)(15 * width)),5,4),
            new Cell(new Point((int)(10 * width), (int)(15 * width)),1,1),
            new Cell(new Point((int)(9 * width), (int)(15 * width)),1,2),
            new Cell(new Point((int)(8 * width), (int)(15 * width)),1,3),//黄
            new Cell(new Point((int)(7 * width), (int)(15 * width)),1,4),
            new Cell(new Point((int)(6 * width), (int)(15 * width)),1,1),
            new Cell(new Point((int)(4 * width), (int)(15 * width)),6,2),
            new Cell(new Point((int)(4 * width), (int)(14 * width)),2,3),
            new Cell(new Point((int)(4 * width), (int)(13 * width)),2,4),
            new Cell(new Point((int)(4 * width), (int)(11 * width)),4,1),
            new Cell(new Point((int)(4 * width), (int)(11 * width)),5,2),
            new Cell(new Point((int)(3 * width), (int)(11 * width)),1,3),
            new Cell(new Point((int)(2 * width), (int)(11 * width)),1,4),
            new Cell(new Point((int)(0 * width), (int)(11 * width)),6,1),
            new Cell(new Point((int)(0 * width), (int)(10 * width)),2,2),
            new Cell(new Point((int)(0 * width), (int)(9 * width)),2,3),
            new Cell(new Point((int)(0 * width), (int)(8 * width)),2,4),//绿
            new Cell(new Point((int)(0 * width), (int)(7 * width)),2,1),
            new Cell(new Point((int)(0 * width), (int)(6 * width)),2,2),
            new Cell(new Point((int)(0 * width), (int)(4 * width)),4,3),
            new Cell(new Point((int)(2 * width), (int)(4 * width)),1,4),
            new Cell(new Point((int)(3 * width), (int)(4 * width)),1,1),
            new Cell(new Point((int)(4 * width), (int)(4 * width)),3,2),
            new Cell(new Point((int)(4 * width), (int)(4 * width)),6,3),
            new Cell(new Point((int)(4 * width), (int)(3 * width)),2,4),
            new Cell(new Point((int)(4 * width), (int)(2 * width)),2,1),
            new Cell(new Point((int)(4 * width), (int)(0 * width)),4,2)
        };

        const int width = 36;
        int player = 1;
        /*表示玩家
         * 0 none
         * 1 red
         * 2 blue
         * 3 yellow
         * 4 green
         */
        int finishRed = 0;
        int finishBlue = 0;
        int finishYellow = 0;
        int finishGreen = 0;
        /* 完成游戏的棋子数
         * 每完成一个，value++
         * 当一个人为4时，游戏结束
         */
        int liveRed = 0;
        int liveBlue = 0;
        int liveYellow = 0;
        int liveGreen = 0;
        Random random = new Random();
        int diceNum;

        /*应该用二维数组，现在一维数组代码还有很多重复的地方*/
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
            new Point((int)(5 * width), (int)(1 * width)),
            new Point((int)(6 * width), (int)(0.5 * width)),
            new Point((int)(7 * width), (int)(0.5 * width)),
            new Point((int)(8 * width), (int)(0.5 * width))//红家门口
            /*
             * 2021.12.16
             * 这部分重复，通过这种方法来避免红色在最后一段路上出现重复的问题
             */
        };
        Point[] pointsRedHome = {
            new Point((int)(13.5*width),(int)(0.5*width)),
            new Point((int)(15.5*width),(int)(0.5*width)),
            new Point((int)(13.5*width),(int)(2.5*width)),
            new Point((int)(15.5*width),(int)(2.5*width))
        };
        Point[] pointsBlueHome = {
            new Point((int)(13.5*width),(int)(13.5*width)),
            new Point((int)(15.5*width),(int)(13.5*width)),
            new Point((int)(13.5*width),(int)(15.5*width)),
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
        Plane[] planesRed = {
            new Plane(true, false, false, 0),
            new Plane(true, false, false, 1),
            new Plane(true, false, false, 2),
            new Plane(true, false, false, 3)
        };
        Plane[] planesBlue = {
            new Plane(true, false, false, 0),
            new Plane(true, false, false, 1),
            new Plane(true, false, false, 2),
            new Plane(true, false, false, 3)
        };
        Plane[] planesYellow = {
            new Plane(true, false, false, 0),
            new Plane(true, false, false, 1),
            new Plane(true, false, false, 2),
            new Plane(true, false, false, 3)
        };
        Plane[] planesGreen = {
            new Plane(true, false, false, 0),
            new Plane(true, false, false, 1),
            new Plane(true, false, false, 2),
            new Plane(true, false, false, 3)
        };

        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            CreateMap();
            CreatePlane();
            startButton.Location = new Point(17 * width, 16 * width);
            startButton.Height = 3 * width / 2;
            startButton.Width = 3 * width / 2;
            throwDice.Location = new Point(19 * width, 16 * width);
            throwDice.Height = 3 * width / 2;
            throwDice.Width = 3 * width / 2;
            openAndSave.Location = new Point(21 * width, 16 * width);
            openAndSave.Height = 3 * width / 2;
            openAndSave.Width = 3 * width / 2;
            gameRecord.Location = new Point(18 * width, 1 * width);
            gameRecord.Height = 10 * width;
            gameRecord.Width = 4 * width;
            diceShow.Location = new Point(19 * width, 13 * width);
            diceShow.Height = 2 * width;
            diceShow.Width = 2 * width;
            throwDice.Enabled = false;
            board.Enabled = false;
            label1.Location = new Point(19 * width, 12 * width);
            label1.Height = 2 * width;
            label1.Width = 2 * width;
        }
        
        public void CreatePlane()
        {
            //绘制棋子
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
            //绘制棋盘
            Bitmap bitmap = new Bitmap(17 * width, 17 * width);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black, 2);
            Brush brushRed = new SolidBrush(Color.Red);
            Brush brushBlue = new SolidBrush(Color.Blue);
            Brush brushOrange = new SolidBrush(Color.Orange);
            Brush brushGreen = new SolidBrush(Color.LightGreen);
            Brush brushGray = new SolidBrush(Color.FromArgb(235, 235, 235));
            for(int i = 0;i < cells.Length; i++)
            {
                if (cells[i].Extend == 1)
                {
                    if (cells[i].CellColor == 1)
                    {
                        g.FillRectangle(brushRed, cells[i].Point.X, cells[i].Point.Y, width, 2 * width);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillRectangle(brushBlue, cells[i].Point.X, cells[i].Point.Y, width, 2 * width);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillRectangle(brushOrange, cells[i].Point.X, cells[i].Point.Y, width, 2 * width);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillRectangle(brushGreen, cells[i].Point.X, cells[i].Point.Y, width, 2 * width);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X, cells[i].Point.Y + width / 2, width, width));
                }
                else if (cells[i].Extend == 2)
                {
                    if (cells[i].CellColor == 1)
                    {
                        g.FillRectangle(brushRed, cells[i].Point.X, cells[i].Point.Y, 2 * width, width);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillRectangle(brushBlue, cells[i].Point.X, cells[i].Point.Y, 2 * width, width);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillRectangle(brushOrange, cells[i].Point.X, cells[i].Point.Y, 2 * width, width);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillRectangle(brushGreen, cells[i].Point.X, cells[i].Point.Y, 2 * width, width);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X + width / 2, cells[i].Point.Y, width, width));
                }
                else if (cells[i].Extend == 3)
                {
                    Point point1 = new Point(cells[i].Point.X, cells[i].Point.Y);
                    Point point2 = new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width);
                    Point point3 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + 2 * width);
                    Point[] pointsArr = { point1, point2, point3 };
                    if (cells[i].CellColor == 1)
                    {
                        g.FillPolygon(brushRed, pointsArr);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillPolygon(brushBlue, pointsArr);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillPolygon(brushOrange, pointsArr);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillPolygon(brushGreen, pointsArr);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X, cells[i].Point.Y + width, width, width));
                }
                else if (cells[i].Extend == 4)
                {
                    Point point1 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y);
                    Point point2 = new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width);
                    Point point3 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + 2 * width);
                    Point[] pointsArr = { point1, point2, point3 };
                    if (cells[i].CellColor == 1)
                    {
                        g.FillPolygon(brushRed, pointsArr);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillPolygon(brushBlue, pointsArr);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillPolygon(brushOrange, pointsArr);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillPolygon(brushGreen, pointsArr);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X + width, cells[i].Point.Y + width, width, width));
                }
                else if (cells[i].Extend == 5)
                {
                    Point point1 = new Point(cells[i].Point.X, cells[i].Point.Y);
                    Point point2 = new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width);
                    Point point3 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y);
                    Point[] pointsArr = { point1, point2, point3 };
                    if (cells[i].CellColor == 1)
                    {
                        g.FillPolygon(brushRed, pointsArr);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillPolygon(brushBlue, pointsArr);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillPolygon(brushOrange, pointsArr);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillPolygon(brushGreen, pointsArr);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X, cells[i].Point.Y, width, width));
                }
                else if (cells[i].Extend == 6)
                {
                    Point point1 = new Point(cells[i].Point.X, cells[i].Point.Y);
                    Point point2 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + 2 * width);
                    Point point3 = new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y);
                    Point[] pointsArr = { point1, point2, point3 };
                    if (cells[i].CellColor == 1)
                    {
                        g.FillPolygon(brushRed, pointsArr);
                    }
                    else if (cells[i].CellColor == 2)
                    {
                        g.FillPolygon(brushBlue, pointsArr);
                    }
                    else if (cells[i].CellColor == 3)
                    {
                        g.FillPolygon(brushOrange, pointsArr);
                    }
                    else if (cells[i].CellColor == 4)
                    {
                        g.FillPolygon(brushGreen, pointsArr);
                    }
                    g.FillEllipse(brushGray, new Rectangle(cells[i].Point.X + width, cells[i].Point.Y, width, width));
                }
            }
            Point pointCenter = new Point(17 * width / 2, 17 * width / 2);
            Point pointTL = new Point(7 * width, 7 * width);
            Point pointTR = new Point(10 * width, 7 * width);
            Point pointBL = new Point(7 * width, 10 * width);
            Point pointBR = new Point(10 * width, 10 * width);
            g.FillPolygon(brushRed, new Point[]{ pointCenter,pointTL,pointTR});
            g.FillPolygon(brushBlue, new Point[] { pointCenter, pointTR, pointBR });
            g.FillPolygon(brushOrange, new Point[] { pointCenter, pointBR, pointBL });
            g.FillPolygon(brushGreen, new Point[] { pointCenter, pointBL, pointTL });
            g.FillRectangle(brushRed, 13 * width, 0, 4 * width, 4 * width);
            g.FillRectangle(brushBlue, 13 * width, 13*width, 4 * width, 4 * width);
            g.FillRectangle(brushOrange, 0, 13 * width, 4 * width, 4 * width);
            g.FillRectangle(brushGreen, 0, 0, 4 * width, 4 * width);
            g.DrawRectangle(pen, 13 * width, 0, 4 * width, 4 * width);
            g.DrawRectangle(pen, 13 * width, 13 * width, 4 * width, 4 * width);
            g.DrawRectangle(pen, 0, 13 * width, 4 * width, 4 * width);
            g.DrawRectangle(pen, 0, 0, 4 * width, 4 * width);
            for (int i = 0; i < pointsRedHome.Length; i++)
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
                g.FillRectangle(brushRed, new Rectangle(pointsRedFinish[i].X, pointsRedFinish[i].Y, width, width));
                g.FillEllipse(brushGray, new Rectangle(pointsRedFinish[i].X, pointsRedFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsBlueFinish.Length; i++)
            {
                g.FillRectangle(brushBlue, new Rectangle(pointsBlueFinish[i].X, pointsBlueFinish[i].Y, width, width));
                g.FillEllipse(brushGray, new Rectangle(pointsBlueFinish[i].X, pointsBlueFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsYellowFinish.Length; i++)
            {
                g.FillRectangle(brushOrange, new Rectangle(pointsYellowFinish[i].X, pointsYellowFinish[i].Y, width, width));
                g.FillEllipse(brushGray, new Rectangle(pointsYellowFinish[i].X, pointsYellowFinish[i].Y, width, width));
            }
            for (int i = 1; i < pointsGreenFinish.Length; i++)
            {
                g.FillRectangle(brushGreen, new Rectangle(pointsGreenFinish[i].X, pointsGreenFinish[i].Y, width, width));
                g.FillEllipse(brushGray, new Rectangle(pointsGreenFinish[i].X, pointsGreenFinish[i].Y, width, width));
            }
            board.Image = bitmap;
        }

        /*
         * 判断点是否在三角形内
         * 点和三角形三个点所围成的三角形的面积与三角形面积之和做比较
         * 考虑到计算精度问题，面积差异在0.1f以内即认为在内部
         * 但边界到底会不会出问题我也不知道
         * 
         * 矩形是转成四个三角形判断
         */
        private float triangleArea(float x0,float y0,float x1,float y1,float x2,float y2)
        {
            return Math.Abs((x0 * y1 + x1 * y2 + x2 * y0 - x1 * y0 - x2 * y1 - x0 * y2) / 2f);
        }

        private Boolean isContain(Point point0,Point point1,Point point2,Point point3)
        {
            //三角形
            float x0 = (float)point0.X;
            float y0 = (float)point0.Y;
            float x1 = (float)point1.X;
            float y1 = (float)point1.Y;
            float x2 = (float)point2.X;
            float y2 = (float)point2.Y;
            float x3 = (float)point3.X;
            float y3 = (float)point3.Y;
            float t = triangleArea(x1, y1, x2, y2, x3, y3);
            float a = triangleArea(x0, y0, x1, y1, x2, y2) + triangleArea(x0, y0, x2, y2, x3, y3) + triangleArea(x0, y0, x3, y3, x1, y1);
            if (Math.Abs(t - a) <= 1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean isContain(Point point0,Point point1,Point point2,Point point3,Point point4)
        {
            //矩形
            float x0 = (float)point0.X;
            float y0 = (float)point0.Y;
            float x1 = (float)point1.X;
            float y1 = (float)point1.Y;
            float x2 = (float)point2.X;
            float y2 = (float)point2.Y;
            float x3 = (float)point3.X;
            float y3 = (float)point3.Y;
            float x4 = (float)point4.X;
            float y4 = (float)point4.Y;
            float t = (x2 - x1) * (y4 - y1);
            float a = triangleArea(x0, y0, x1, y1, x2, y2) + triangleArea(x0, y0, x2, y2, x3, y3) + triangleArea(x0, y0, x3, y3, x4, y4) + +triangleArea(x0, y0, x4, y4, x1, y1);
            if (Math.Abs(t - a) <= 1f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private String searchLocation(Point pointClick)
        {
            //搜索点击位置
            int x = pointClick.X;
            int y = pointClick.Y;
            int isHome = 0;
            int isPlaying = 0;
            int isFinish = 0;
            int isWaiting = 0;
            int whichSelecte = -1;
            int index = -2;
            if (player == 1)
            {
                //判断点击的是哪个飞机
                if ((red0.Location.X - x) * (red0.Location.X + width - x) <= 0 && (red0.Location.Y - y) * (red0.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 0;
                }
                else if ((red1.Location.X - x) * (red1.Location.X + width - x) <= 0 && (red1.Location.Y - y) * (red1.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 1;
                }
                else if ((red2.Location.X - x) * (red2.Location.X + width - x) <= 0 && (red2.Location.Y - y) * (red2.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 2;
                }
                else if ((red3.Location.X - x) * (red3.Location.X + width - x) <= 0 && (red3.Location.Y - y) * (red3.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 3;
                }
                //判断按下的位置在那个方框
                for (int i = 0; i < pointsRedHome.Length; i++)
                {
                    if ((pointsRedHome[i].X - x) * (pointsRedHome[i].X + width - x) <= 0 && (pointsRedHome[i].Y - y) * (pointsRedHome[i].Y + width - y) <= 0)
                    {
                        index = i;
                        isHome = 1;
                        break;
                    }
                }
                //如果不是家里的话，则先在结束地方进行查找
                if (isHome == 0)
                {
                    for (int i = 0; i < pointsRedFinish.Length - 1; i++)
                    {
                        if ((pointsRedFinish[i].X - x) * (pointsRedFinish[i].X + width - x) < 0 && (pointsRedFinish[i].Y - y) * (pointsRedFinish[i].Y + width - y) < 0)
                        {
                            index = i;
                            isFinish = 1;
                            break;
                        }
                    }
                }
                //等待区域的判断
                if(isHome == 0&&isFinish == 0)
                {
                    if (isContain(pointClick, new Point(11 * width, 0 * width), new Point(13 * width, 0 * width), new Point(13 * width, 2 * width)))
                    {
                        isWaiting = 1;
                        index = -1;
                    }
                }
            }
            else if (player == 2)
            {
                if ((blue0.Location.X - x) * (blue0.Location.X + width - x) <= 0 && (blue0.Location.Y - y) * (blue0.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 0;
                }
                else if ((blue1.Location.X - x) * (blue1.Location.X + width - x) <= 0 && (blue1.Location.Y - y) * (blue1.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 1;
                }
                else if ((blue2.Location.X - x) * (blue2.Location.X + width - x) <= 0 && (blue2.Location.Y - y) * (blue2.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 2;
                }
                else if ((blue3.Location.X - x) * (blue3.Location.X + width - x) <= 0 && (blue3.Location.Y - y) * (blue3.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 3;
                }
                for (int i = 0; i < pointsBlueHome.Length; i++)
                {
                    if ((pointsBlueHome[i].X - x) * (pointsBlueHome[i].X + width - x) <= 0 && (pointsBlueHome[i].Y - y) * (pointsBlueHome[i].Y + width - y) <= 0)
                    {
                        index = i;
                        isHome = 1;
                        break;
                    }
                }
                if (isHome == 0)
                {
                    for (int i = 0; i < pointsBlueFinish.Length - 1; i++)
                    {
                        if ((pointsBlueFinish[i].X - x) * (pointsBlueFinish[i].X + width - x) < 0 && (pointsBlueFinish[i].Y - y) * (pointsBlueFinish[i].Y + width - y) < 0)
                        {
                            index = i;
                            isFinish = 1;
                            break;
                        }
                    }
                }
                if (isHome == 0 && isFinish == 0)
                {
                    if (isContain(pointClick, new Point(15 * width, 13 * width), new Point(17 * width, 13 * width), new Point(17 * width, 11 * width)))
                    {
                        isWaiting = 1;
                        index = -1;
                    }
                }
            }
            else if (player == 3)
            {
                //判断点击的是哪个飞机
                if ((yellow0.Location.X - x) * (yellow0.Location.X + width - x) <= 0 && (yellow0.Location.Y - y) * (yellow0.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 0;
                }
                else if ((yellow1.Location.X - x) * (yellow1.Location.X + width - x) <= 0 && (yellow1.Location.Y - y) * (yellow1.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 1;
                }
                else if ((yellow2.Location.X - x) * (yellow2.Location.X + width - x) <= 0 && (yellow2.Location.Y - y) * (yellow2.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 2;
                }
                else if ((yellow3.Location.X - x) * (yellow3.Location.X + width - x) <= 0 && (yellow3.Location.Y - y) * (yellow3.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 3;
                }
                for (int i = 0; i < pointsYellowHome.Length; i++)
                {
                    //判断按下的位置在那个方框
                    if ((pointsYellowHome[i].X - x) * (pointsYellowHome[i].X + width - x) <= 0 && (pointsYellowHome[i].Y - y) * (pointsYellowHome[i].Y + width - y) <= 0)
                    {
                        index = i;
                        isHome = 1;
                        break;
                    }
                }
                //下面的都是有问题的，因为方框不是标准正方形
                if (isHome == 0)
                {
                    for (int i = 0; i < pointsYellowFinish.Length - 1; i++)
                    {
                        if ((pointsYellowFinish[i].X - x) * (pointsYellowFinish[i].X + width - x) < 0 && (pointsYellowFinish[i].Y - y) * (pointsYellowFinish[i].Y + width - y) < 0)
                        {
                            index = i;
                            isFinish = 1;
                            break;
                        }
                    }
                }
                if (isHome == 0 && isFinish == 0)
                {
                    if (isContain(pointClick, new Point(4 * width, 15 * width), new Point(4 * width, 17 * width), new Point(6 * width, 17 * width)))
                    {
                        isWaiting = 1;
                        index = -1;
                    }
                }
            }
            else if (player == 4)
            {
                //判断点击的是哪个飞机
                if ((green0.Location.X - x) * (green0.Location.X + width - x) <= 0 && (green0.Location.Y - y) * (green0.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 0;
                }
                else if ((green1.Location.X - x) * (green1.Location.X + width - x) <= 0 && (green1.Location.Y - y) * (green1.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 1;
                }
                else if ((green2.Location.X - x) * (green2.Location.X + width - x) <= 0 && (green2.Location.Y - y) * (green2.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 2;
                }
                else if ((green3.Location.X - x) * (green3.Location.X + width - x) <= 0 && (green3.Location.Y - y) * (green3.Location.Y + width - y) <= 0)
                {
                    whichSelecte = 3;
                }
                for (int i = 0; i < pointsGreenHome.Length; i++)
                {
                    //判断按下的位置在那个方框
                    if ((pointsGreenHome[i].X - x) * (pointsGreenHome[i].X + width - x) <= 0 && (pointsGreenHome[i].Y - y) * (pointsGreenHome[i].Y + width - y) <= 0)
                    {
                        index = i;
                        isHome = 1;
                        break;
                    }
                }
                //下面的都是有问题的，因为方框不是标准正方形
                if (isHome == 0)
                {
                    for (int i = 0; i < pointsGreenFinish.Length - 1; i++)
                    {
                        if ((pointsGreenFinish[i].X - x) * (pointsGreenFinish[i].X + width - x) < 0 && (pointsGreenFinish[i].Y - y) * (pointsGreenFinish[i].Y + width - y) < 0)
                        {
                            index = i;
                            isFinish = 1;
                            break;
                        }
                    }
                }
                if (isHome == 0 && isFinish == 0)
                {
                    if (isContain(pointClick, new Point(0 * width, 4 * width), new Point(0 * width, 6 * width), new Point(2 * width, 4 * width)))
                    {
                        isWaiting = 1;
                        index = -1;
                    }
                }
            }
            //既不在家也不在结束的地方
            if (isHome == 0 && isFinish == 0 && isWaiting == 0)
            {
                for(int i = 0; i < cells.Length; i++)
                {
                    if (cells[i].Extend == 1)
                    {
                        if (isContain(pointClick, cells[i].Point, new Point(cells[i].Point.X + width, cells[i].Point.Y), new Point(cells[i].Point.X + width, cells[i].Point.Y + 2 * width), new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                    else if (cells[i].Extend == 2)
                    {
                        if (isContain(pointClick, cells[i].Point, new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y), new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + width), new Point(cells[i].Point.X, cells[i].Point.Y + width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                    else if(cells[i].Extend == 3)
                    {
                        if(isContain(pointClick,cells[i].Point,new Point(cells[i].Point.X + 2*width,cells[i].Point.Y+2*width),new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                    else if (cells[i].Extend == 4)
                    {
                        if (isContain(pointClick, new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y), new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + 2 * width), new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                    else if (cells[i].Extend == 5)
                    {
                        if (isContain(pointClick, cells[i].Point, new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y), new Point(cells[i].Point.X, cells[i].Point.Y + 2 * width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                    else if (cells[i].Extend == 6)
                    {
                        if (isContain(pointClick, cells[i].Point, new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y), new Point(cells[i].Point.X + 2 * width, cells[i].Point.Y + 2 * width)))
                        {
                            isPlaying = 1;
                            index = i;
                        }
                    }
                }
            }
            String result = "" + isHome + isPlaying + isFinish + isWaiting + whichSelecte + index;
            //MessageBox.Show(result);
            return result;
        }

        private void eat(PictureBox pic)
        {
            /*
             * 两个子在一起，后者吃前子
             * 一个个遍历过去，如果一开始采用数组来存棋子不知道能不能优化一下
             */
            if (pic.Name.Substring(0,3).Equals("red"))
            {
                if(pic.Location == blue0.Location)
                {
                    blue0.Location = new Point(pointsBlueHome[0].X + 6, pointsBlueHome[0].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue1.Location)
                {
                    blue1.Location = new Point(pointsBlueHome[1].X + 6, pointsBlueHome[1].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue2.Location)
                {
                    blue2.Location = new Point(pointsBlueHome[2].X + 6, pointsBlueHome[2].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue3.Location)
                {
                    blue3.Location = new Point(pointsBlueHome[3].X + 6, pointsBlueHome[3].Y + 6);
                    liveBlue--;
                }

                else if (pic.Location == yellow0.Location)
                {
                    yellow0.Location = new Point(pointsYellowHome[0].X + 6, pointsYellowHome[0].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow1.Location)
                {
                    yellow1.Location = new Point(pointsYellowHome[1].X + 6, pointsYellowHome[1].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow2.Location)
                {
                    yellow2.Location = new Point(pointsYellowHome[2].X + 6, pointsYellowHome[2].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow3.Location)
                {
                    yellow3.Location = new Point(pointsYellowHome[3].X + 6, pointsYellowHome[3].Y + 6);
                    liveYellow--;
                }

                else if (pic.Location == green0.Location)
                {
                    green0.Location = new Point(pointsGreenHome[0].X + 6, pointsGreenHome[0].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green1.Location)
                {
                    green1.Location = new Point(pointsGreenHome[1].X + 6, pointsGreenHome[1].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green2.Location)
                {
                    green2.Location = new Point(pointsGreenHome[2].X + 6, pointsGreenHome[2].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green3.Location)
                {
                    green3.Location = new Point(pointsGreenHome[3].X + 6, pointsGreenHome[3].Y + 6);
                    liveGreen--;
                }
            }
            else if (pic.Name.Substring(0, 3).Equals("blu"))
            {
                if (pic.Location == red0.Location)
                {
                    red0.Location = new Point(pointsRedHome[0].X + 6, pointsRedHome[0].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red1.Location)
                {
                    red1.Location = new Point(pointsRedHome[1].X + 6, pointsRedHome[1].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red2.Location)
                {
                    red2.Location = new Point(pointsRedHome[2].X + 6, pointsRedHome[2].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red3.Location)
                {
                    red3.Location = new Point(pointsRedHome[3].X + 6, pointsRedHome[3].Y + 6);
                    liveRed--;
                }

                else if (pic.Location == yellow0.Location)
                {
                    yellow0.Location = new Point(pointsYellowHome[0].X + 6, pointsYellowHome[0].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow1.Location)
                {
                    yellow1.Location = new Point(pointsYellowHome[1].X + 6, pointsYellowHome[1].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow2.Location)
                {
                    yellow2.Location = new Point(pointsYellowHome[2].X + 6, pointsYellowHome[2].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow3.Location)
                {
                    yellow3.Location = new Point(pointsYellowHome[3].X + 6, pointsYellowHome[3].Y + 6);
                    liveYellow--;
                }

                else if (pic.Location == green0.Location)
                {
                    green0.Location = new Point(pointsGreenHome[0].X + 6, pointsGreenHome[0].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green1.Location)
                {
                    green1.Location = new Point(pointsGreenHome[1].X + 6, pointsGreenHome[1].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green2.Location)
                {
                    green2.Location = new Point(pointsGreenHome[2].X + 6, pointsGreenHome[2].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green3.Location)
                {
                    green3.Location = new Point(pointsGreenHome[3].X + 6, pointsGreenHome[3].Y + 6);
                    liveGreen--;
                }
            }
            else if (pic.Name.Substring(0, 3).Equals("yel"))
            {
                if (pic.Location == red0.Location)
                {
                    red0.Location = new Point(pointsRedHome[0].X + 6, pointsRedHome[0].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red1.Location)
                {
                    red1.Location = new Point(pointsRedHome[1].X + 6, pointsRedHome[1].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red2.Location)
                {
                    red2.Location = new Point(pointsRedHome[2].X + 6, pointsRedHome[2].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red3.Location)
                {
                    red3.Location = new Point(pointsRedHome[3].X + 6, pointsRedHome[3].Y + 6);
                    liveRed--;
                }

                else if (pic.Location == blue0.Location)
                {
                    blue0.Location = new Point(pointsBlueHome[0].X + 6, pointsBlueHome[0].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue1.Location)
                {
                    blue1.Location = new Point(pointsBlueHome[1].X + 6, pointsBlueHome[1].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue2.Location)
                {
                    blue2.Location = new Point(pointsBlueHome[2].X + 6, pointsBlueHome[2].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue3.Location)
                {
                    blue3.Location = new Point(pointsBlueHome[3].X + 6, pointsBlueHome[3].Y + 6);
                    liveBlue--;
                }

                else if (pic.Location == green0.Location)
                {
                    green0.Location = new Point(pointsGreenHome[0].X + 6, pointsGreenHome[0].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green1.Location)
                {
                    green1.Location = new Point(pointsGreenHome[1].X + 6, pointsGreenHome[1].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green2.Location)
                {
                    green2.Location = new Point(pointsGreenHome[2].X + 6, pointsGreenHome[2].Y + 6);
                    liveGreen--;
                }
                else if (pic.Location == green3.Location)
                {
                    green3.Location = new Point(pointsGreenHome[3].X + 6, pointsGreenHome[3].Y + 6);
                    liveGreen--;
                }
            }
            else if (pic.Name.Substring(0, 3).Equals("gre"))
            {
                if (pic.Location == red0.Location)
                {
                    red0.Location = new Point(pointsRedHome[0].X + 6, pointsRedHome[0].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red1.Location)
                {
                    red1.Location = new Point(pointsRedHome[1].X + 6, pointsRedHome[1].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red2.Location)
                {
                    red2.Location = new Point(pointsRedHome[2].X + 6, pointsRedHome[2].Y + 6);
                    liveRed--;
                }
                else if (pic.Location == red3.Location)
                {
                    red3.Location = new Point(pointsRedHome[3].X + 6, pointsRedHome[3].Y + 6);
                    liveRed--;
                }

                else if (pic.Location == blue0.Location)
                {
                    blue0.Location = new Point(pointsBlueHome[0].X + 6, pointsBlueHome[0].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue1.Location)
                {
                    blue1.Location = new Point(pointsBlueHome[1].X + 6, pointsBlueHome[1].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue2.Location)
                {
                    blue2.Location = new Point(pointsBlueHome[2].X + 6, pointsBlueHome[2].Y + 6);
                    liveBlue--;
                }
                else if (pic.Location == blue3.Location)
                {
                    blue3.Location = new Point(pointsBlueHome[3].X + 6, pointsBlueHome[3].Y + 6);
                    liveBlue--;
                }

                else if (pic.Location == yellow0.Location)
                {
                    yellow0.Location = new Point(pointsYellowHome[0].X + 6, pointsYellowHome[0].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow1.Location)
                {
                    yellow1.Location = new Point(pointsYellowHome[1].X + 6, pointsYellowHome[1].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow2.Location)
                {
                    yellow2.Location = new Point(pointsYellowHome[2].X + 6, pointsYellowHome[2].Y + 6);
                    liveYellow--;
                }
                else if (pic.Location == yellow3.Location)
                {
                    yellow3.Location = new Point(pointsYellowHome[3].X + 6, pointsYellowHome[3].Y + 6);
                    liveYellow--;
                }
            }
        }

        private Boolean waitngToPlaying(PictureBox pic,int index,Boolean hasExecuted)
        {
            //从等待区进入航线
            if (pic.Name.Substring(0, 3).Equals("red"))
            {
                int location = 4 + diceNum;
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (cells[location].CellColor == 1)
                {
                    location += 4;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                }
                hasExecuted = true;
            }
            else if (pic.Name.Substring(0, 3).Equals("blu"))
            {
                int location = 17 + diceNum;
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (cells[location].CellColor == 2)
                {
                    location += 4;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                }
                hasExecuted = true;
            }
            else if (pic.Name.Substring(0, 3).Equals("yel"))
            {
                int location = 30 + diceNum;
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (cells[location].CellColor == 3)
                {
                    location += 4;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                }
                hasExecuted = true;
            }
            else if (pic.Name.Substring(0, 3).Equals("gre"))
            {
                int location = 43 + diceNum;
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (cells[location].CellColor == 4)
                {
                    location += 4;
                    if (location >= 52)
                    {
                        location -= 52;
                    }
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                }
                hasExecuted = true;
            }
            eat(pic);
            return hasExecuted;
        }

        private Boolean playingToFinish(PictureBox pic,int index,Boolean hasExecuted,int PlaneColor)
        {
            //航线，以及航线进入结尾部分
            Boolean isFinish = false;
            Boolean hasFlown = false;
            int location = index + diceNum;
            if (PlaneColor != 1)
            {
                if (location >= 52)
                {
                    location -= 52;
                }
            }
            pic.Location = points[location];
            pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
            eat(pic);
            if (PlaneColor == 1)
            {
                if (location == 50)
                {
                    location = 2;
                    hasFlown = true;
                    isFinish = true;
                }
                if(location >= 52)
                {
                    //这部分有问题
                    if (location >= 54)
                    {
                        location -= 54;
                        hasFlown = true;
                        isFinish = true;
                    }
                    else
                    {
                        location -= 52;
                    }
                }
                // 这部分合并到上边>=54情况下
                //if (location >= 2 && (index < 2 || index >= 48))
                //{
                //    location -= 2;
                //    hasFlown = true;//如果在家门口，则不能飞行，类似与已经飞过了
                //    isFinish = true;
                //}
                if(location == 22)
                {
                    location = 34;
                }
                if(location == 18)
                {
                    location = 22;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                    eat(pic);
                    location = 34;
                    hasFlown = true;
                }
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (hasFlown == false&&(cells[location].CellColor == 1))
                {
                    location += 4;
                    hasFlown = true;
                    if (location >= 52)
                    {
                        location -= 52;
                        isFinish = true;
                    }
                }
                if (isFinish)
                {
                    pic.Location = pointsRedFinish[location];
                }
                else
                {
                    pic.Location = points[location];
                }
            }
            else if(PlaneColor == 2)
            {
                if(location == 11)
                {
                    location = 15;
                    hasFlown = true;
                }
                if (location >= 15 && (index >= 9 && (index < 15)))
                {
                    location -= 15;
                    hasFlown = true;
                    isFinish = true;
                }
                if(location == 35)
                {
                    location = 47;
                }
                if(location == 31)
                {
                    location = 35;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                    eat(pic);
                    location = 47;
                    hasFlown = true;
                }
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (hasFlown == false && (cells[location].CellColor == 2))
                {
                    location += 4;
                    hasFlown = true;
                    if (location >= 52)
                    {
                        location -= 52;
                    }
                }
                if (isFinish)
                {
                    pic.Location = pointsBlueFinish[location];
                }
                else
                {
                    pic.Location = points[location];
                }
            }
            else if (PlaneColor == 3)
            {
                if (location == 24)
                {
                    location = 28;
                    hasFlown = true;
                }
                if (location >= 28 && (index >= 22 && index < 28))
                {
                    location -= 28;
                    hasFlown = true;
                    isFinish = true;
                }
                if (location == 48)
                {
                    location = 8;
                }
                if (location == 44)
                {
                    location = 38;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                    eat(pic);
                    location = 8;
                    hasFlown = true;
                }
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (hasFlown == false && (cells[location].CellColor == 3))
                {
                    location += 4;
                    hasFlown = true;
                    if (location >= 52)
                    {
                        location -= 52;
                    }
                }
                if (isFinish)
                {
                    pic.Location = pointsYellowFinish[location];
                }
                else
                {
                    pic.Location = points[location];
                }
            }
            else if (PlaneColor == 4)
            {
                if (location == 37)
                {
                    location = 41;
                    hasFlown = true;
                }
                if (location >= 41 && index >= 35 && index < 41)
                {
                    location -= 41;
                    hasFlown = true;
                    isFinish = true;
                }
                if (location == 9)
                {
                    location = 21;
                }
                if (location == 5)
                {
                    location = 9;
                    pic.Location = points[location];
                    pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                    eat(pic);
                    location = 21;
                    hasFlown = true;
                }
                pic.Location = points[location];
                pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
                eat(pic);
                if (hasFlown == false && (cells[location].CellColor == 4))
                {
                    location += 4;
                    hasFlown = true;
                    if (location >= 52)
                    {
                        location -= 52;
                    }
                }
                if (isFinish)
                {
                    pic.Location = pointsGreenFinish[location];
                }
                else
                {
                    pic.Location = points[location];
                }
            }
            pic.Location = new Point(pic.Location.X + 6, pic.Location.Y + 6);
            eat(pic);
            return true;
        }

        private void throwDice_Click(object sender, EventArgs e)
        {
            Boolean hasExecuted = false;
            diceNum = random.Next(0, 36) % 6 + 1;
            board.Enabled = true;
            throwDice.Enabled = false;
            if(player == 1)
            {
                gameRecord.Text += "红色";
            }
            else if (player == 2)
            {
                gameRecord.Text += "蓝色";
            }
            else if (player == 3)
            {
                gameRecord.Text += "黄色";
            }
            else if (player == 4)
            {
                gameRecord.Text += "绿色";
            }
            gameRecord.Text += "投骰子，点数" + diceNum + "\n";
            diceShow.Image = Image.FromFile("骰子" + diceNum + ".png");
            if (player == 1 && liveRed == 0 && diceNum != 6)
            {
                gameRecord.Text += "红色无可移动棋子\n";
                board.Enabled = false;
                throwDice.Enabled = true;
                gameRecord.Text += "蓝色玩家环节\n";
                hasExecuted = true;
            }
            if (player == 2 && liveBlue == 0 && diceNum != 6)
            {
                gameRecord.Text += "蓝色无可移动棋子\n";
                board.Enabled = false;
                throwDice.Enabled = true;
                gameRecord.Text += "黄色玩家环节\n";
                hasExecuted = true;
            }
            if (player == 3 && liveYellow == 0 && diceNum != 6)
            {
                gameRecord.Text += "黄色无可移动棋子\n";
                board.Enabled = false;
                throwDice.Enabled = true;
                gameRecord.Text += "绿色玩家环节\n";
                hasExecuted = true;
            }
            if (player == 4 && liveGreen == 0 && diceNum != 6)
            {
                gameRecord.Text += "绿色无可移动棋子\n";
                board.Enabled = false;
                throwDice.Enabled = true;
                gameRecord.Text += "红色玩家环节\n";
                hasExecuted = true;
            }
            //gameRecord.Text += "" + liveRed + liveBlue + liveYellow + liveGreen + finishRed + finishBlue + finishYellow + finishGreen;
            label1.Text = player + "   " + diceNum;
            if (hasExecuted)
            {
                player++;
                if (player == 5)
                {
                    player = 1;
                }
                diceNum = -1;
            }
        }

        private void board_Click(object sender, EventArgs e)
        {
            /* 开始游戏
             * 或者 上一个玩家结束
             * 棋盘设置为不可交互
             * 丢骰子
             * 点击棋盘交互
             * 根据鼠标点击位置获取棋子
             * 然后移动
             * 当到终点了，value++
             * if value == 4
             * Messagebox.show 成功
             * 重开
             * 重新调用
             */
            Point pointClick = this.PointToClient(MousePosition);
            String result = searchLocation(pointClick);
            Boolean hasExecuted = false;
            int isHome = 0;
            int isFinish = 0;
            int isPlaying = 0;
            int isWaiting = 0;
            int whichSelect = -1;
            int index = -2;
            if (result[0] == '1')
            {
                isHome = 1;
            }
            else if (result[1] == '1')
            {
                isPlaying = 1;
            }
            else if (result[2] == '1')
            {
                isFinish = 1;
            }
            else if (result[3] == '1')
            {
                isWaiting = 1;
            }
            if (result[4] != '-')
            {
                whichSelect = result[4] - '0';
                index = int.Parse(result.Substring(5));
            }
            if (player == 1)
            {
                //如果点击的是在家里的棋子
                if (isHome == 1)
                {
                    if (diceNum == 6)
                    {
                        if (whichSelect == 0)
                        {
                            red0.Location = new Point(12 * width, 0 * width);
                            hasExecuted = true;
                            liveRed++;
                        }
                        else if (whichSelect == 1)
                        {
                            red1.Location = new Point(12 * width, 0 * width);
                            hasExecuted = true;
                            liveRed++;
                        }
                        else if (whichSelect == 2)
                        {
                            red2.Location = new Point(12 * width, 0 * width);
                            hasExecuted = true;
                            liveRed++;
                        }
                        else if (whichSelect == 3)
                        {
                            red3.Location = new Point(12 * width, 0 * width);
                            hasExecuted = true;
                            liveRed++;
                        }
                    }
                }
                //如果是在结束地方的棋子
                if (isFinish == 1)
                {
                    if (whichSelect == 0)
                    {
                        //等于6，则完成的++
                        if (index + diceNum == 6)
                        {
                            finishRed++;
                            hasExecuted = true;
                            red0.Visible = false;
                            liveRed--;
                        }
                        //大于6，要返回
                        else if(index+diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            red0.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        //小于6，正常
                        else if(index + diceNum < 6)
                        {
                            index = index + diceNum;
                            red0.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 1)
                    {
                        if (index + diceNum == 6)
                        {
                            finishRed++;
                            hasExecuted = true;
                            red1.Visible = false;
                            liveRed--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            red1.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            red1.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 2)
                    {
                        if (index + diceNum == 6)
                        {
                            finishRed++;
                            hasExecuted = true;
                            red2.Visible = false;
                            liveRed--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            red2.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            red2.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 3)
                    {
                        if (index + diceNum == 6)
                        {
                            finishRed++;
                            hasExecuted = true;
                            red3.Visible = false;
                            liveRed--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            red3.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            red3.Location = new Point(pointsRedFinish[index].X + 6, pointsRedFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                }
                if (isWaiting == 1)
                {
                    if(whichSelect == 0)
                    {
                        hasExecuted = waitngToPlaying(red0, index, hasExecuted);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = waitngToPlaying(red1, index, hasExecuted);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = waitngToPlaying(red2, index, hasExecuted);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = waitngToPlaying(red3, index, hasExecuted);
                    }
                }
                if (isPlaying == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = playingToFinish(red0, index, hasExecuted, 1);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = playingToFinish(red1, index, hasExecuted, 1);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = playingToFinish(red2, index, hasExecuted, 1);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = playingToFinish(red3, index, hasExecuted, 1);
                    }
                }
            }
            if (player == 2)
            {
                //如果点击的是在家里的棋子
                if (isHome == 1)
                {
                    if (diceNum == 6)
                    {
                        if (whichSelect == 0)
                        {
                            blue0.Location = new Point(16 * width, 12 * width);
                            hasExecuted = true;
                            liveBlue++;
                        }
                        else if (whichSelect == 1)
                        {
                            blue1.Location = new Point(16 * width, 12 * width);
                            hasExecuted = true;
                            liveBlue++;
                        }
                        else if (whichSelect == 2)
                        {
                            blue2.Location = new Point(16 * width, 12 * width);
                            hasExecuted = true;
                            liveBlue++;
                        }
                        else if (whichSelect == 3)
                        {
                            blue3.Location = new Point(16 * width, 12 * width);
                            hasExecuted = true;
                            liveBlue++;
                        }
                    }
                }
                //如果是在结束地方的棋子
                if (isFinish == 1)
                {
                    if (whichSelect == 0)
                    {
                        //等于6，则完成的++
                        if (index + diceNum == 6)
                        {
                            finishBlue++;
                            hasExecuted = true;
                            blue0.Visible = false;
                            liveBlue--;
                        }
                        //大于6，要返回
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            blue0.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        //小于6，正常
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            blue0.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 1)
                    {
                        if (index + diceNum == 6)
                        {
                            finishBlue++;
                            hasExecuted = true;
                            blue1.Visible = false;
                            liveBlue--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            blue1.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            blue1.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 2)
                    {
                        if (index + diceNum == 6)
                        {
                            finishBlue++;
                            hasExecuted = true;
                            blue2.Visible = false;
                            liveBlue--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            blue2.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            blue2.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 3)
                    {
                        if (index + diceNum == 6)
                        {
                            finishBlue++;
                            hasExecuted = true;
                            blue3.Visible = false;
                            liveBlue--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            blue3.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            blue3.Location = new Point(pointsBlueFinish[index].X + 6, pointsBlueFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                }
                if (isWaiting == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = waitngToPlaying(blue0, index, hasExecuted);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = waitngToPlaying(blue1, index, hasExecuted);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = waitngToPlaying(blue2, index, hasExecuted);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = waitngToPlaying(blue3, index, hasExecuted);
                    }
                }
                if (isPlaying == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = playingToFinish(blue0, index, hasExecuted, 2);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = playingToFinish(blue1, index, hasExecuted, 2);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = playingToFinish(blue2, index, hasExecuted, 2);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = playingToFinish(blue3, index, hasExecuted, 2);
                    }
                }
            }
            if (player == 3)
            {
                //如果点击的是在家里的棋子
                if (isHome == 1)
                {
                    if (diceNum == 6)
                    {
                        if (whichSelect == 0)
                        {
                            yellow0.Location = new Point(4 * width, 16 * width);
                            hasExecuted = true;
                            liveYellow++;
                        }
                        else if (whichSelect == 1)
                        {
                            yellow1.Location = new Point(4 * width, 16 * width);
                            hasExecuted = true;
                            liveYellow++;
                        }
                        else if (whichSelect == 2)
                        {
                            yellow2.Location = new Point(4 * width, 16 * width);
                            hasExecuted = true;
                            liveYellow++;
                        }
                        else if (whichSelect == 3)
                        {
                            yellow3.Location = new Point(4 * width, 16 * width);
                            hasExecuted = true;
                            liveYellow++;
                        }
                    }
                }
                //如果是在结束地方的棋子
                if (isFinish == 1)
                {
                    if (whichSelect == 0)
                    {
                        //等于6，则完成的++
                        if (index + diceNum == 6)
                        {
                            finishYellow++;
                            hasExecuted = true;
                            yellow0.Visible = false;
                            liveYellow--;
                        }
                        //大于6，要返回
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            yellow0.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        //小于6，正常
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            yellow0.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 1)
                    {
                        if (index + diceNum == 6)
                        {
                            finishYellow++;
                            hasExecuted = true;
                            yellow1.Visible = false;
                            liveYellow--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            yellow1.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            yellow1.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 2)
                    {
                        if (index + diceNum == 6)
                        {
                            finishYellow++;
                            hasExecuted = true;
                            yellow2.Visible = false;
                            liveYellow--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            yellow2.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            yellow2.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 3)
                    {
                        if (index + diceNum == 6)
                        {
                            finishYellow++;
                            hasExecuted = true;
                            yellow3.Visible = false;
                            liveYellow--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            yellow3.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            yellow3.Location = new Point(pointsYellowFinish[index].X + 6, pointsYellowFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                }
                if (isWaiting == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = waitngToPlaying(yellow0, index, hasExecuted);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = waitngToPlaying(yellow1, index, hasExecuted);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = waitngToPlaying(yellow2, index, hasExecuted);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = waitngToPlaying(yellow3, index, hasExecuted);
                    }
                }
                if (isPlaying == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = playingToFinish(yellow0, index, hasExecuted, 3);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = playingToFinish(yellow1, index, hasExecuted, 3);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = playingToFinish(yellow2, index, hasExecuted, 3);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = playingToFinish(yellow3, index, hasExecuted, 3);
                    }
                }
            }
            if (player == 4)
            {
                //如果点击的是在家里的棋子
                if (isHome == 1)
                {
                    if (diceNum == 6)
                    {
                        if (whichSelect == 0)
                        {
                            green0.Location = new Point(0 * width, 4 * width);
                            hasExecuted = true;
                            liveGreen++;
                        }
                        else if (whichSelect == 1)
                        {
                            green1.Location = new Point(0 * width, 4 * width);
                            hasExecuted = true;
                            liveGreen++;
                        }
                        else if (whichSelect == 2)
                        {
                            green2.Location = new Point(0 * width, 4 * width);
                            hasExecuted = true;
                            liveGreen++;
                        }
                        else if (whichSelect == 3)
                        {
                            green3.Location = new Point(0 * width, 4 * width);
                            hasExecuted = true;
                            liveGreen++;
                        }
                    }
                }
                //如果是在结束地方的棋子
                if (isFinish == 1)
                {
                    if (whichSelect == 0)
                    {
                        //等于6，则完成的++
                        if (index + diceNum == 6)
                        {
                            finishGreen++;
                            hasExecuted = true;
                            green0.Visible = false;
                            liveGreen--;
                        }
                        //大于6，要返回
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            green0.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        //小于6，正常
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            green0.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 1)
                    {
                        if (index + diceNum == 6)
                        {
                            finishGreen++;
                            hasExecuted = true;
                            green1.Visible = false;
                            liveGreen--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            green1.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            green1.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 2)
                    {
                        if (index + diceNum == 6)
                        {
                            finishGreen++;
                            hasExecuted = true;
                            green2.Visible = false;
                            liveGreen--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            green2.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            green2.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                    else if (whichSelect == 3)
                    {
                        if (index + diceNum == 6)
                        {
                            finishGreen++;
                            hasExecuted = true;
                            green3.Visible = false;
                            liveGreen--;
                        }
                        else if (index + diceNum > 6)
                        {
                            index = 12 - index - diceNum;
                            green3.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                        else if (index + diceNum < 6)
                        {
                            index = index + diceNum;
                            green3.Location = new Point(pointsGreenFinish[index].X + 6, pointsGreenFinish[index].Y + 6);
                            hasExecuted = true;
                        }
                    }
                }
                if (isWaiting == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = waitngToPlaying(green0, index, hasExecuted);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = waitngToPlaying(green1, index, hasExecuted);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = waitngToPlaying(green2, index, hasExecuted);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = waitngToPlaying(green3, index, hasExecuted);
                    }
                }
                if (isPlaying == 1)
                {
                    if (whichSelect == 0)
                    {
                        hasExecuted = playingToFinish(green0, index, hasExecuted, 4);
                    }
                    else if (whichSelect == 1)
                    {
                        hasExecuted = playingToFinish(green1, index, hasExecuted, 4);
                    }
                    else if (whichSelect == 2)
                    {
                        hasExecuted = playingToFinish(green2, index, hasExecuted, 4);
                    }
                    else if (whichSelect == 3)
                    {
                        hasExecuted = playingToFinish(green3, index, hasExecuted, 4);
                    }
                }
            }
            if (hasExecuted)
            {
                board.Enabled = false;
                throwDice.Enabled = true;
                if (diceNum != 6)
                {
                    player++;
                    if (player == 5)
                    {
                        player = 1;
                    }
                }
            }
            if (finishRed == 4 || finishBlue == 4 || finishYellow == 4 || finishGreen == 4)
            {
                throwDice.Enabled = false;
                MessageBox.Show("游戏结束");
                gameRecord.Text += "游戏结束\n";
                //判断谁获胜
                if(finishRed == 4)
                {
                    gameRecord.Text += "红色方获胜";
                }
                else if (finishBlue == 4)
                {
                    gameRecord.Text += "蓝色方获胜";
                }
                else if (finishYellow == 4)
                {
                    gameRecord.Text += "黄色方获胜";
                }
                else if (finishGreen == 4)
                {
                    gameRecord.Text += "绿色方获胜";
                }
            }
            diceNum = -1;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text.Equals("开始游戏"))
            {
                gameRecord.Text += "游戏开始\n红色玩家环节\n";
                throwDice.Enabled = true;
                startButton.Text = "重新开始";
                openAndSave.Text = "保存";
            }
            else
            {
                startButton.Text = "开始游戏";
                openAndSave.Text = "导入";
                //重置
                gameRecord.Clear();
                player = 1;
                liveRed = 0;
                liveBlue = 0;
                liveYellow = 0;
                liveGreen = 0;
                finishRed = 0;
                finishBlue = 0;
                finishYellow = 0;
                finishGreen = 0;
                red0.Image = Image.FromFile("red.png");
                red0.Location = new Point((int)(pointsRedHome[0].X + width / 2 - 12), (int)(pointsRedHome[0].Y + width / 2) - 12);
                red1.Image = Image.FromFile("red.png");
                red1.Location = new Point((int)(pointsRedHome[1].X + width / 2 - 12), (int)(pointsRedHome[1].Y + width / 2) - 12);
                red2.Image = Image.FromFile("red.png");
                red2.Location = new Point((int)(pointsRedHome[2].X + width / 2 - 12), (int)(pointsRedHome[2].Y + width / 2) - 12);
                red3.Image = Image.FromFile("red.png");
                red3.Location = new Point((int)(pointsRedHome[3].X + width / 2 - 12), (int)(pointsRedHome[3].Y + width / 2) - 12);
                blue0.Image = Image.FromFile("blue.png");
                blue0.Location = new Point((int)(pointsBlueHome[0].X + width / 2 - 12), (int)(pointsBlueHome[0].Y + width / 2) - 12);
                blue1.Image = Image.FromFile("blue.png");
                blue1.Location = new Point((int)(pointsBlueHome[1].X + width / 2 - 12), (int)(pointsBlueHome[1].Y + width / 2) - 12);
                blue2.Image = Image.FromFile("blue.png");
                blue2.Location = new Point((int)(pointsBlueHome[2].X + width / 2 - 12), (int)(pointsBlueHome[2].Y + width / 2) - 12);
                blue3.Image = Image.FromFile("blue.png");
                blue3.Location = new Point((int)(pointsBlueHome[3].X + width / 2 - 12), (int)(pointsBlueHome[3].Y + width / 2) - 12);
                yellow0.Image = Image.FromFile("orange.png");
                yellow0.Location = new Point((int)(pointsYellowHome[0].X + width / 2 - 12), (int)(pointsYellowHome[0].Y + width / 2) - 12);
                yellow1.Image = Image.FromFile("orange.png");
                yellow1.Location = new Point((int)(pointsYellowHome[1].X + width / 2 - 12), (int)(pointsYellowHome[1].Y + width / 2) - 12);
                yellow2.Image = Image.FromFile("orange.png");
                yellow2.Location = new Point((int)(pointsYellowHome[2].X + width / 2 - 12), (int)(pointsYellowHome[2].Y + width / 2) - 12);
                yellow3.Image = Image.FromFile("orange.png");
                yellow3.Location = new Point((int)(pointsYellowHome[3].X + width / 2 - 12), (int)(pointsYellowHome[3].Y + width / 2) - 12);
                green0.Image = Image.FromFile("green.png");
                green0.Location = new Point((int)(pointsGreenHome[0].X + width / 2 - 12), (int)(pointsGreenHome[0].Y + width / 2) - 12);
                green1.Image = Image.FromFile("green.png");
                green1.Location = new Point((int)(pointsGreenHome[1].X + width / 2 - 12), (int)(pointsGreenHome[1].Y + width / 2) - 12);
                green2.Image = Image.FromFile("green.png");
                green2.Location = new Point((int)(pointsGreenHome[2].X + width / 2 - 12), (int)(pointsGreenHome[2].Y + width / 2) - 12);
                green3.Image = Image.FromFile("green.png");
                green3.Location = new Point((int)(pointsGreenHome[3].X + width / 2 - 12), (int)(pointsGreenHome[3].Y + width / 2) - 12);
            }
        }

        public void CreateNode(XmlDocument xmlDocument, XmlNode parentNode, String name, String value)
        {
            XmlElement element = xmlDocument.CreateElement(name);
            element.InnerText = value;
            parentNode.AppendChild(element);
        }

        private void openAndSave_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            String path = "Aeroplane.xml";
            if (openAndSave.Text.Equals("保存"))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "所有文件|*.xml";
                saveFile.Title = "保存文件";
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    path = saveFile.FileName;
                }
                if (!File.Exists(path))
                {
                    XmlNode node = xmlDocument.CreateXmlDeclaration("1.0", "GB2312", null);
                    xmlDocument.AppendChild(node);
                    XmlElement root = xmlDocument.CreateElement("棋子");
                    xmlDocument.AppendChild(root);
                    XmlElement rootred0 = xmlDocument.CreateElement("red0");
                    root.AppendChild(rootred0);
                    CreateNode(xmlDocument, rootred0, "X", red0.Location.X.ToString());
                    CreateNode(xmlDocument, rootred0, "Y", red0.Location.Y.ToString());
                    rootred0.SetAttribute("player", player + "");
                    rootred0.SetAttribute("diceNum", diceNum + "");
                    XmlElement rootred1 = xmlDocument.CreateElement("red1");
                    root.AppendChild(rootred1);
                    CreateNode(xmlDocument, rootred1, "X", red1.Location.X.ToString());
                    CreateNode(xmlDocument, rootred1, "Y", red1.Location.Y.ToString());
                    XmlElement rootred2 = xmlDocument.CreateElement("red2");
                    root.AppendChild(rootred2);
                    CreateNode(xmlDocument, rootred2, "X", red2.Location.X.ToString());
                    CreateNode(xmlDocument, rootred2, "Y", red2.Location.Y.ToString());
                    XmlElement rootred3 = xmlDocument.CreateElement("red3");
                    root.AppendChild(rootred3);
                    CreateNode(xmlDocument, rootred3, "X", red3.Location.X.ToString());
                    CreateNode(xmlDocument, rootred3, "Y", red3.Location.Y.ToString());
                    XmlElement rootblue0 = xmlDocument.CreateElement("blue0");
                    root.AppendChild(rootblue0);
                    CreateNode(xmlDocument, rootblue0, "X", blue0.Location.X.ToString());
                    CreateNode(xmlDocument, rootblue0, "Y", blue0.Location.Y.ToString());
                    XmlElement rootblue1 = xmlDocument.CreateElement("blue1");
                    root.AppendChild(rootblue1);
                    CreateNode(xmlDocument, rootblue1, "X", blue1.Location.X.ToString());
                    CreateNode(xmlDocument, rootblue1, "Y", blue1.Location.Y.ToString());
                    XmlElement rootblue2 = xmlDocument.CreateElement("blue2");
                    root.AppendChild(rootblue2);
                    CreateNode(xmlDocument, rootblue2, "X", blue2.Location.X.ToString());
                    CreateNode(xmlDocument, rootblue2, "Y", blue2.Location.Y.ToString());
                    XmlElement rootblue3 = xmlDocument.CreateElement("blue3");
                    root.AppendChild(rootblue3);
                    CreateNode(xmlDocument, rootblue3, "X", blue3.Location.X.ToString());
                    CreateNode(xmlDocument, rootblue3, "Y", blue3.Location.Y.ToString());
                    XmlElement rootyellow0 = xmlDocument.CreateElement("yellow0");
                    root.AppendChild(rootyellow0);
                    CreateNode(xmlDocument, rootyellow0, "X", yellow0.Location.X.ToString());
                    CreateNode(xmlDocument, rootyellow0, "Y", yellow0.Location.Y.ToString());
                    XmlElement rootyellow1 = xmlDocument.CreateElement("yellow1");
                    root.AppendChild(rootyellow1);
                    CreateNode(xmlDocument, rootyellow1, "X", yellow1.Location.X.ToString());
                    CreateNode(xmlDocument, rootyellow1, "Y", yellow1.Location.Y.ToString());
                    XmlElement rootyellow2 = xmlDocument.CreateElement("yellow2");
                    root.AppendChild(rootyellow2);
                    CreateNode(xmlDocument, rootyellow2, "X", yellow2.Location.X.ToString());
                    CreateNode(xmlDocument, rootyellow2, "Y", yellow2.Location.Y.ToString());
                    XmlElement rootyellow3 = xmlDocument.CreateElement("yellow3");
                    root.AppendChild(rootyellow3);
                    CreateNode(xmlDocument, rootyellow3, "X", yellow3.Location.X.ToString());
                    CreateNode(xmlDocument, rootyellow3, "Y", yellow3.Location.Y.ToString());
                    XmlElement rootgreen0 = xmlDocument.CreateElement("green0");
                    root.AppendChild(rootgreen0);
                    CreateNode(xmlDocument, rootgreen0, "X", green0.Location.X.ToString());
                    CreateNode(xmlDocument, rootgreen0, "Y", green0.Location.Y.ToString());
                    XmlElement rootgreen1 = xmlDocument.CreateElement("green1");
                    root.AppendChild(rootgreen1);
                    CreateNode(xmlDocument, rootgreen1, "X", green1.Location.X.ToString());
                    CreateNode(xmlDocument, rootgreen1, "Y", green1.Location.Y.ToString());
                    XmlElement rootgreen2 = xmlDocument.CreateElement("green2");
                    root.AppendChild(rootgreen2);
                    CreateNode(xmlDocument, rootgreen2, "X", green2.Location.X.ToString());
                    CreateNode(xmlDocument, rootgreen2, "Y", green2.Location.Y.ToString());
                    XmlElement rootgreen3 = xmlDocument.CreateElement("green3");
                    root.AppendChild(rootgreen3);
                    CreateNode(xmlDocument, rootgreen3, "X", green3.Location.X.ToString());
                    CreateNode(xmlDocument, rootgreen3, "Y", green3.Location.Y.ToString());
                    try
                    {
                        xmlDocument.Save(path);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            else if (openAndSave.Text.Equals("导入"))
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "所有文件|*.xml";
                openFile.Title = "打开文件";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    path = openFile.FileName;
                }
                try
                {
                    gameRecord.Text += "游戏开始\n红色玩家环节\n";
                    throwDice.Enabled = true;
                    startButton.Text = "重新开始";
                    openAndSave.Text = "保存";
                    xmlDocument.Load(path);
                    XmlNode xn = xmlDocument.SelectSingleNode("棋子");
                    XmlNodeList xnl = xn.ChildNodes;
                    foreach (XmlNode xn1 in xnl)
                    {
                        if (xn1.Name.Equals("red0"))
                        {
                            red0.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (red0.Location != new Point(492, 24))
                            {
                                liveRed++;
                            }
                            if (red0.Location == new Point(8 * width + 6, 7 * width + 6))
                            {
                                liveRed--;
                                finishRed++;
                                red0.Visible = false;
                            }
                            player = int.Parse(((XmlElement)xn1).GetAttribute("player").ToString());
                            diceNum = int.Parse(((XmlElement)xn1).GetAttribute("diceNum").ToString());
                            if (diceNum == -1)
                            {
                                throwDice.Enabled = true;
                            }
                            else
                            {
                                throwDice.Enabled = false;
                                board.Enabled = true;
                                diceShow.Image = Image.FromFile("骰子" + diceNum + ".png");
                            }
                        }
                        else if (xn1.Name.Equals("red1"))
                        {
                            red1.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (red1.Location != new Point(564, 24))
                            {
                                liveRed++;
                            }
                            if (red1.Location == new Point(8 * width + 6, 7 * width + 6))
                            {
                                liveRed--;
                                finishRed++;
                                red1.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("red2"))
                        {
                            red2.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (red2.Location != new Point(492, 96))
                            {
                                liveRed++;
                            }
                            if (red2.Location == new Point(8 * width + 6, 7 * width + 6))
                            {
                                liveRed--;
                                finishRed++;
                                red2.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("red3"))
                        {
                            red3.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (red3.Location != new Point(564, 96))
                            {
                                liveRed++;
                            }
                            if (red3.Location == new Point(8 * width + 6, 7 * width + 6))
                            {
                                liveRed--;
                                finishRed++;
                                red3.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("blue0"))
                        {
                            blue0.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (blue0.Location != new Point(492, 492))
                            {
                                liveBlue++;
                            }
                            if (blue0.Location == new Point(9 * width + 6, 8 * width + 6))
                            {
                                liveBlue--;
                                finishBlue++;
                                blue0.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("blue1"))
                        {
                            blue1.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (blue1.Location != new Point(564, 492))
                            {
                                liveBlue++;
                            }
                            if (blue1.Location == new Point(9 * width + 6, 8 * width + 6))
                            {
                                liveBlue--;
                                finishBlue++;
                                blue1.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("blue2"))
                        {
                            blue2.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (blue2.Location != new Point(492, 564))
                            {
                                liveBlue++;
                            }
                            if (blue2.Location == new Point(9 * width + 6, 8 * width + 6))
                            {
                                liveBlue--;
                                finishBlue++;
                                blue2.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("blue3"))
                        {
                            blue3.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (blue3.Location != new Point(564, 564))
                            {
                                liveBlue++;
                            }
                            if (blue3.Location == new Point(9 * width + 6, 8 * width + 6))
                            {
                                liveBlue--;
                                finishBlue++;
                                blue3.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("yellow0"))
                        {
                            yellow0.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (yellow0.Location != new Point(24, 492))
                            {
                                liveYellow++;
                            }
                            if (yellow0.Location == new Point(8 * width + 6, 9 * width + 6))
                            {
                                liveYellow--;
                                finishYellow++;
                                yellow0.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("yellow1"))
                        {
                            yellow1.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (yellow1.Location != new Point(96, 492))
                            {
                                liveYellow++;
                            }
                            if (yellow1.Location == new Point(8 * width + 6, 9 * width + 6))
                            {
                                liveYellow--;
                                finishYellow++;
                                yellow1.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("yellow2"))
                        {
                            yellow2.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (yellow2.Location != new Point(24, 564))
                            {
                                liveYellow++;
                            }
                            if (yellow2.Location == new Point(8 * width + 6, 9 * width + 6))
                            {
                                liveYellow--;
                                finishYellow++;
                                yellow2.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("yellow3"))
                        {
                            yellow3.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (yellow3.Location != new Point(96, 564))
                            {
                                liveYellow++;
                            }
                            if (yellow3.Location == new Point(8 * width + 6, 9 * width + 6))
                            {
                                liveYellow--;
                                finishYellow++;
                                yellow3.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("green0"))
                        {
                            green0.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (green0.Location != new Point(24, 24))
                            {
                                liveGreen++;
                            }
                            if (green0.Location == new Point(7 * width + 6, 8 * width + 6))
                            {
                                liveGreen--;
                                finishGreen++;
                                green0.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("green1"))
                        {
                            green1.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (green1.Location != new Point(96, 24))
                            {
                                liveGreen++;
                            }
                            if (green1.Location == new Point(7 * width + 6, 8 * width + 6))
                            {
                                liveGreen--;
                                finishGreen++;
                                green1.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("green2"))
                        {
                            green2.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (green2.Location != new Point(24, 96))
                            {
                                liveGreen++;
                            }
                            if (green2.Location == new Point(7 * width + 6, 8 * width + 6))
                            {
                                liveGreen--;
                                finishGreen++;
                                green2.Visible = false;
                            }
                        }
                        else if (xn1.Name.Equals("green3"))
                        {
                            green3.Location = new Point(int.Parse(((XmlElement)xn1).ChildNodes.Item(0).InnerText), int.Parse(((XmlElement)xn1).ChildNodes.Item(1).InnerText));
                            if (green3.Location != new Point(96, 96))
                            {
                                liveGreen++;
                            }
                            if (green3.Location == new Point(7 * width + 6, 8 * width + 6))
                            {
                                liveGreen--;
                                finishGreen++;
                                green3.Visible = false;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
