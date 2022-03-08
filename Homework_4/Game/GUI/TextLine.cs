using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class TextLine: GuiObject
    {

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                Render();
            }
        }

        public TextLine(int x, int y, int width, string data) : base(x, y, data.Length, 1)
        {
            this.Data = data;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Data);
        }
    }
}
