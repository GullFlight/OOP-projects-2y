namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent fileSystemComponent);

    void Visit(DirectoryFileSystemComponent directoryFileSystemComponent);
}