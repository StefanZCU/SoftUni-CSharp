using System.Linq;
using System.Text;
using EDriveRent.Core.Contracts;
using EDriveRent.Models.Contracts;
using EDriveRent.Models.Routes;
using EDriveRent.Models.Users;
using EDriveRent.Models.Vehicles;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core;

public class Controller : IController
{
    private UserRepository users = new();
    private VehicleRepository vehicles = new();
    private RouteRepository routes = new();

    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {
        if (users.FindById(drivingLicenseNumber) != null)
        {
            return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }

        var newUser = new User(firstName, lastName, drivingLicenseNumber);
        users.AddModel(newUser);

        return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
    }

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {
        if (vehicleType != nameof(PassengerCar) &&
            vehicleType != nameof(CargoVan))
        {
            return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
        }

        if (vehicles.FindById(licensePlateNumber) != null)
        {
            return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }

        IVehicle vehicle = vehicleType switch
        {
            nameof(PassengerCar) => new PassengerCar(brand, model, licensePlateNumber),
            _ => new CargoVan(brand, model, licensePlateNumber)
        };

        vehicles.AddModel(vehicle);
        return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
    }

    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        if (routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length == length) !=
            null)
        {
            return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
        }

        var roadToFind = routes.GetAll().FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint);

        if (roadToFind != null && roadToFind.Length < length)
        {
            return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
        }

        if (roadToFind != null  && roadToFind.Length > length)
        {
            roadToFind.LockRoute();
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        var route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
        routes.AddModel(route);
        return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
    }

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId,
        bool isAccidentHappened)
    {
        var user = users.FindById(drivingLicenseNumber);
        var vehicle = vehicles.FindById(licensePlateNumber);
        var route = routes.FindById(routeId);

        if (user.IsBlocked)
        {
            return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }

        if (vehicle.IsDamaged)
        {
            return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }

        if (route.IsLocked)
        {
            return string.Format(OutputMessages.RouteLocked, routeId);
        }
        
        vehicle.Drive(route.Length);

        if (isAccidentHappened)
        {
            vehicle.ChangeStatus();
            user.DecreaseRating();
        }
        else
        {
            user.IncreaseRating();
        }

        return vehicle.ToString();

    }

    public string RepairVehicles(int count)
    {
        var damagedVehicles = vehicles.GetAll().Where(x => x.IsDamaged).OrderBy(x => x.Brand).ThenBy(x => x.Model).Take(count).ToList();

        foreach (var vehicle in damagedVehicles)
        {
            vehicle.Recharge();
            vehicle.ChangeStatus();
        }

        return string.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
        
    }

    public string UsersReport()
    {
        var sb = new StringBuilder();
        sb.AppendLine("*** E-Drive-Rent ***");

        foreach (var user in users.GetAll().OrderByDescending(x => x.Rating).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
        {
            sb.AppendLine(user.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}