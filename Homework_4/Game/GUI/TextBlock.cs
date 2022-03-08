using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.GUI
{
    class TextBlock:GuiObject
    {
        public List<TextLine> textLines = new List<TextLine>();
        public TextBlock(int x, int y, int width, List<string> strings): base(x,y,width,strings.Count)
        {
            foreach(string i in strings)
            {
                textLines.Add(new TextLine(x + (width-i.Length)/2,y + strings.IndexOf(i), i.Length,i));
            }
        }

        public override void Render()
        {
            foreach(TextLine textLine in textLines)
            {
                textLine.Render();
            }
        }
    }
}
