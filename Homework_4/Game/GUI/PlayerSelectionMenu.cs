using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class PlayerSelectionMenu: Window
    {
        private TextBlock playersTextBlock;
        private List<string> strings = new List<string> { "Select number of players", "Use Arrows and Enter"};
        private List<Button> playerButtons = new List<Button>();
        public int NumPlayers { get; set; } = 2;

        public PlayerSelectionMenu(int x = 25, int y = 5, int width = 50, int height = 20, char renderChar = '+') : base(x, y, width, height, renderChar)
        {
            playersTextBlock = new TextBlock(x+10, y+2, 30, strings);
            playerButtons.Add(new Button(42, 15, 5, 4, "P2"));
            playerButtons[0].IsActive = true;
            playerButtons.Add(new Button(47, 15, 5, 4, "P3"));
            playerButtons.Add(new Button(52, 15, 5, 4, "P4"));
            playerButtons.Add(new Button(42, 19, 5, 4, "P5"));
            playerButtons.Add(new Button(47, 19, 5, 4, "P6"));
            playerButtons.Add(new Button(52, 19, 5, 4, "P7"));
        }

        public override void Render()
        {
            ClearScreen();
            base.Render();
            playersTextBlock.Render();
            foreach (Button i in playerButtons)
            {   
                if (!i.IsActive) i.Render();
            }
            foreach (Button i in playerButtons)
            {
                if (i.IsActive) i.Render();
            }
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

        public void SetActiveButton(int i)
        {
            playerButtons[NumPlayers - 2].IsActive = false;
            playerButtons[i].IsActive = true;
            NumPlayers = i + 2;
        }

        public void ChangeActiveButton(string direction)
        {
            int i = NumPlayers - 2;
            switch (direction)
            {
                case "right":
                    if (i == 2 || i == 5)
                    {
                        i-=2;
                    }
                    else
                    {
                        i++;
                    }
                    break;
                case "left":
                    if (i == 0 || i==3)
                    {
                        i+=2;
                    }
                    else
                    {
                        i--;
                    }
                    break;
                case "up":
                case "down":
                    if (i < 3)
                    {
                        i += 3;
                    }
                    else
                    {
                        i -= 3;
                    }
                    break;
            }
            SetActiveButton(i);
        }
    }
}
