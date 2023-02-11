public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

        BubbleSort(numbers, 0);

    }

    private static void BubbleSort(int[] numbers, int idx)
    {

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 1; j < numbers.Length - i; j++)
            {
                if (numbers[j - 1] > numbers[j])
                {
                    Swap(j - 1, j, numbers);
                }
            }
        }
    }

    private static void Swap(int first, int last, int[] numbers)
    {
        var temp = numbers[first];

        numbers[first] = numbers[last];

        numbers[last] = temp;
    }
}