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
        Boolean isHome;
        Boolean isPlaying;
        Boolean isFinish;
        int location;//数组下标

        public Plane(bool isHome, bool isPlaying, bool isFinish, int location)
        {
            this.isHome = isHome;
            this.isPlaying = isPlaying;
            this.isFinish = isFinish;
            this.location = location;
        }

        public bool IsHome { get => isHome; set => isHome = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public bool IsFinish { get => isFinish; set => isFinish = value; }
        public int Location { get => location; set => location = value; }
    }
}
