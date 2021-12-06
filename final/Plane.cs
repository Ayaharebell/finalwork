using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class Plane
    {
        Point point;
        String path;
        Boolean isFinish;

        public Plane(Point point, string path, bool isFinish)
        {
            this.point = point;
            this.path = path;
            this.isFinish = isFinish;
        }

        public Point Point { get => point; set => point = value; }
        public string Path { get => path; set => path = value; }
        public bool IsFinish { get => isFinish; set => isFinish = value; }
    }
}
