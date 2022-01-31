using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class MenuWindow: Window
    {

        private TextBlock titleTextBlock;
        private List<string> strings = new List<string> {"Super Game", "Made by Aleksej", "Made in Vilnius Coding School"};
        private List<Button> menuButtons = new List<Button>(3);

        public MenuWindow(int x = 1, int y = 1, int width = 100, int height = 25, char renderChar = '%') :base(x, y, width, height, renderChar)
        {
            menuButtons.Add(new Button(15, 15, 11, 4, "START"));
            menuButtons[0].SetActive();
            menuButtons.Add(new Button(45, 15, 11, 4, "CREDITS"));
            menuButtons.Add(new Button(75, 15, 11, 4, "QUIT"));
            titleTextBlock = new TextBlock(35, 5, 30, strings);
        }

        public int GetActiveButton()
        {
            for(int i = 0; i<3; i++)
            {
                if (menuButtons[i].IsActive)
                {
                    return i;
                }
            }
            menuButtons[0].SetActive();
            return 0;
        }

        public void SetActiveButton(int i)
        {
            menuButtons[GetActiveButton()].IsActive = false;
            menuButtons[i].SetActive();
        }

        public void ChangeActiveButton(string direction)
        {
            int i = GetActiveButton();
            switch (direction)
            {
                case "right":
                    if(i < 2)
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
