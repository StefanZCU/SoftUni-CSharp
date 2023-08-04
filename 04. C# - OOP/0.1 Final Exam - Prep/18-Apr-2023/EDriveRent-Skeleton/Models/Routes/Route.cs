namespace EDriveRent.Models.Routes;

using System;

using Contracts;
using Utilities.Messages;

public class Route : IRoute
{
    private string startPoint;
    private string endPoint;
    private double length;

    public Route(string startPoint, string endPoint, double length, int routeId)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        Length = length;
        RouteId = routeId;
    }

    public string StartPoint
    {
        get => startPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.StartPointNull);
            }

            startPoint = value;
        }
    }

    public string EndPoint
    {
        get => endPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.EndPointNull);
            }

            endPoint = value;
        }
    }

    public double Length
    {
        get => length;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
            }

            length = value;
        }
    }

    public int RouteId { get; private set; }

    public bool IsLocked { get; private set; }
    
    public void LockRoute()
    {
        IsLocked = true;
    }
}