namespace Itmo.ObjectOrientedProgramming.Lab2.UserItems;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _messages = new();

    public IReadOnlyDictionary<Message, MessageStatus> Messages => _messages;

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message, MessageStatus.Unread);
    }

    public void MarkMessageAsRead(Message message)
    {
        if (_messages[message] == MessageStatus.Read)
        {
            throw new InvalidOperationException($"Message {message} already read");
        }

        _messages[message] = MessageStatus.Read;
    }
}
