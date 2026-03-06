namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public interface IFileSystemComponent
{
    string Name { get; }

    string Path { get; }

    void Accept(IFileSystemComponentVisitor component);
}