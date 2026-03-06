namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommand
{
    ExecuteResult Execute(FileSystemContext fileSystemContext);
}