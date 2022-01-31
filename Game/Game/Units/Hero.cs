using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.Game
{
    class Hero: Unit
    {
        public char renderChar = '@';

        public Hero(string name, int x, int y): base(name, x, y)
        {
        }

        public void MoveRight()
        {
            SetX(GetX()+1);
        }

        public void MoveLeft()
        {
            SetX(GetX() - 1);
        }

        public void PrintLegend(char renderChar)
        {
            Console.WriteLine($"Hero - {renderChar}");
        }
    }
}
