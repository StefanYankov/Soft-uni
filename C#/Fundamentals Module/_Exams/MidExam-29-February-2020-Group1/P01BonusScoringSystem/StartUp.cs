using System;

namespace P01BonusScoringSystem
{
    public class StartUp
    {
        public static void Main()
        {
            int studentCount = int.Parse(Console.ReadLine());
            int lectureCount = int.Parse(Console.ReadLine());
            int courseBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxStudentAttendances = 0;
            for (int i = 1; i <= studentCount; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double totalBonus = (studentAttendances*1.0  / lectureCount*1.0) * (5 + courseBonus);
                    
                if(totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxStudentAttendances = studentAttendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxStudentAttendances} lectures.");
        }
    }
}
