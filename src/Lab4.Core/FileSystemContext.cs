using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class FileSystemContext : IFileSystemContext
{
    public string CurrentPath { get; private set; }

    public string AbsolutePath { get; private set; }

    public string Mode { get; private set; }

    public IFileSystem? FileSystem { get; private set; }

    public FileSystemContext()
    {
        CurrentPath = string.Empty;
        AbsolutePath = string.Empty;
        Mode = string.Empty;
        FileSystem = null;
    }

    public FileSystemContext(string currentPath, IFileSystem? fileSystem)
    {
        CurrentPath = currentPath;
        AbsolutePath = currentPath;
        Mode = string.Empty;
        FileSystem = fileSystem;
    }

    public ExecuteResult Connect(string path, string mode = "local")
    {
        if (string.IsNullOrEmpty(path) || Path.Exists(path))
            return new ExecuteResult.Failure("File not found");

        if (mode != "local")
            throw new NotSupportedException("Mode not supported");

        string absolutePath = Path.GetFullPath(path);
        FileSystem = new LocalFileSystem(absolutePath);
        Mode = mode;
        AbsolutePath = absolutePath;
        CurrentPath = absolutePath;
        return new ExecuteResult.Success();
    }

    public ExecuteResult Disconnect()
    {
        if (FileSystem == null)
            return new ExecuteResult.Failure("File system not initialized");

        Mode = string.Empty;
        AbsolutePath = string.Empty;
        CurrentPath = string.Empty;
        return new ExecuteResult.Success();
    }

    public void SetCurrentPath(string path)
    {
        CurrentPath = path;
    }

    public string GetDirectoryName(string path)
    {
        string? directoryName = Path.GetDirectoryName(path);

        if (directoryName == null)
            return string.Empty;

        return directoryName;
    }
}