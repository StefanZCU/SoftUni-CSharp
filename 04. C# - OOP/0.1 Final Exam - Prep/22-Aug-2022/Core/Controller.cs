namespace BookingApp.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Bookings;
    using Models.Hotels;
    using Models.Hotels.Contacts;
    using Models.Rooms;
    using Repositories;
    using Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Bookings.Contracts;

    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            if (roomTypeName != nameof(Studio) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = roomTypeName switch
            {
                nameof(Studio) => new Studio(),
                nameof(Apartment) => new Apartment(),
                _ => new DoubleBed()
            };

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(Studio) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotel.Rooms.All().All(x => roomTypeName != x.GetType().Name))
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            var room = hotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = hotels.All()
                .OrderBy(x => x.FullName).ToList();

            if (orderedHotels.All(x => x.Category != category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            int countPeople = adults + children;

            IRoom roomToFind = countPeople switch
            {
                <= 2 => new DoubleBed(),
                <= 4 => new Studio(),
                <= 6 => new Apartment(),
                _ => null
            };

            foreach (var hotel in orderedHotels)
            {
                var room = hotel.Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity)
                    .FirstOrDefault(x => x.BedCapacity >= adults + children);

                if (room != null && roomToFind != null)
                {
                    if (room.GetType().Name != roomToFind.GetType().Name) continue;
                }
                else
                {
                    continue;
                }

                IBooking booking = new Booking(room, duration, adults, children, hotel.Bookings.All().Count + 1);
                hotel.Bookings.AddNew(booking);

                return string.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Count, hotel.FullName);


            }

            return OutputMessages.RoomNotAppropriate;
        }


        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();

            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            sb
                .AppendLine($"Hotel name: {hotelName}")
                .AppendLine($"--{hotel.Category} star hotel")
                .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
                .AppendLine($"--Bookings:")
                .AppendLine();
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var hotelBooking in hotel.Bookings.All())
                {
                    sb.AppendLine(hotelBooking.BookingSummary());
                    sb.AppendLine();
                }
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
