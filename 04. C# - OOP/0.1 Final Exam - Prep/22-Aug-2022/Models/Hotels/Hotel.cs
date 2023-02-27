namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using Contacts;
    using Bookings.Contracts;
    using Rooms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                fullName = value;
            }
        }

        public int Category
        {
            get => category;

            private set
            {
                if (value is < 1 or > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover => Math.Round(Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get; }
        public IRepository<IBooking> Bookings { get; }
    }
}
