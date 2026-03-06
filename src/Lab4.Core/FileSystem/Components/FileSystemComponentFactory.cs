namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public class FileSystemComponentFactory : IFileSystemFactory
{
    public IFileComponent CreateFileComponent(string fileName, string path)
    {
        return new FileFileSystemComponent(fileName, path);
    }

    public IDirectoryComponent CreateDirectoryComponent(string directoryName, string path)
    {
        return new DirectoryFileSystemComponent(directoryName, path);
    }
}