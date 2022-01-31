using Game.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.Game
{
    class GameScreen
    {
        int width;
        int height;
        Hero hero;
        List<Enemy> EnemyList;
        Window gameWindow;


        public GameScreen(int width, int height, Hero hero, List<Enemy> EnemyList)
        {
            this.width = width;
            this.height = height;
            this.hero = hero;
            this.EnemyList = EnemyList;
            this.gameWindow = new Window(1, 1, width, height, '*');
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Game Screen width: {width}; height: {height}");
        }

        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        public Hero GetHero()
        {
            return hero;
        }

        public void MoveHeroRight()
        {
            hero.MoveRight();
        }

        public void MoveHeroLeft()
        {
            hero.MoveLeft();
        }

        public void AddEnemy(Enemy enemy)
        {
            EnemyList.Add(enemy);
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in EnemyList)
            {
                enemy.MoveDown();
            }
        }

        public Enemy GetEnemyById(int id)
        {
            foreach (Enemy enemy in EnemyList)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }
            return null;
        }

        public void Render()
        {
            gameWindow.Render();
            hero.Render(hero.renderChar);
            foreach (Enemy enemy in EnemyList)
            {
                enemy.Render(enemy.renderChar);
            }
            Console.SetCursorPosition(2, 2);
            hero.PrintLegend(hero.renderChar);
            Console.SetCursorPosition(2, 3);
            EnemyList[0].PrintLegend(EnemyList[0].renderChar);
        }
    }
}
