using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    using Contracts;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmd = args.Split();
            string[] arg = cmd.Skip(1).ToArray();
            Assembly assembly = Assembly.GetEntryAssembly();
            Type command = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmd[0]}Command");
            if (command != null)
            {
                MethodInfo execute = command.GetMethod("Execute");
                var newCommand = Activator.CreateInstance(command);
                object result = (string)execute.Invoke(newCommand, new object[] { arg });
                return result.ToString();
            }
            return null;
        }
    }
}
