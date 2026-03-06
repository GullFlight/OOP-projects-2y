namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public Speed Speed { get; private set; }

    public Acceleration Acceleration { get; private set; }

    private readonly Mass _mass;

    private readonly Force _maxForce;

    private readonly Time _precision;

    public Train(Mass mass, Force maxForce, Time precision)
    {
        _mass = mass;
        _maxForce = maxForce;
        Speed = new Speed(0);
        Acceleration = new Acceleration(0);
        _precision = new Time(1);
    }

    public void SetZeroAcceleration()
    {
        Acceleration = new Acceleration(0);
    }

    public ApplyForceResult ApplyForce(Force force)
    {
        if (Math.Abs(force.Value) > _maxForce.Value)
            return new ApplyForceResult.Failure();

        Acceleration = new Acceleration(force.Value / _mass.Value);
        return new ApplyForceResult.Success();
    }

    public MoveResult CalculateTimeForDistance(Distance distance)
    {
        var time = new Time(0);
        Distance remainingDistance = distance;
        Speed currentSpeed = Speed;

        while (remainingDistance.Value > 0)
        {
            var newSpeed = new Speed(
                currentSpeed.Value +
                (Acceleration.Value * _precision.Value));

            var distanceThisStep = new Distance(newSpeed.Value * _precision.Value);

            if (distanceThisStep.Value <= 0 && remainingDistance.Value > 0)
                return new MoveResult.Failure();

            if (remainingDistance.Value < distanceThisStep.Value)
            {
                var exactTime = new Time(remainingDistance.Value / newSpeed.Value);
                time = new Time(exactTime.Value + time.Value);
                remainingDistance = new Distance(0);
                currentSpeed = newSpeed;
            }
            else
            {
                remainingDistance = new Distance(remainingDistance.Value - distanceThisStep.Value);
                currentSpeed = newSpeed;
                time = new Time(time.Value + _precision.Value);
            }
        }

        Speed = currentSpeed;

        return new MoveResult.Success(time);
    }
}