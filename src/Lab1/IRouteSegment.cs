namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface IRouteSegment
{
    MoveResult PassThrough(Train train);
}