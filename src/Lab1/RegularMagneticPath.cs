namespace Itmo.ObjectOrientedProgramming.Lab1;

public class RegularMagneticPath : IRouteSegment
{
    private readonly Distance _length;

    public RegularMagneticPath(Distance length)
    {
        _length = length;
    }

    public MoveResult PassThrough(Train train)
    {
        train.SetZeroAcceleration();

        MoveResult result = train.CalculateTimeForDistance(_length);
        return result switch
        {
            MoveResult.Failure => new MoveResult.Failure(),
            MoveResult.Success success => new MoveResult.Success(success.Time),
            _ => new MoveResult.Failure(),
        };
    }
}