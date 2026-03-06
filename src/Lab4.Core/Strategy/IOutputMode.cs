namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public interface IOutputMode
{
    ExecuteResult Execute(IFileSystemContext fileSystemContext, string filePath);
}