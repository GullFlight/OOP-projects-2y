namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public class DirectoryFileSystemComponent : IDirectoryComponent
{
    private readonly Lazy<IReadOnlyCollection<IFileSystemComponent>> _components;

    public string Name { get; }

    public string Path { get; }

    public DirectoryFileSystemComponent(string name, string path)
    {
        Name = name;
        Path = path;
        _components = new Lazy<IReadOnlyCollection<IFileSystemComponent>>(() => new List<IFileSystemComponent>());
    }

    public IReadOnlyCollection<IFileSystemComponent> Components => _components.Value;

    public void Accept(IFileSystemComponentVisitor component)
    {
        component.Visit(this);
    }
}