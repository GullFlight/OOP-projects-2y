namespace Itmo.ObjectOrientedProgramming.Lab3.Battlefield;

public class Randomizer : IRandom
{
    private readonly int _random;

    public Randomizer(int random)
    {
        _random = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
    }

    public int RandomNumber(int max)
    {
        return _random % max;
    }
}