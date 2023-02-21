namespace BookingApp.Models.Rooms
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Room : IRoom
    {
        private double pricePerNight;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; }

        public double PricePerNight
        {
            get => pricePerNight;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
