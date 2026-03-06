namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public sealed class LocalConnectionMode : IConnectionMode
{
    private readonly string _filePath;

    public LocalConnectionMode(IOutputMode connectionMode, string filePath)
    {
        _filePath = filePath;
    }

    public ExecuteResult Execute(string filePath, IFileSystemContext fileSystemContext)
    {
        return fileSystemContext.Connect(_filePath);
    }
}