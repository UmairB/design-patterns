namespace DesignPatterns.Command.Logging.Commands
{
    public class CreateOrderCommand : ICommand, ICommandFactory
    {
        public string CommandName => "CreateOrder";

        public string Description => "CreateOrder";

        public void Execute()
        {
        }

        public ICommand MakeCommand(string[] arguments)
        {
            return new CreateOrderCommand();
        }
    }
}