using System.Collections.ObjectModel;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SimulatorTests
{
    [Fact]
    public void Simulate_ShouldReturnSuccess_WhenTrainAcceleratesToAllowedSpeedPassesRegularPath()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var acceleratingPath = new ForceMagneticPath(new Distance(500), new Force(3000));
        var regularPath = new RegularMagneticPath(new Distance(300));

        var segments = new Collection<IRouteSegment> { acceleratingPath, regularPath };
        var route = new Route(new Speed(60), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnFailure_WhenTrainExceedsRouteSpeedLimit()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var acceleratingPath = new ForceMagneticPath(new Distance(1000), new Force(4000));
        var regularPath = new RegularMagneticPath(new Distance(1000));

        var segments = new Collection<IRouteSegment> { acceleratingPath, regularPath };
        var route = new Route(new Speed(20), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnSuccess_WhenTrainAcceleratesToAllowedSpeedPassesStationAndRegularPath()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var acceleratingPath = new ForceMagneticPath(new Distance(800), new Force(2000));
        var regularPath1 = new RegularMagneticPath(new Distance(300));
        var station = new Station(new Speed(60), new Time(2));
        var regularPath2 = new RegularMagneticPath(new Distance(400));

        var segments = new Collection<IRouteSegment> { acceleratingPath, regularPath1, station, regularPath2 };
        var route = new Route(new Speed(70), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnFailure_WhenTrainExceedsStationSpeedLimit()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var acceleratingPath = new ForceMagneticPath(new Distance(1000), new Force(4000));
        var station = new Station(new Speed(20), new Time(2));

        var segments = new Collection<IRouteSegment> { acceleratingPath, station };
        var route = new Route(new Speed(30), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnFailure_WhenTrainExceedsRouteSpeedLimitButWithinStationLimit()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var acceleratingPath = new ForceMagneticPath(new Distance(1000), new Force(365));
        var regularPath1 = new RegularMagneticPath(new Distance(300));
        var station = new Station(new Speed(30), new Time(2));
        var regularPath2 = new RegularMagneticPath(new Distance(400));

        var segments = new Collection<IRouteSegment> { acceleratingPath, regularPath1, station, regularPath2 };
        var route = new Route(new Speed(25), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnSuccess_WhenTrainAdjustsSpeedForStationAndRouteLimits()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        // Разгон выше лимита станции
        var acceleratingPath1 = new ForceMagneticPath(new Distance(800), new Force(777));
        var regularPath1 = new RegularMagneticPath(new Distance(200));

        // Замедление до лимита станции
        var deceleratingPath1 = new ForceMagneticPath(new Distance(500), new Force(-555));

        var station = new Station(new Speed(30), new Time(2));
        var regularPath2 = new RegularMagneticPath(new Distance(300));

        var acceleratingPath2 = new ForceMagneticPath(new Distance(600), new Force(3500));
        var regularPath3 = new RegularMagneticPath(new Distance(200));

        // Замедление до лимита маршрута
        var deceleratingPath2 = new ForceMagneticPath(new Distance(400), new Force(-4500));

        var segments = new Collection<IRouteSegment>
        {
            acceleratingPath1, regularPath1, deceleratingPath1,
            station, regularPath2, acceleratingPath2,
            regularPath3, deceleratingPath2,
        };
        var route = new Route(new Speed(40), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnFailure_WhenTrainHasNoAccelerationOnRegularPath()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var regularPath = new RegularMagneticPath(new Distance(500));

        var segments = new Collection<IRouteSegment> { regularPath };
        var route = new Route(new Speed(30), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void Simulate_ShouldReturnFailure_WhenAppliedForceExceedsMaxForce()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new Force(5000);
        var train = new Train(mass, maxForce, new Time(1));

        var forcePath1 = new ForceMagneticPath(new Distance(500), new Force(2000));
        var forcePath2 = new ForceMagneticPath(new Distance(500), new Force(-4000));

        var segments = new Collection<IRouteSegment> { forcePath1, forcePath2 };
        var route = new Route(new Speed(30), segments);

        // Act
        RouteResult result = route.Simulate(train);

        // Assert
        Assert.IsType<RouteResult.Failure>(result);
    }
}