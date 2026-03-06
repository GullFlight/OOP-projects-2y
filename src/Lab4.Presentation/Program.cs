using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static ProgramResult Main(string[] args)
    {
        var context = new FileSystemContext();
        var outputMode = new ConsoleShowMode();
        var connectionMode = new LocalConnectionMode(outputMode, context.AbsolutePath);
        var parser = new CommandParser(connectionMode, outputMode);

        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null)
                return new ProgramResult.Failure("exited");

            ICommand? command = parser.Parse(input);

            if (command != null)
                command.Execute(context);

            return new ProgramResult.Success();
        }
    }
}