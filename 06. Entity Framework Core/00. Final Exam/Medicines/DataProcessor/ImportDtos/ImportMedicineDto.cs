using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        [XmlElement("Price")]
        public double Price { get; set; }

        [Required]
        [XmlAttribute("category")]
        [EnumDataType(typeof(Category))]
        public int Category { get; set; }

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; }

        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        [XmlElement("Producer")]
        public string Producer { get; set; }
    }
}
