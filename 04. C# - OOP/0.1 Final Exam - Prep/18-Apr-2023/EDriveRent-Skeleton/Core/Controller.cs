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

        IUser newUser = new User(firstName, lastName, drivingLicenseNumber);
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
        int routeId = this.routes.GetAll().Count + 1;

        IRoute existingRoute = this.routes
            .GetAll()
            .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);
                        
        if (existingRoute != null)
        {
            if (existingRoute.Length == length)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            else if(existingRoute.Length < length)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            else if (existingRoute.Length > length)
            {
                existingRoute.LockRoute();
            }
        }
        IRoute newRoute = new Route(startPoint, endPoint, length, routeId);
        this.routes.AddModel(newRoute);

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
        var damagedVehicles = this.vehicles.GetAll().Where(v => v.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model);

        int vehiclesCount = 0;

        vehiclesCount = damagedVehicles.Count() < count ? damagedVehicles.Count() : count;

        var selectedVehicles = damagedVehicles.ToArray().Take(vehiclesCount);

        foreach (var vehicle in selectedVehicles)
        {
            vehicle.ChangeStatus();
            vehicle.Recharge();
        }

        return string.Format(OutputMessages.RepairedVehicles, vehiclesCount);
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