namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _name;

    public FileRenameCommand(string sourcePath, string name)
    {
        _sourcePath = sourcePath;
        _name = name;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (string.IsNullOrEmpty(_sourcePath))
            return new ExecuteResult.Failure("Path is empty");

        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        fileSystemContext.FileSystem.Rename(_sourcePath, _name);
        return new ExecuteResult.Success();
    }
}