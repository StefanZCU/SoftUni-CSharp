using System.Xml.Serialization;

namespace Medicines.Extensions
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T deserializedDtos = (T)xmlSerializer.Deserialize(reader);

            return deserializedDtos;
        }
    }
}
