namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public interface IDirectoryComponent : IFileSystemComponent
{
    IReadOnlyCollection<IFileSystemComponent> Components { get; }
}