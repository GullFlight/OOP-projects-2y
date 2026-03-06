using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public interface IFileSystemContext
{
    string CurrentPath { get; }

    string AbsolutePath { get; }

    string Mode { get; }

    ExecuteResult Connect(string path, string mode = "local");

    ExecuteResult Disconnect();

    IFileSystem? FileSystem { get; }
}