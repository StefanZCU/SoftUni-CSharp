namespace Telephony.Models.Interfaces
{
    public interface ISmartphone : IStationaryPhone
    {
        public string BrowseURL(string site);
    }
}
