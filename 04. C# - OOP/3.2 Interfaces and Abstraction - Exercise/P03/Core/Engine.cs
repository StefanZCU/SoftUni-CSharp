
namespace Telephony.Core
{
    using Interfaces;
    using Models;
    using Telephony.IO.Interfaces;
    using Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;

        public Engine()
        {
            smartphone = new Smartphone();
            stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ");
            string[] urls = reader.ReadLine().Split(" ");

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                }
                catch (InvalidPhoneException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.BrowseURL(url));
                }
                catch (InvalidURLException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
