public class Program
{

    private static string[] elements;
    private static string[] mutated;
    private static int k;
    public static void Main()
    {
        elements = new[] { "A", "B", "C" };
        k = int.Parse(Console.ReadLine());
        mutated = new string[k];
        Permutate(0, k);
    }

    private static void Permutate(int index, int k)
    {
        if (index >= mutated.Length)
        {
            Console.WriteLine(string.Join(' ', mutated));
            return;
        }

        for (int i = 0; i < elements.Length; i++)
        {
            mutated[index] = elements[i];
            Permutate(index + 1, k);
        }
    }
}