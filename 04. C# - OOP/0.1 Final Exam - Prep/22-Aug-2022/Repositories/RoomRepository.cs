namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using BookingApp.Models.Rooms.Contracts;
    using Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(x => x.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }
    }
}
