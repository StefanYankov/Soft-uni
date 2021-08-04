namespace P10PokeMon
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int originalPokePower = pokePower;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokeCount = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokeCount++;

                if (pokePower != 0)
                {
                    int fullPart = originalPokePower / pokePower;
                    int decimalPart = originalPokePower % pokePower;

                    if (fullPart == 2 && decimalPart == 0)
                    {
                        if (exhaustionFactor != 0)
                        {
                            pokePower /= exhaustionFactor;

                        }
                    }
                }

            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCount);
        }
    }
}
