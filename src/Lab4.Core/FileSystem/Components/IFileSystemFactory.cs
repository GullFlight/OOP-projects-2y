namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public interface IFileSystemFactory
{
    IFileComponent CreateFileComponent(string fileName, string path);

    IDirectoryComponent CreateDirectoryComponent(string directoryName, string path);
}