namespace CommandPattern.Core.Commands
{
    using System;

    using Contracts;

    public class ExitCommand : ICommand
    {
        private const int DefaultExitCode = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(DefaultExitCode);

            return null;
        }
    }
}
