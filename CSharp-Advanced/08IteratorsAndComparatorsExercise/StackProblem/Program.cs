using System;
using System.Collections.Generic;
using System.Linq;

namespace StackProblem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<string> myStack = new MyStack<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                string cmd = tokens[0];

                if (cmd == "Push")
                {
                    foreach (var item in tokens.Skip(1))
                    {
                        myStack.Push(item);
                    }
                }
                else if (cmd == "Pop")
                {
                    if (myStack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                        command = Console.ReadLine();
                        break;
                    }
                    myStack.Pop();
                }

                command = Console.ReadLine();
            }
            // count check
            if (myStack.Count == 0)
            {
                return;
            }
            
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
