using System;
using System.Linq;
using System.Collections.Generic;
namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(songsInput);

            string command = Console.ReadLine();
            while (songs.Any())
            {

                string[] cmdArr = command.Split();
                string cmd = cmdArr[0];
                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd == "Add")
                {
                    string result = string.Empty;
                    for (int i = 1; i < cmdArr.Length ; i++)
                    {
                        if (i == cmdArr.Length)
                        {
                            result += cmd[i];

                        }
                        else
                        {
                            result += cmdArr[i] + " ";
                        }
                    }
                    result = result.Trim();
                    if (songs.Contains(result))
                    {
                        Console.WriteLine($"{result} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(result);
                    }

                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                if (!songs.Any()) // rotate 
                {
                    Console.WriteLine("No more songs!");
                    return;
                }
                command = Console.ReadLine();

            }
        }

    }
}

