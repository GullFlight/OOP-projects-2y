using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    void Rename(string path, string newName);

    void Delete(string path);

    void Copy(string sourcePath, string targetPath);

    void Move(string sourcePath, string targetPath);

    string ReadFile(string path);

    void Show(IFileComponent component);

    void Show(IDirectoryComponent component);

    string GetDirectoryName(string path);

    bool FileExists(string path);

    bool DirectoryExists(string path);
}