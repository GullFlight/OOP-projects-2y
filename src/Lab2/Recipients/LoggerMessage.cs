using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggerMessage : IRecipient
{
    private readonly ILogger _logger;

    private readonly IRecipient _recipient;

    public LoggerMessage(IRecipient recipient, ILogger logger)
    {
        _logger = logger;
        _recipient = recipient;
    }

    public void Receive(Message message)
    {
        _recipient.Receive(message);
        _logger.Log($" Received message: {message.Title}");
    }
}