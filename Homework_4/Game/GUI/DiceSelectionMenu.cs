using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class DiceSelectionMenu : Window
    {
        private TextBlock diceMenuTextBlockTitle;
        private List<string> strings = new List<string> { "Select number of dices", "Use +/- and Enter", "Selected number of dices: "};


        public int NumDices { get; set; } = 3;

        public DiceSelectionMenu(int x = 25, int y = 5, int width = 50, int height = 7, char renderChar = '+') : base(x, y, width, height, renderChar)
        {
            diceMenuTextBlockTitle = new TextBlock(x + 10, y + 2, 30, strings.GetRange(0,2));
        }

        public override void Render()
        {
            Console.Clear();
            base.Render();
            diceMenuTextBlockTitle.Render();
            Console.SetCursorPosition(25 + 10, 5 + 5);
            Console.WriteLine($"{strings[2]}{NumDices}");
        }


        public void FinalSelectionRender()
        {
            Console.Clear();
            base.Render();
            Console.SetCursorPosition(25 + 11, 5 + 4);
            Console.WriteLine($"Players will have {NumDices} dices!");
        }

        private void ClearScreen()
        {
            for (int i = X; i <= X + Width; i++)
            {
                for (int j = Y; j <= Y + Height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                }
            }
        }

        public void ChangeNumDices(string direction)
        {
            switch (direction)
            {
                case "-":
                    if (NumDices > 1)
                    {
                        NumDices--;

                    }
                    break;
                case "+":
                    if (NumDices < 5)
                    {
                        NumDices++;
                    }
                    break;
            }
        }
    }
}
