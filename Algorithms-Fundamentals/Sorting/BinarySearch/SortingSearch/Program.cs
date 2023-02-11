public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
        SortingSearch(numbers, 0);
        ;
    }

    private static void SortingSearch(int[] numbers, int idx)
    {
        for (int i = idx; i < numbers.Length; i++)
        {
            var min = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[min])
                {
                    min = j;
                }

            }
            Swap(i, min, numbers);
        }
    }

    private static void Swap(int first, int last, int[] numbers)
    {
        var temp = numbers[first];

        numbers[first] = numbers[last];

        numbers[last] = temp;
    }
}