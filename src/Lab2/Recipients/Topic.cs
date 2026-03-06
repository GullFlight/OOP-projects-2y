using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class Topic
{
    private readonly List<IRecipient> _recipients = new();

    public string Name { get; }

    public Topic(string name)
    {
        Name = name;
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}