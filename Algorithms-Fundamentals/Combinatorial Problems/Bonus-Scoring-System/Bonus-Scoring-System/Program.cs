public class Program
{
    public static void Main()
    {
        double studentsCount = double.Parse(Console.ReadLine());
        double lecturesCount = double.Parse(Console.ReadLine());
        double bonus = double.Parse(Console.ReadLine());



        double maxBonus = 0;
        double maxLectures = 0;
        for (int i = 0; i < studentsCount; i++)
        {
            int cmd = int.Parse(Console.ReadLine());

            double totalBonus = Math.Round((cmd / lecturesCount) * (5 + bonus));

            if (totalBonus > maxBonus)
            {
                maxBonus = totalBonus;
                maxLectures = cmd;
            }
        }

        Console.WriteLine(maxBonus);
        Console.WriteLine(maxLectures);
    }

}