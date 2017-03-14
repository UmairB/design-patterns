namespace DesignPatterns.Command.Logging.Commands
{
    public class ShipOrderCommand : ICommand, ICommandFactory
    {
        public string CommandName => "ShipOrder";

        public string Description => "ShipOrder";

        public void Execute()
        {
        }

        public ICommand MakeCommand(string[] arguments)
        {
            return new ShipOrderCommand();
        }
    }
}