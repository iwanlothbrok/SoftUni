using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var sb = new StringBuilder(input);


        var command = Console.ReadLine();
        while (command != "Reveal")
        {
            char[] separaton = { '|', ':' };
            var splittedCmd = command.Split(separaton, StringSplitOptions.RemoveEmptyEntries);


            var cmd = splittedCmd[0];

            if (cmd == "Reverse")
            {
                string neededOne = splittedCmd[1];

                if (sb.ToString().Contains(neededOne))
                {
                    var index = sb.ToString().IndexOf(neededOne);
                    sb.Remove(index, neededOne.Length); // check if the indexes are right 

                    var subReversed = string.Empty;
                    char[] charArray = neededOne.ToCharArray();
                    Array.Reverse(charArray);
                    subReversed = new string(charArray);

                    sb.Insert(sb.Length, subReversed);
                }
                else
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }
            }
            else if (cmd == "ChangeAll")
            {
                var oldOne = splittedCmd[1];
                var newOne = splittedCmd[2];

                sb.Replace(oldOne, newOne);
            }
            else if (cmd == "InsertSpace")
            {
                var index = int.Parse(splittedCmd[1]);
                sb.Insert(index, " ");
            }
            Console.WriteLine(sb.ToString());
            command = Console.ReadLine();
        }
        Console.WriteLine($"You have a new text message: {sb.ToString()}");
    }
}
