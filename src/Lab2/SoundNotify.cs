namespace Itmo.ObjectOrientedProgramming.Lab2;

public class SoundNotify : INotificationSystem
{
    public void Notify()
    {
        Console.Beep();
    }
}