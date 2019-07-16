using System;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double width;
        private double height;
        private double length;

        public double Width
        {
            get => this.width;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double GetLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height + 2 * this.Width * this.Height);
        }

        public double GetSurfaceArea()
        {
            return (2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.GetVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}