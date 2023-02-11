public class Program
{
    public static void Main()
    {
        var elements = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

        var searched = int.Parse(Console.ReadLine());

        BinarySearch(elements, searched);
    }

    private static int BinarySearch(int[] elements, int searched)
    {
        var left = 0;
        var right = elements.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;


            if (elements[mid] == searched)
            {
                return mid;
            }

            if (elements[mid] < searched)
            {
                left =mid + 1;

            }
            else
            {
                right = mid - 1;
            }


        }

        return -1;
    }
}