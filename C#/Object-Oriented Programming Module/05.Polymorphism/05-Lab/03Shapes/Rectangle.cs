using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get => this.height;
            private set
            {

                this.height = value;
            }
        }

        public int Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}