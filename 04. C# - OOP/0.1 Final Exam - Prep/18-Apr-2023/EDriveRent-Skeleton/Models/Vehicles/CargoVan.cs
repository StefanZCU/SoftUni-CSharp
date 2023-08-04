namespace EDriveRent.Models.Vehicles;

public class CargoVan : Vehicle
{
    private const double MAX_MILEAGE = 180;
    public CargoVan(string brand, string model, string licensePlateNumber) : base(brand, model, MAX_MILEAGE, licensePlateNumber)
    {
    }
}