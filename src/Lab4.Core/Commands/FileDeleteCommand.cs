namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _fileName;

    public FileDeleteCommand(string fileName)
    {
        _fileName = fileName;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        fileSystemContext.FileSystem.Delete(_fileName);
        return new ExecuteResult.Success();
    }
}