using System;

namespace DesignPatterns.Command.Logging.Commands
{
    public class NotFoundCommand : ICommand
    {
        public string RequestedCommand { get; set; }

        public void Execute()
        {
            Console.WriteLine("Command {0} not found", RequestedCommand);
        }
    }
}
