namespace EDriveRent.Models.Vehicles;

using System;

using Contracts;
using Utilities.Messages;

public abstract class Vehicle : IVehicle
{
    private string brand;
    private string model;
    private string licensePlateNumber;

    protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
    {
        Brand = brand;
        Model = model;
        MaxMileage = maxMileage;
        LicensePlateNumber = licensePlateNumber;
        BatteryLevel = 100;
    }

    public string Brand
    {
        get => brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandNull);
            }

            brand = value;
        }
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNull);
            }

            model = value;
        }
    }

    public double MaxMileage { get; private set; }

    public string LicensePlateNumber
    {
        get => licensePlateNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
            }

            licensePlateNumber = value;
        }
    }

    public int BatteryLevel { get; private set; }

    public bool IsDamaged { get; private set; }

    public void Drive(double mileage)
    {
        BatteryLevel -= (int)Math.Round((mileage / MaxMileage) * 100);

        if (this.GetType() == typeof(CargoVan))
        {
            BatteryLevel -= 5;
        }
    }

    public void Recharge()
    {
        BatteryLevel = 100;
    }

    public void ChangeStatus()
    {
        IsDamaged = !IsDamaged;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK/damaged";
    }
}