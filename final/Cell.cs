using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class Cell
    {
        Point point;
        int extend;
        /*    1
         *    ***
         *    ***
         *    ***
         *    ***
         *    2
         *    ****
         *    ****
         *    ****
         *    3
         *    *
         *    **
         *    ***
         *    4
         *      *
         *     **
         *    ***
         *    5
         *    ***
         *    **
         *    *
         *    6
         *    ***
         *     **
         *      *
         */
        int cellColor;
        /*    1 Red
         *    2 Blue
         *    3 Yellow
         *    4 Green
         */

        public Cell(Point point, int extend, int cellColor)
        {
            this.point = point;
            this.extend = extend;
            this.cellColor = cellColor;
        }

        public Point Point { get => point; set => point = value; }
        public int Extend { get => extend; set => extend = value; }
        public int CellColor { get => cellColor; set => cellColor = value; }
    }
}
