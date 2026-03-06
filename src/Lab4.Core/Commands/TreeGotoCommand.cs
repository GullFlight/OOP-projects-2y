namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (string.IsNullOrEmpty(_path))
            return new ExecuteResult.Failure("Path is empty");

        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        fileSystemContext.SetCurrentPath(_path);
        return new ExecuteResult.Success();
    }
}