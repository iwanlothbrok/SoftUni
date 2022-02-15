using System;
using System.Linq;
using System.Collections.Generic;
namespace PasswordReset

{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] cmdArr = command.Split(' ');
                string cmd = cmdArr[0];
                switch (cmd)
                {
                    case "TakeOdd":
                        string takeOdd = string.Empty;
                        for (int i = 0; i < password.Length; i++)
                        {

                            if (i % 2 == 1)
                            {
                                takeOdd += password[i];
                            }
                        }
                        password = takeOdd;
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        int index = int.Parse(cmdArr[1]);
                        int lenght = int.Parse(cmdArr[2]);
                        password = password.Remove(index, lenght);
                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        string substring = cmdArr[1];
                        string substitute = cmdArr[2];
                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;


                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
