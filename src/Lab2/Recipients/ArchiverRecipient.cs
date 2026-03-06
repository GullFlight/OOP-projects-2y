using Itmo.ObjectOrientedProgramming.Lab2.Archivers;

using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IMessageArchiver _archiver;

    public ArchiverRecipient(IMessageArchiver recipient)
    {
        _archiver = recipient;
    }

    public void Receive(Message message)
    {
        _archiver.Archive(message);
    }
}