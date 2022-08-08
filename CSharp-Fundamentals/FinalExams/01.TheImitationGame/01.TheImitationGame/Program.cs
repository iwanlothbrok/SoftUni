using System;
using System.Text;

namespace _01.TheImitationGame
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder(input);
            var cmd = Console.ReadLine();

            while (cmd != "Decode")
            {
                var command = cmd.Split("|");
                var spllitedCmd = command[0];

                if (spllitedCmd == "ChangeAll")
                {
                    var oldChars = command[1];
                    var newChars = command[2];
                    sb.Replace(oldChars, newChars);
                }
                else if (spllitedCmd == "Move")
                {
                    var index = int.Parse(command[1]);
                    var neededOne = sb.ToString().Substring(0, index);
                    sb.Remove(0, index);
                    sb.Append(neededOne);
                }
                else if (spllitedCmd == "Insert")
                {
                    var index = int.Parse(command[1]);
                    var neededChar = command[2];
                    sb.Insert(index, neededChar);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {sb.ToString()}");
        }
    }
}
