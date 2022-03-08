using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class MainMenu: Window
    {

        private TextBlock titleTextBlock;
        private List<string> strings = new List<string> {"Dice Game", "Made by Aleksej", "Made in Vilnius Coding School"};
        private List<Button> menuButtons = new List<Button>(2);
        const string playButton = "P - Play";
        const string quitButton = "Q - Quit";

        public MainMenu(int x = 1, int y = 1, int width = 100, int height = 25, char renderChar = '%') :base(x, y, width, height, renderChar)
        {
            menuButtons.Add(new Button(30, 15, 11, 4, playButton));
            menuButtons[0].IsActive = true;
            menuButtons.Add(new Button(55, 15, 11, 4, quitButton));
            titleTextBlock = new TextBlock(35, 5, 30, strings);
        }

        public int GetActiveButton()
        {
            for(int i = 0; i< menuButtons.Count; i++)
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

        public void ChangeActiveButton()
        {
            int i = GetActiveButton();
            if (i == 0)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            SetActiveButton(i);
        }


        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            menuButtons[0].Render();
            menuButtons[1].Render();
        }
    }
}
