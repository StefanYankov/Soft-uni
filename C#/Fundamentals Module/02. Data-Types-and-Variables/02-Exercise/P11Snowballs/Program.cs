namespace P11Snowballs
{
    using System;
    using System.Numerics;
    public class Program
    {
        public static void Main()
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            int snowballSnow;
            int snowballTime;
            int snowballQuality;
            BigInteger largestSnowball = 0;
            BigInteger snowballValue;
            BigInteger[] snowBallData = { 0, 0, 0, 0 };

            for (int i = 0; i < numberOfSnowballs; i++)
            {

                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > largestSnowball)
                {
                    largestSnowball = snowballValue;
                    snowBallData[0] = snowballSnow;
                    snowBallData[1] = snowballTime;
                    snowBallData[2] = snowballValue;
                    snowBallData[3] = snowballQuality;
                }
            }

            Console.WriteLine($"{snowBallData[0]} : {snowBallData[1]} = {snowBallData[2]} ({snowBallData[3]})");
        }
    }
}
