using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class Button : GuiObject
    {
        private Frame activeFrame;
        private Frame nonActiveFrame;
        private TextLine textLine;

        public bool IsActive { get; set; } = false;

        public Button(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            textLine = new TextLine(x+Math.Max(1,(width-text.Length)/2),y+height/2,width,text);
            activeFrame = new Frame(x, y, width, height, '#');
            nonActiveFrame = new Frame(x, y, width, height, '+');
            IsActive = false;
        }

        public void SetActive()
        {
            IsActive = true;
        }

        public override void Render()
        {
            if (IsActive)
            {
                activeFrame.Render();
            }
            else
            {
                nonActiveFrame.Render();
            }
            textLine.Render();
        }
    }
}
