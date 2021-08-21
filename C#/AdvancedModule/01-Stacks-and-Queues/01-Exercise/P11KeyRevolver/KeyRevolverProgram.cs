namespace P11KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolverProgram
    {
        public static void Main()
        {
            byte pricePerBullet = byte.Parse(Console.ReadLine());
            ushort sizeOfGunBarrel = ushort.Parse(Console.ReadLine());
            ushort gunBarrelCount = 0;
            byte[] bulletsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();
            Stack<byte> bullets = new Stack<byte>(bulletsInput);
            byte[] locksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();
            Queue<byte> locks = new Queue<byte>(locksInput);
            uint valueOfTheIntelligence = uint.Parse(Console.ReadLine());
            int bulletsUsed = 0;

            while (true)
            {
                if (locks.Count == 0)
                {
                    break;
                }

                byte currentBullet = bullets.Pop();
                byte currentLock = locks.Peek();

                if (currentLock >= currentBullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsUsed++;
                gunBarrelCount++;
                if (bullets.Count == 0)
                {
                    break;
                }
                if (gunBarrelCount == sizeOfGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                    gunBarrelCount = 0;
                }
            }

            if (locks.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var moneyEarned = valueOfTheIntelligence - (pricePerBullet * bulletsUsed);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
