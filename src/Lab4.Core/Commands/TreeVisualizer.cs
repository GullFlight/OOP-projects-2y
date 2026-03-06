using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public sealed class TreeVisualizer : IFileSystemComponentVisitor
{
    private readonly StringBuilder _builder = new();
    private readonly int _maxDepth;
    private int _depth;
    private int _padding;

    public string Value => _builder.ToString();

    public TreeVisualizer(int maxDepth)
    {
        _maxDepth = maxDepth;
    }

    public void Visit(FileFileSystemComponent fileSystemComponent)
    {
        if (_depth >= _maxDepth) return;
        _builder.Append(' ', _padding);
        _depth++;
        _builder.AppendLine(fileSystemComponent.Name);
    }

    public void Visit(DirectoryFileSystemComponent directoryFileSystemComponent)
    {
        if (_depth >= _maxDepth) return;
        _builder.Append(' ', _padding);
        _builder.AppendLine(directoryFileSystemComponent.Name);
        _depth++;
        _padding += 1;
        foreach (IFileSystemComponent child in directoryFileSystemComponent.Components)
        {
            child.Accept(this);
        }

        _depth -= 1;
        _padding += 1;
    }
}