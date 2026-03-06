namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public sealed class ConsoleShowMode : IOutputMode
{
    public ExecuteResult Execute(IFileSystemContext fileSystemContext, string filePath)
    {
        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        string content = fileSystemContext.FileSystem.ReadFile(filePath);
        Console.WriteLine(content);
        return new ExecuteResult.Success();
    }
}