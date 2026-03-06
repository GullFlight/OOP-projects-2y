namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : IRouteSegment
{
    private readonly Speed _speedLimit;

    private readonly Time _stationTime;

    public Station(Speed speedLimit, Time stationTime)
    {
        _speedLimit = speedLimit;
        _stationTime = stationTime;
    }

    public MoveResult PassThrough(Train train)
    {
        if (train.Speed.Value > _speedLimit.Value)
        {
            return new MoveResult.Failure();
        }

        return new MoveResult.Success(_stationTime);
    }
}