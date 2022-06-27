using System;

namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsCount = double.Parse(Console.ReadLine());
            var lecturestCount = double.Parse(Console.ReadLine());
            var bonus = double.Parse(Console.ReadLine());

            var maxBonus = 0.0;
            var maxAttendance = 0.0;


            for (int i = 0; i < studentsCount; i++)
            {
                var attendance = double.Parse(Console.ReadLine());
                var a = (5 + bonus);
                var b = attendance / lecturestCount;
                var currentBonus = b * a;

                if (maxBonus < currentBonus)
                {
                    maxBonus = currentBonus;
                    maxAttendance = attendance;
                }


            }
            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
//{ total bonus} = { student attendances} / { course lectures}
//*(5 + { additional bonus})