using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            animals.Add(new Bear("mecho"));
            animals.Add(new Mammal("elephant"));
            animals.Add(new Reptile("dinosaur"));
        }
    }
}