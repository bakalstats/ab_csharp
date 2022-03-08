using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class GameOverMenu : Window
    {


        private TextBlock titleTextBlock;
        private List<string> strings = new List<string> { "The winner is Player: "};
        private List<Button> menuButtons = new List<Button>(3);
        const string replayButton = "R - Replay game";
        const string goToMenuButton = "M - Go to menu";
        const string quitButton = "Q - Quit";

        public GameOverMenu(int winner, int x = 1, int y = 1, int width = 100, int height = 25, char renderChar = '%') : base(x, y, width, height, renderChar)
        {
            menuButtons.Add(new Button(15, 15, 18, 4, replayButton));
            menuButtons[0].IsActive = true;
            menuButtons.Add(new Button(45, 15, 18, 4, goToMenuButton));
            menuButtons.Add(new Button(75, 15, 18, 4, quitButton));
            strings[0] += $"{winner}";
            titleTextBlock = new TextBlock(35, 5, 30, strings);
        }

        public int GetActiveButton()
        {
            for (int i = 0; i < menuButtons.Count; i++)
            {
                if (menuButtons[i].IsActive)
                {
                    return i;
                }
            }
            menuButtons[0].IsActive = true;
            return 0;
        }

        public void SetActiveButton(int i)
        {
            menuButtons[GetActiveButton()].IsActive = false;
            menuButtons[i].IsActive = true;
        }

        public void ChangeActiveButton(string direction)
        {
            int i = GetActiveButton();
            switch (direction)
            {
                case "right":
                    if (i < 2)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                    break;
                case "left":
                    if (i > 0)
                    {
                        i--;
                    }
                    else
                    {
                        i = 2;
                    }
                    break;
            }
            SetActiveButton(i);
        }


        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            menuButtons[0].Render();
            menuButtons[1].Render();
            menuButtons[2].Render();
        }
    }
}
