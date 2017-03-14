using DesignPatterns.Command.Logging.Commands;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Command.Logging
{
    public class Program2
    {
        public static void Main2(string[] args)
        {
            var availableCommands = GetAvailableCommands();

            if (args.Length == 0)
            {
                PrintUsage(availableCommands);
                return;
            }

            var parser = new CommandParser(availableCommands);
            var command = parser.ParseCommand(args);

            if (null != command)
                command.Execute();
        }

        private static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new CreateOrderCommand(),
                new UpdateQuantityCommand(),
                new ShipOrderCommand()
            };
        }

        public static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("Usage: LoggingDemo CommandName Arguments");
            Console.WriteLine("Commands:");
            foreach (var command in availableCommands)
                Console.WriteLine("    {0}", command.Description);
        }
    }
}
