namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        return fileSystemContext.Disconnect();
    }
}