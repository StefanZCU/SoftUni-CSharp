namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int BED_CAPACITY = 6;

        public Apartment() : base(BED_CAPACITY)
        {
        }
    }
}
