using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    private readonly IOutputMode _mode;

    public TreeListCommand(int depth, IOutputMode mode)
    {
        _depth = depth;
        _mode = mode;
    }

    public ExecuteResult Execute(FileSystemContext fileSystemContext)
    {
        if (fileSystemContext.FileSystem == null)
            return new ExecuteResult.Failure("FileSystem is not chosen");

        var treeVisualizer = new TreeVisualizer(_depth);

        var factory = new FileSystemComponentFactory();
        IDirectoryComponent currentDirectory = factory
            .CreateDirectoryComponent(fileSystemContext.GetDirectoryName(fileSystemContext.AbsolutePath), fileSystemContext.AbsolutePath);

        currentDirectory.Accept(treeVisualizer);
        return _mode.Execute(fileSystemContext, treeVisualizer.Value);
    }
}