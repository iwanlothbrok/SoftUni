public class Program
{
    public static string[] output;
    public static void Main()
    {
        var elements = Console.ReadLine().Split();
        output = new string[elements.Length];

        ReverseInput(elements, 0);
    }

    private static void ReverseInput(string[] elements, int idx)
    {
        if (idx == output.Length / 2)
        {
            Console.WriteLine(string.Join(' ', elements));
            return;
        }

        var temp = elements[idx];
        elements[idx] = elements[elements.Length - idx - 1];
        elements[elements.Length - idx - 1] = temp;

        ReverseInput(elements, idx + 1);
    }
}   