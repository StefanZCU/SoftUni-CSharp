namespace EDriveRent.Models.Vehicles;

public class PassengerCar : Vehicle
{
    private const double MAX_MILEAGE = 450;
    
    public PassengerCar(string brand, string model, string licensePlateNumber) : base(brand, model, MAX_MILEAGE, licensePlateNumber)
    {
    }
    
    
}