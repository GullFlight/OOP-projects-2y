using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class AlertSystemRecipient : IRecipient
{
    private readonly INotificationSystem _alertSystem;
    private readonly string[] _suspiciousWords;

    public AlertSystemRecipient(INotificationSystem alertSystem, string[] suspiciousWords)
    {
        _alertSystem = alertSystem;
        _suspiciousWords = suspiciousWords;
    }

    public void Receive(Message message)
    {
        string fullText = message.Title + " \n" + message.Body;
        if (_suspiciousWords.Any(suspiciousWord =>
                fullText.Contains(suspiciousWord, StringComparison.OrdinalIgnoreCase)))
        {
            _alertSystem.Notify();
        }
    }
}