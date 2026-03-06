using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MockRecipient : IRecipient
{
    private readonly List<Message> _messages = new();

    public IReadOnlyList<Message> Messages => _messages.AsReadOnly();

    public int MessageCalls => _messages.Count;

    public void Receive(Message message)
    {
        _messages.Add(message);
    }
}