using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class Frame : GuiObject
    {
        public char RenderChar { set; get; }

        public Frame(int x, int y, int width, int height, char renderChar) : base(x, y, width, height)
        {
            this.RenderChar = renderChar;
        }

        public override void Render()
        {
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(X + i, Y);
                Console.WriteLine(RenderChar);
                Console.SetCursorPosition(X + i, Y + Height);
                Console.WriteLine(RenderChar);
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(X, Y+i);
                Console.WriteLine(RenderChar);
                Console.SetCursorPosition(X + Width, Y + i);
                Console.WriteLine(RenderChar);
            }
        }
    }
}
