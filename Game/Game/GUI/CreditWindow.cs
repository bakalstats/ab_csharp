using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class CreditWindow: Window
    {
        private Button backButton;
        private TextBlock creditTextBlock;
        private List<string> strings = new List<string> { "Designed and produced by:", "Aleksej"};

        public CreditWindow(int x = 25, int y = 5, int width = 50, int height = 20, char renderChar = '@') : base(x, y, width, height, renderChar)
        {
            creditTextBlock = new TextBlock(x+10, y+2, 30, strings);
            backButton = new Button(x+20, y+12, 10, 4, "BACK");
        }

        public override void Render()
        {
            ClearScreen();
            base.Render();
            creditTextBlock.Render();
            backButton.SetActive();
            backButton.Render();
        }

        private void ClearScreen()
        {
            for (int i = X; i <= X + Width; i++)
            {
                for(int j = Y; j <= Y + Height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
