namespace P10Crossroads
{
    using System;
    using System.Collections.Generic;
    public class CrossroadsProgram
    {
        public static void Main()
        {
            Queue<string> crossRoadsQueue = new Queue<string>();
            byte greenLightDuration = byte.Parse(Console.ReadLine());
            byte freeWindowDuration = byte.Parse(Console.ReadLine());
            int numberOfCarsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }

                if (!input.Equals("green"))
                {
                    crossRoadsQueue.Enqueue(input);
                    continue;
                }

                int tempGreenLightDuration = greenLightDuration;
                while (tempGreenLightDuration > 0 && crossRoadsQueue.Count > 0)
                {
                    string carName = crossRoadsQueue.Dequeue();
                    int carLength = carName.Length;

                    if ((tempGreenLightDuration - carLength) >= 0)
                    {
                        tempGreenLightDuration -= carLength;
                        numberOfCarsPassed++;
                    }
                    else
                    {
                        tempGreenLightDuration += freeWindowDuration;

                        if ((tempGreenLightDuration - carLength) >= 0)
                        {
                            numberOfCarsPassed++;
                            break;
                        }

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{carName} was hit at {carName[tempGreenLightDuration]}.");
                        return;
                    }

                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{numberOfCarsPassed} total cars passed the crossroads.");
        }
    }
}
