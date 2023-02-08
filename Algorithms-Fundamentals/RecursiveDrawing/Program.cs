int n = Convert.ToInt32(Console.ReadLine());

Draw(n);

void Draw(int n)
{
    if (n == 0)
    {
        return;
    }
    Console.WriteLine(new string('*', n));

    Draw(n - 1);

    Console.WriteLine(new string('+', n));
}