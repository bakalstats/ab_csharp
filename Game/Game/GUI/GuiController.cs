using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class GuiController
    {
        private MenuWindow menuWindow;
        private CreditWindow creditWindow;
        private GameController gameController;

        public GuiController()
        {
            menuWindow = new MenuWindow();
            creditWindow = new CreditWindow();
            gameController = new GameController();
        }

        public void ShowMenu()
        {
            menuWindow.Render();
        }

        public void MakeSelection()
        {
            bool needtoRender = true;
            do
            {
                ShowMenu();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needtoRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            menuWindow.ChangeActiveButton("right");
                            break;
                        case ConsoleKey.LeftArrow:
                            menuWindow.ChangeActiveButton("left");
                            break;
                        case ConsoleKey.Enter:
                            needtoRender = RunSelectedOption();
                            break;
                    }
            } while (needtoRender);
        }

        public bool RunSelectedOption()
        {
            int i = menuWindow.GetActiveButton();
            if (i == 0)
            {
                gameController.StartGame();
                Console.Clear();
                return true;
            }
            else if (i == 1)
            {
                Console.Clear();
                creditWindow.Render();
                bool needtoRender = true;
                do
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    if(pressedChar.Key.Equals(ConsoleKey.Enter) | pressedChar.Key.Equals(ConsoleKey.Escape)) 
                    {
                        Console.Clear();
                        needtoRender = false;
                    }
                } while (needtoRender);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
