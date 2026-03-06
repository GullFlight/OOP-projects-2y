using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void ConnectParseLink_ParsingConnectCommand()
    {
        // Arrange
        var parser = new ConnectParseLink();
        var iterator = new ArgumentIterator("connect C:\\project");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ConnectCommand>(result);
    }

    [Fact]
    public void DisconnectParseLink_ParsingDisconnectCommand()
    {
        // Arrange
        var parser = new DisconnectParseLink();
        var iterator = new ArgumentIterator("disconnect C:\\project");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<DisconnectCommand>(result);
    }

    [Fact]
    public void ConnectParseLink_ParsingConnectCommandWithMode()
    {
        // Arrange
        var parser = new ConnectParseLink();
        var iterator = new ArgumentIterator("connect C:\\project -m local");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ConnectCommand>(result);
    }

    [Fact]
    public void TreeGotoParseLink_ParsingTreeGotoCommand()
    {
        // Arrange
        var parser = new TreeGotoParseLink();
        var iterator = new ArgumentIterator("tree goto directory");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TreeGotoCommand>(result);
    }

    [Fact]
    public void TreeListParseLink_ParsingTreeListCommand()
    {
        // Arrange
        var parser = new TreeListParseLink();
        var iterator = new ArgumentIterator("tree list -d 3");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TreeListCommand>(result);
    }

    [Fact]
    public void TreeVisualizerWithDepth1_NotShowSubDirectory()
    {
        // Arrange
        var root = new DirectoryFileSystemComponent("root", "C://projects");
        var subDirectory = new DirectoryFileSystemComponent("subDirectory", "C://projects//subDirectory");

        var visualizer = new TreeVisualizer(1);

        // Act
        root.Accept(visualizer);
        string result = visualizer.Value;

        // Assert
        Assert.Contains("root", result, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("subDirectory", result, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void FileCopyParseLink_ParsingFileCopyCommand()
    {
        // Arrange
        var parser = new FileCopyParseLink();
        var iterator = new ArgumentIterator("file copy old.txt new.txt");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FileCopyCommand>(result);
    }

    [Fact]
    public void FileMoveParseLink_ParsingFileMoveCommand()
    {
        // Arrange
        var parser = new FileMoveParseLink();
        var iterator = new ArgumentIterator("file move old.txt new.txt");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FileMoveCommand>(result);
    }

    [Fact]
    public void FileDeleteParseLink_ParsingFileDeleteCommand()
    {
        // Arrange
        var parser = new FileDeleteParseLink();
        var iterator = new ArgumentIterator("file delete file.txt");

        // Act
        ICommand? result = parser.Parse(iterator);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FileDeleteCommand>(result);
    }

    [Fact]
    public void ConnectCommand_ShouldReturnedSuccess_ExecuteConnection()
    {
        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        var context = new FileSystemContext();
        fileSystemMock.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(true);
        var command = new ConnectCommand("C:\\project", "local");

        // Act
        ExecuteResult result = command.Execute(context);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ExecuteResult.Success>(result);
    }

    [Fact]
    public void TreeListCommand_ShouldReturnedSuccess_ExecuteConsoleMode()
    {
        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        var outputMock = new Mock<IOutputMode>();
        var context = new FileSystemContext("C:\\project", fileSystemMock.Object);
        fileSystemMock.Setup(fs => fs.DirectoryExists("C:\\project")).Returns(true);
        outputMock.Setup(m => m.Execute(context, It.IsAny<string>())).Returns(new ExecuteResult.Success());
        var command = new TreeListCommand(3, outputMock.Object);

        // Act
        ExecuteResult result = command.Execute(context);

        // Assert
        Assert.IsType<ExecuteResult.Success>(result);
        outputMock.Verify(m => m.Execute(context, It.IsAny<string>()), Times.Once);
    }
}