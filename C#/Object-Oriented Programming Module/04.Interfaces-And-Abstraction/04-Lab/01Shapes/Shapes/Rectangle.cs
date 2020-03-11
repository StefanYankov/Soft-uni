using System;

namespace _01Shapes.Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public int Width { get; }
        public int Heigth { get; }
        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));

            for (int i = 0; i < this.Heigth - 2; i++)
            {
                Console.WriteLine("*" + new string(' ', this.Width - 2) + "*");
            }

            Console.WriteLine(new string('*', this.Width));
        }
    }
}
