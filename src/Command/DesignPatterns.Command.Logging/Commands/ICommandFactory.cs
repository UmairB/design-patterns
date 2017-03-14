namespace DesignPatterns.Command.Logging.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }

        string Description { get; }

        ICommand MakeCommand(string[] arguments);
    }
}