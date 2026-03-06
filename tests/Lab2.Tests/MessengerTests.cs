using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.UserItems;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MessengerTests
{
    [Fact]
    public void ReceiveMessage_ShouldBeSaved_WhenUserUnreadMessage()
    {
        // Arrange
        var user = new User();
        var recipient = new UserRecipient(user);
        var message = new Message("Title", "Body", ImportanceLevel.Normal);

        // Act
        recipient.Receive(message);

        // Assert
        Assert.Single(user.Messages);
        Assert.Equal(MessageStatus.Unread, user.Messages[message]);
    }

    [Fact]
    public void MarkAsRead_ShouldHaveExpectedStatus_WhenUserMarkAsReadMessage()
    {
        // Arrange
        var user = new User();
        var recipient = new UserRecipient(user);
        var message = new Message("Title", "Body", ImportanceLevel.Normal);

        // Act
        recipient.Receive(message);
        user.MarkMessageAsRead(message);

        // Assert
        Assert.Single(user.Messages);
        Assert.Equal(MessageStatus.Read, user.Messages[message]);
    }

    [Fact]
    public void MarkAsRead_ShouldHaveException_WhenUserTwiceMarkAsReadMessage()
    {
        // Arrange
        var user = new User();
        var recipient = new UserRecipient(user);
        var message = new Message("Title", "Body", ImportanceLevel.Normal);

        // Act
        recipient.Receive(message);
        user.MarkMessageAsRead(message);

        // Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkMessageAsRead(message));
    }

    [Fact]
    public void ImportanceFilter_FiltersLowPriorityMessages()
    {
        // Arrange
        var mockrecipient = new MockRecipient();
        var filteredrecipient = new ImportanceFilter(mockrecipient, ImportanceLevel.High);
        var message = new Message("Title", "Body", ImportanceLevel.Low);

        // Act
        filteredrecipient.Receive(message);

        // Assert
        Assert.Equal(0, mockrecipient.MessageCalls);
    }

    [Fact]
    public void LoggingDecorator_ShouldCallLogger_WhenMessageReceived()
    {
        // Arrange
        var mockLogger = new MockLogger(new ConsoleLogger());
        var recipient = new MockRecipient();
        var loggingRecipient = new LoggerMessage(recipient, mockLogger);
        var message = new Message("Title", "Body", ImportanceLevel.Normal);

        // Act
        loggingRecipient.Receive(message);

        // Assert
        Assert.Single(mockLogger.Messages);
        Assert.Equal(1, mockLogger.LogMessageCalls);
    }

    [Fact]
    public void FormattingArchiver_ShouldCallFormatterAndArchive_WhenMessageArchived()
    {
        // Arrange
        var mockFormatter = new MockFormatter();
        var archiver = new FormattingArchiver(mockFormatter);
        var message = new Message("Title", "Body", ImportanceLevel.Normal);

        // Act
        archiver.Archive(message);

        // Assert
        Assert.Equal(1, mockFormatter.FormatTitleCalls);
        Assert.Equal(1, mockFormatter.FormatBodyCalls);
    }

    [Fact]
    public void GroupRecipient_ShouldDeliveredOneMessage_WhenCallFilteredAndNormalRecipients()
    {
        // Arrange
        var user = new User();
        var recipient1 = new UserRecipient(user);
        var recipient2 = new UserRecipient(user);
        var groupRecipient = new GroupRecipient();
        var filteredRecipient = new ImportanceFilter(recipient1, ImportanceLevel.Normal);
        groupRecipient.AddRecipient(filteredRecipient);
        groupRecipient.AddRecipient(recipient2);
        var message = new Message("Title", "Body", ImportanceLevel.Low);

        // Act
        groupRecipient.Receive(message);

        // Assert
        Assert.False(user.Messages.Count >= 2);
        Assert.Single(user.Messages);
    }
}