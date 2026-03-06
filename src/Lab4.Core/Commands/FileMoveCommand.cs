namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (string.IsNullOrEmpty(_sourcePath))
            return new ExecuteResult.Failure("Path is empty");

        if (string.IsNullOrEmpty(_destinationPath))
            return new ExecuteResult.Failure("Path is empty");

        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        fileSystemContext.FileSystem.Move(_sourcePath, _destinationPath);
        return new ExecuteResult.Success();
    }
}