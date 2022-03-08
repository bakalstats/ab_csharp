using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    abstract class GuiObject
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public GuiObject(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }

        public abstract void Render();
    }
}
