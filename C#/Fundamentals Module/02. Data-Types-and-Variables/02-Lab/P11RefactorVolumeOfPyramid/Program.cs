namespace P11RefactorVolumeOfPyramid
{
    using System;
    public class Program
    {
        public static void Main()
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());

            double area = length * width * height / 3;
            Console.WriteLine($"Pyramid Volume: {area:f2}");
        }
    }
}
