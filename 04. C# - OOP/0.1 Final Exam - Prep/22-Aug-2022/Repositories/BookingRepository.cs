namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using BookingApp.Models.Bookings.Contracts;
    using Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }
    }
}
