using Game.GUI;
using System;
using System.Collections.Generic;
using Units.Game;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            //GameController myGame = new GameController();
            //myGame.StartGame();

            //Button button = new Button(2, 2, 15, 5, "Quit");
            //button.Render();
            //List<string> strings = new List<string> { "Super Game", "Made by AB", "Made in Vilnius Coding School" };
            //TextBlock textBlock = new TextBlock(30, 2, 30, strings);
            //textBlock.Render();

            GuiController controller = new GuiController();

            Console.CursorVisible = false;
            controller.ShowMenu();
            controller.MakeSelection();
            //MenuWindow menuWindow = new MenuWindow();
            //menuWindow.Render();

            //CreditWindow creditWindow= new CreditWindow();
            //creditWindow.Render();

            Console.ReadKey();

        }
    }
}
