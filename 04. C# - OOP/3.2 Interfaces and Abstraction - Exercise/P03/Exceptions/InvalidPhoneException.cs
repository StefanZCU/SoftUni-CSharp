namespace Telephony.Exceptions
{
    public class InvalidPhoneException : Exception
    {
        private const string DefaultMessage = "Invalid number!";

        public InvalidPhoneException() : base(DefaultMessage)
        {
            
        }

        public InvalidPhoneException(string message) : base(message)
        {

        }
    }
}
