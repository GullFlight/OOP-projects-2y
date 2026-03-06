namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;

public class FileFileSystemComponent : IFileComponent
{
    private readonly Lazy<string> _text;

    public string Text => _text.Value;

    public string Name { get; }

    public string Path { get; }

    public FileFileSystemComponent(string name, string path)
    {
        Name = name;
        Path = path;
        _text = new Lazy<string>(() => File.ReadAllText(Path), LazyThreadSafetyMode.PublicationOnly);
    }

    public void Accept(IFileSystemComponentVisitor component)
    {
        component.Visit(this);
    }
}