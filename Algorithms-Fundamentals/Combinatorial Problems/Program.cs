public class Program
{

    private static string[] elements;
    private static string[] mutated;
    private static bool[] used;
    public static void Main()
    {
        elements = new[] { "A", "B", "C" };
        mutated = new string[elements.Length];
        used = new bool[elements.Length];

        Permutate(0);
    }

    private static void Permutate(int index)
    {
        if (index >= mutated.Length)
        {
            Console.WriteLine(string.Join(' ', mutated));
            return;
        }

        for (int i = 0; i < mutated.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                mutated[index] = elements[i];
                Permutate(index + 1);
                used[i] = false;
            }
        }
    }
}