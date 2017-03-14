using DesignPatterns.Command.Logging.Commands;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Command.Logging
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        public ICommand ParseCommand(string[] args)
        {
            var requestedCommand = args[0];

            var command = FindRequestedCommand(requestedCommand);

            if (null == command)
                return new NotFoundCommand { RequestedCommand = requestedCommand };

            return command.MakeCommand(args);
        }

        private ICommandFactory FindRequestedCommand(string commandName)
        {
            return availableCommands
                .FirstOrDefault(cmd => cmd.CommandName == commandName);
        }
    }
}
