namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    using Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using Utilities.Messages;

    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; }
        public int ResidenceDuration
        {
            get => residenceDuration;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get => adultsCount;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get => childrenCount;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
            }
        }
        public int BookingNumber { get; }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {Math.Round(ResidenceDuration * Room.PricePerNight, 2):F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}
