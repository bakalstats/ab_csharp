using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.Game
{
    class Unit
    {
        private string Name;
        private int X;
        private int Y;

        public Unit(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public void Render(char renderChar)
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(renderChar);
            //Console.WriteLine($"Name: {Name}; Position: ({X},{Y})");
        }

        public void SetX(int x)
        {
            X = x;
        }

        public int GetX()
        {
            return X;
        }

        public void SetY(int y)
        {
            Y = y;
        }
        public int GetY()
        {
            return Y;
        }
    }
}
