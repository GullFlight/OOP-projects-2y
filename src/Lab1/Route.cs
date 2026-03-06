namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private IReadOnlyCollection<IRouteSegment> Segments { get; }

    private readonly Speed _speedLimit;

    public Route(Speed speedLimit, IReadOnlyCollection<IRouteSegment> segments)
    {
        _speedLimit = speedLimit;
        Segments = segments;
    }

    public RouteResult Simulate(Train train)
    {
        foreach (IRouteSegment segment in Segments)
        {
            MoveResult result = segment.PassThrough(train);

            if (result is MoveResult.Failure failure)
                return new RouteResult.Failure();
        }

        if (train.Speed.Value > _speedLimit.Value)
        {
            return new RouteResult.Failure();
        }

        return new RouteResult.Success();
    }
}