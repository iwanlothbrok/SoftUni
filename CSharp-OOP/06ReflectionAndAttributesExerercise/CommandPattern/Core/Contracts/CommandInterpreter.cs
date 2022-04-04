using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split(' ');

            string cmd = inputInfo[0] + "Command";
            string[] parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes()
                 .Where(n => n.Name == cmd).FirstOrDefault();

           // if (type == null)
           // {
           //     throw new InvalidOperationException("Invalid command");
           // }
            ICommand command = (ICommand)Activator.CreateInstance(type);// SWAP IN FOREACH
            string result = command.Execute(parameters);
            return result;
        }
    }
}
