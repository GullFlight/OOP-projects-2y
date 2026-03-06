namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ForceMagneticPath : IRouteSegment
{
    private readonly Distance _length;

    private readonly Force _force;

    public ForceMagneticPath(Distance length, Force force)
    {
        _length = length;
        _force = force;
    }

    public MoveResult PassThrough(Train train)
    {
        if (train.ApplyForce(_force) is ApplyForceResult.Failure)
            return new MoveResult.Failure();

        MoveResult result = train.CalculateTimeForDistance(_length);

        return result;
    }
}