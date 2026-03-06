using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ImportanceFilter : IRecipient
{
    private readonly ImportanceLevel _importanceLevel;

    private readonly IRecipient _recipient;

    public ImportanceFilter(IRecipient recipient, ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
        _recipient = recipient;
    }

    public void Receive(Message message)
    {
        if (_importanceLevel <= message.Importance)
        {
            _recipient.Receive(message);
        }
    }
}