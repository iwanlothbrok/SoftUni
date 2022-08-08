using System;
using System.Linq;
using System.Text;

namespace _01.DecryptingCommands
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder(input);


            var cmd = Console.ReadLine();
            while (cmd != "Finish")
            {
                var splittedCmd = cmd.Split(' ');
                var command = splittedCmd[0];

                if (command == "Replace")
                {
                    var oldChar = splittedCmd[1];
                    var newChar = splittedCmd[2];
                    sb.Replace(oldChar, newChar);
                    Console.WriteLine(sb.ToString());

                }
                else if (command == "Cut")
                {
                    var startIndex = int.Parse(splittedCmd[1]);
                    var endIndex = int.Parse(splittedCmd[2]);
                    var substring = string.Empty;
                    if (startIndex < 0 || startIndex > sb.Length
                        || endIndex > sb.Length || startIndex > endIndex) // andd end < 0
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else
                    {
                        var lenght = endIndex - startIndex;
                        //substring = sb.ToString().Substring(startIndex, lenght+1);
                        sb.Remove(startIndex, lenght+1);
                        Console.WriteLine(sb.ToString());
                    }
                }
                else if (command == "Make")
                {
                    var lowerOrUpper = splittedCmd[1];
                    if (lowerOrUpper == "Lower")
                    {
                        string s = sb.ToString().ToLower();

                        sb.Clear();
                        sb.Append(s);
                    }
                    else
                    {

                        string s = sb.ToString().ToUpper();

                        sb.Clear();
                        sb.Append(s);
                    }
                    Console.WriteLine(sb.ToString());
                }
                else if (command == "Check")
                {
                    var neededWord = splittedCmd[1];
                    if (sb.ToString().Contains(neededWord))
                    {
                        Console.WriteLine($"Message contains {neededWord}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {neededWord}");
                    }
                }
                else if (command == "Sum")
                {
                    var startIndex = int.Parse(splittedCmd[1]);
                    var endIndex = int.Parse(splittedCmd[2]);
                    var subString = string.Empty;
                    if (startIndex < 0 || startIndex > sb.Length
                        || endIndex > sb.Length || startIndex > endIndex) // andd end < 0
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    else
                    {
                        var lenght = endIndex - startIndex;
                        subString = sb.ToString().Substring(startIndex, lenght+1);
                        var sum = subString.Select(part => Convert.ToInt32(part))
                        .Where(num => num > 3)
                        .Sum();
                        Console.WriteLine(sum);
                    }
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
