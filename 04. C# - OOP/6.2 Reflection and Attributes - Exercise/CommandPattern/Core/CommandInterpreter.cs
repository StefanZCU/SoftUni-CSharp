namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType is null)
            {
                throw new InvalidOperationException("Command not found.");
            }

            ICommand commandInstance =
                Activator.CreateInstance(commandType) as ICommand;

            string result = commandInstance.Execute(commandArguments);

            return result.ToString();
        }
    }
}
