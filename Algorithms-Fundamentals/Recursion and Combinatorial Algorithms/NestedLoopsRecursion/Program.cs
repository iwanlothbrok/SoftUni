public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var arr = new int[n];


        Revert(n, arr, 0);
    }

    private static void Revert(int n, int[] arr, int idx)
    {

        if (idx >= arr.Length)
        {
            Console.WriteLine(string.Join(' ', arr));
            return;
        }

        for (int i = 1; i <= arr.Length; i++)
        {
            arr[idx] = i;

            Revert(n, arr, idx + 1);
        }
    }
}