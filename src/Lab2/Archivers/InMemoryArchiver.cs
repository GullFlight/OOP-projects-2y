using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class InMemoryArchiver : IMessageArchiver
{
    private readonly List<Message> _messages = new();

    public IReadOnlyList<Message> Messages => _messages.AsReadOnly();

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}