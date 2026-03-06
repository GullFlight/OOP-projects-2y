namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public interface IConnectionMode
{
    ExecuteResult Execute(string filePath, IFileSystemContext fileSystemContext);
}