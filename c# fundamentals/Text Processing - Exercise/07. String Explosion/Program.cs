using System;

public class Program
{
    public static void Main()
    {
        String input = Console.ReadLine();
        String[] divided = input.Split('>');

        int bomb = 0;
        int count = 0;
        for (int i = 1; i < divided.Length; i++)
        {
            bomb = int.Parse("" + divided[i][0]) + count;
            count = bomb - divided[i].Length;

            if (bomb > divided[i].Length)
                bomb = divided[i].Length;

            divided[i] = divided[i].Substring(bomb);
            if (count < 0)
                count = 0;
        }

        String result = String.Join(">", divided);
        Console.WriteLine(result);
    }
}