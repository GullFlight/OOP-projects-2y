using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly IConnectionMode _mode;

    public FileShowCommand(string path, IConnectionMode mode)
    {
        _path = path;
        _mode = mode;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        if (string.IsNullOrEmpty(_path))
            return new ExecuteResult.Failure("Path is empty");

        _mode.Execute(_path, fileSystemContext);
        return new ExecuteResult.Success();
    }
}