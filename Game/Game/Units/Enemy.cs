using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.Game
{
    class Enemy: Unit
    {
        public char renderChar = '+';

        private int id;

        public Enemy(int id, int x, int y, string name): base(name, x, y)
        {
            this.id = id;
        }

        public void MoveDown()
        {
            SetY(GetY() + 1);
        }

        public int GetId()
        {
            return id;
        }

        public void PrintLegend(char renderChar)
        {
            Console.WriteLine($"Enemy - {renderChar}");
        }

    }
}
