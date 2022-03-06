using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIteratorProblem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;
            string command = Console.ReadLine();

            try
            {
                while (command != "END")
                {
                    string[] tokens = command.Split();
                    string cmd = tokens[0];

                    switch (cmd)
                    {
                        case "Create":
                            List<string> elements = tokens
                                                    .Skip(1).ToList();
                            listyIterator = new ListyIterator<string>(elements);
                            break;

                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;

                        case "Print":
                            listyIterator.Print();
                            break;

                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;


                    }


                    command = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                command = Console.ReadLine();
            }
        }
    }
}
