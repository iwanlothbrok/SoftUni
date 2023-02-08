

    var arr = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

int count = 0;
Console.WriteLine(recSum(arr, 0));

int recSum(int[] arr, int index)
{
    count++;
    if (index >= arr.Length)
    {
        return 0;
    }

    return arr[index] += recSum(arr, index+ 1);
}