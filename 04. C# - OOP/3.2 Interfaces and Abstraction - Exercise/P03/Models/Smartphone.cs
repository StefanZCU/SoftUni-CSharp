namespace Telephony.Models
{
    using Interfaces;
    using Exceptions;

    public class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhone(phoneNumber))
            {
                throw new InvalidPhoneException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string BrowseURL(string site)
        {
            if (!ValidateURL(site))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {site}!";
        }


        private bool ValidatePhone(string phoneNumber)
            => phoneNumber.All(char.IsDigit);

        private bool ValidateURL(string url)
        => url.All(x => !char.IsDigit(x));
    }
}
