using System;
using System.Linq;

namespace _03.PhoneShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(", ").ToList();


            var cmd = Console.ReadLine();

            while (cmd != "End")
            {
                var cmdSplit = cmd.Split(" - ");

                var command = cmdSplit[0];

                if (command == "Add")
                {
                    var phone = cmdSplit[1];
                    if (list.Contains(phone) == false)
                    {
                        list.Add(phone);
                    }
                }
                else if (command == "Remove")
                {
                    var phone = cmdSplit[1];
                    if (list.Contains(phone))
                    {
                        list.Remove(phone);
                    }
                }
                else if (command == "Bonus phone")
                {
                    var phones = cmdSplit[1].Split(":").ToList();
                    var phone1 = phones[0];
                    var phone2 = phones[1];
                    if (list.Contains(phones[0]))
                    {
                        var index = list.IndexOf(phone1);
                        list.Insert(index + 1, phone2);
                    }
                }
                else if (command == "Last")
                {
                    var phone = cmdSplit[1];
                    if (list.Contains(phone))
                    {
                        list.Remove(phone);
                        list.Add(phone);
                    }
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ",list));
        }
    }
}
