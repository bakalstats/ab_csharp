using Game.GUI;
using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            //GuiController controller = new GuiController();
            //Console.CursorVisible = false;
            //controller.ShowMenu();
            //controller.MakeSelection();
            //Console.ReadKey();

            GuiController controller = new GuiController();
            Console.CursorVisible = false;
            controller.ShowMenu();
            controller.MakeSelection();

            //NumPlayersWindow playersMenu = new NumPlayersWindow();
            //playersMenu.Render();


        }
    }
}
