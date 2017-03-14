using System;

namespace DesignPatterns.Command.Logging
{
    public class Program1
    {
        public static void Main1(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }

            var processor = new CommandExecutor1();
            processor.ExecuteCommand(args);
        }

        public static void PrintUsage()
        {
            Console.WriteLine("Usage: LoggingDemo CommandName Arguments");
            Console.WriteLine("Commands:");
            Console.WriteLine("     UpdateQuantity number");
            Console.WriteLine("     CreateOrder");
            Console.WriteLine("     ShipOrder");
        }
    }
}
