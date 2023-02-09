

int input = Convert.ToInt32(Console.ReadLine());
int[] arr = new int[input];

int index = 0;
Vector(arr, index);

void Vector(int[] arr, int index)
{
    if (index == arr.Length)
    {
        Console.WriteLine(String.Join(' ', arr));
        return;
    }
    for (int i = 0; i <= 1; i++)
    {
        arr[index] = i;

        Vector(arr, index + 1);
    }
}
