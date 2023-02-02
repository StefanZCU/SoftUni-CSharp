namespace Telephony.Models
{
    using Interfaces;
    using Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhone(phoneNumber))
            {
                throw new InvalidPhoneException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhone(string phoneNumber)
            => phoneNumber.All(char.IsDigit);
    }
}
