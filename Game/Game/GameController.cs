using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.Game;

namespace Game
{
    class GameController
    {
        GameScreen gameScreen;

        public GameController()
        {
        }
        public void StartGame()
        {
            InitGame();

            StartGameLoop();
        }

        public void InitGame()
        {
            Random rnd = new Random();
            Hero hero = new Hero("Superman", rnd.Next(100), rnd.Next(20, 25));
            List<Enemy> EnemyList = new List<Enemy>();
            gameScreen = new GameScreen(100, 25, hero, EnemyList);
            for (int i = 0; i < 4; i++)
            {
                gameScreen.AddEnemy(new Enemy(i, rnd.Next(100), rnd.Next(20), $"Enemy{i}"));
            }
        }

        public void StartGameLoop()
        {
            bool needtoRender = true;
            do
            {
                Console.Clear();
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needtoRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            gameScreen.MoveHeroRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            gameScreen.MoveHeroLeft();
                            break;
                    }
                }

                gameScreen.Render();
                gameScreen.MoveAllEnemiesDown();
                System.Threading.Thread.Sleep(1000);
            } while (needtoRender);
        }
    }
}
