namespace Itmo.ObjectOrientedProgramming.Lab2;

public class TextNotify : INotificationSystem
{
    public string Text { get; }

    public TextNotify(string text)
    {
        Text = text;
    }

    public void Notify()
    {
        Console.WriteLine(Text);
    }
}