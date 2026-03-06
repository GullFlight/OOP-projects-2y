using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private readonly string _path;

    public LocalFileSystem(string path)
    {
        _path = path;
    }

    public void Rename(string path, string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentNullException(nameof(newName));

        if (!File.Exists(path))
            throw new FileNotFoundException($"File '{path}' not found.");

        string newPath = Path.Combine(_path, newName);

        File.Move(path, newPath, overwrite: true);
    }

    public void Delete(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        File.Delete(path);
    }

    public void Copy(string sourcePath, string targetPath)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException(sourcePath);

        if (!File.Exists(targetPath))
            throw new FileNotFoundException(targetPath);

        string fileName = Path.GetFileName(targetPath);
        string newPath = Path.Combine(_path, fileName);

        File.Copy(sourcePath, newPath, overwrite: true);
    }

    public void Move(string sourcePath, string targetPath)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException(sourcePath);

        if (!Directory.Exists(targetPath))
            throw new DirectoryNotFoundException(targetPath);

        File.Move(sourcePath, targetPath);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public void Show(IFileComponent component)
    {
        Console.WriteLine(component.Text);
    }

    public void Show(IDirectoryComponent component)
    {
        foreach (IFileSystemComponent part in component.Components)
        {
            Console.WriteLine(part.Name);
        }
    }

    public string GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path) ?? string.Empty;
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }
}