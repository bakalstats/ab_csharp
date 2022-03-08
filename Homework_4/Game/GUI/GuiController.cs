using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.GUI
{
    class GuiController
    {
        private MainMenu mainMenuWindow;
        private PlayerSelectionMenu playersMenuWindow;
        private DiceSelectionMenu dicesMenuWindow;
        private GameOverMenu gameOverWindow;
        private GameController gameController;
        private int winner;
        private enum direction {right, left, up, down};

        public GuiController()
        {
            mainMenuWindow = new MainMenu();
            playersMenuWindow = new PlayerSelectionMenu();
            dicesMenuWindow = new DiceSelectionMenu();
            gameController = new GameController();
        }

        public void ShowMenu()
        {
            Console.Clear();
            mainMenuWindow.Render();
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
                        case ConsoleKey.Q:
                            needtoRender = false;
                            break;
                        case ConsoleKey.RightArrow: 
                        case ConsoleKey.LeftArrow:
                            mainMenuWindow.ChangeActiveButton();
                            break;
                        case ConsoleKey.Enter:
                            if (mainMenuWindow.GetActiveButton() == 0)
                            {
                                Console.Clear();
                                SelectNumPlayers();
                            }
                            needtoRender = false;
                            break;
                        case ConsoleKey.P:
                            Console.Clear();
                            SelectNumPlayers();
                            needtoRender = false;
                            break;
                    }
            } while (needtoRender);
        }


        public void SelectNumPlayers()
        {
            bool needtoRender = true;
            do
            {
                playersMenuWindow.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        needtoRender = false;
                        break;
                    case ConsoleKey.RightArrow:
                        playersMenuWindow.ChangeActiveButton("right");
                        break;
                    case ConsoleKey.UpArrow:
                        playersMenuWindow.ChangeActiveButton("up");
                        break;
                    case ConsoleKey.DownArrow:
                        playersMenuWindow.ChangeActiveButton("down");
                        break;
                    case ConsoleKey.LeftArrow:
                        playersMenuWindow.ChangeActiveButton("left");
                        break;
                    case ConsoleKey.Enter:
                        SelectNumDices();
                        needtoRender = false;
                        break;
                }
            } while (needtoRender);
        }


        public void SelectNumDices()
        {
            bool needtoRender = true;
            do
            {
                dicesMenuWindow.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        needtoRender = false;
                        break;
                    case ConsoleKey.OemPlus:
                        dicesMenuWindow.ChangeNumDices("+");
                        break;
                    case ConsoleKey.OemMinus:
                        dicesMenuWindow.ChangeNumDices("-");
                        break;
                    case ConsoleKey.Enter:
                        dicesMenuWindow.FinalSelectionRender();
                        Thread.Sleep(3000);
                        needtoRender = RunGame();
                        break;
                }
            } while (needtoRender);
        }

        public bool RunGame()
        {
            int numPlayers = playersMenuWindow.NumPlayers;
            int numDices = dicesMenuWindow.NumDices;
            gameController.StartGame(numPlayers, numDices);
            winner = gameController.Winner;
            Console.Clear();
            gameOverWindow = new GameOverMenu(winner);
            ShowResults();
            return false;
        }


        public void ShowResults()
        {
            bool needtoRender = true;
            do
            {
                gameOverWindow.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                if(pressedChar.Key == ConsoleKey.Escape || pressedChar.Key == ConsoleKey.Q || (gameOverWindow.GetActiveButton() == 2 && pressedChar.Key == ConsoleKey.Enter))
                {
                    needtoRender = false;
                }
                else if (pressedChar.Key == ConsoleKey.RightArrow)
                {
                    gameOverWindow.ChangeActiveButton("right");
                }
                else if (pressedChar.Key == ConsoleKey.LeftArrow)
                {
                    gameOverWindow.ChangeActiveButton("left");
                }
                else if (pressedChar.Key == ConsoleKey.R || (gameOverWindow.GetActiveButton() == 0 && pressedChar.Key == ConsoleKey.Enter))
                {
                    Console.Clear();
                    SelectNumPlayers();
                    needtoRender = false;
                }
                else if (pressedChar.Key == ConsoleKey.M || (gameOverWindow.GetActiveButton() == 1 && pressedChar.Key == ConsoleKey.Enter))
                {
                    Console.Clear();
                    MakeSelection();
                    needtoRender = false;
                }
                else
                {
                    needtoRender = false;
                }
            } while (needtoRender);

        }
    }
}
