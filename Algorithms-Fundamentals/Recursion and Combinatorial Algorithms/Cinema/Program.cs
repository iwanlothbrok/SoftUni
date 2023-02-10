public class Program
{
    public static List<string> people;
    public static string[] outputPeople;
    public static bool[] locked;

    public static void Main()
    {
        people = Console.ReadLine().Split(", ").ToList();

        outputPeople = new string[people.Count];
        locked = new bool[people.Count];

        while (true)
        {
            var cmd = Console.ReadLine();

            if (cmd == "generate")
            {
                break;
            }
            var command = cmd.Split(" - ");

            var name = command[0];
            var position = int.Parse(command[1]) - 1;

            outputPeople[position] = name;
            locked[position] = true;

            people.Remove(name);
        }

        Permute(0);
    }

    private static void Permute(int idx)
    {
        if (idx >= people.Count)
        {
            PrintPermute();
            return;
        }

        Permute(idx + 1);

        for (int i = idx + 1; i < people.Count; i++)
        {
            if (locked[i] == false)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }
    }

    private static void PrintPermute()
    {
        var idx = 0;

        for (int i = 0; i < outputPeople.Length; i++)
        {
            if (locked[i] == false)
            {
                outputPeople[i] = people[idx++];
            }
        }
        Console.WriteLine(String.Join(", ", outputPeople));
    }

    private static void Swap(int idx, int i)
    {
        var temp = people[idx];
        people[idx] = people[i];
        people[i] = temp;
    }
}