namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Hotels.Contacts;
    using Contracts;

    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return hotels.FirstOrDefault(x => x.FullName == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }
    }
}
