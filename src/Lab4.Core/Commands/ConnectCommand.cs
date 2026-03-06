namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ConnectCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        return fileSystemContext.Connect(_path, _mode);
    }
}